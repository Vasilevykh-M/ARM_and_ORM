using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace АРМ
{
    public partial class UserForm : Form
    {
        public UserForm()
        {
            InitializeComponent();

            dgv1.Columns.Add("id", "id");
            dgv1.Columns["id"].Visible = false;
            dgv1.Columns.Add("login", "Логин");
            dgv1.Columns.Add("password", "Хэш-пароля");
            dgv1.Columns.Add("lvl", "Уровень должности в системе");

            show();
        }

        private void UserForm_Load(object sender, EventArgs e)
        {

        }

        private void show()
        {
            using (var db = new laba8_bdContext())
            {
                var users = db.Users.ToList();
                foreach(var egge in users)
                {
                    int id = dgv1.Rows.Add(egge.Id, egge.Login, egge.Password, egge.Lvl);
                    dgv1.Rows[id].Tag = new List<object>() {egge.Id, egge.Login, egge.Password, egge.Lvl };
                }
            }
        }

        private void dgv1_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            var row = dgv1.Rows[e.RowIndex];
            row.ErrorText = "";

            foreach (var columnName in new[] { "login", "password", "lvl" })
            {
                if (row.Cells[columnName].Value != null)
                {
                    var cellValue = row.Cells[columnName].Value.ToString();
                    if (string.IsNullOrWhiteSpace(cellValue))
                    {
                        var columnText = row.Cells[columnName].OwningColumn.HeaderText;
                        row.ErrorText = $"Значение в стлобце ' {columnText}'не должно быть пустым";
                        return;
                    }
                }
                else
                {
                    var columnText = row.Cells[columnName].OwningColumn.HeaderText;
                    row.ErrorText = $"Значение в стлобце ' {columnText}'не должно быть пустым";
                    return;
                }
            }

            var newid = (int?)dgv1.Rows[e.RowIndex].Cells["id"].Value;

            using (var db = new laba8_bdContext())
            {
                if(newid.HasValue)
                {
                    var user = db.Users.Find(newid);

                    string str = "";
                    if ((row.Tag as List<object>)[2].ToString() == row.Cells[2].Value.ToString())
                    {
                        str = row.Cells[2].Value.ToString();
                    }
                    else
                    {
                        str = BCrypt.Net.BCrypt.HashPassword(row.Cells[2].Value.ToString());
                    }

                    user.Login = row.Cells[1].Value.ToString();
                    user.Password = str;
                    user.Lvl = Int32.Parse(row.Cells[3].Value.ToString());
                    db.SaveChanges();
                }
                else
                {
                    User user = new User()
                    {
                        Login = row.Cells[1].Value.ToString(),
                        Password = BCrypt.Net.BCrypt.HashPassword(row.Cells[2].Value.ToString()),
                        Lvl = Int32.Parse(row.Cells[3].Value.ToString())
                    };
                    db.Users.Add(user);
                    db.SaveChanges();
                    var id = user.Id;

                    dgv1.Rows[e.RowIndex].Cells["id"].Value = (int)id;

                    var obj = db.Users.Find((int)id);

                    dgv1.Rows[e.RowIndex].Tag = new List<object>() { obj.Login, obj.Password, obj.Lvl };

                }
            }
        }

        private void dgv1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var newid = (int?)e.Row.Cells["id"].Value;

            if (!newid.HasValue)
                return;

            using (var db = new laba8_bdContext())
            {
                var user = db.Users.Find(newid);
                db.Users.Remove(user);
                db.SaveChanges();
            }
        }

        private void dgv1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                dgv1.CancelEdit();

                if (dgv1.CurrentRow.Cells["id"].Value != null)
                {
                    List<object> a = (List<object>)dgv1.CurrentRow.Tag;
                    dgv1.CurrentRow.Cells["login"].Value = a[0];
                    dgv1.CurrentRow.Cells["password"].Value = a[1];
                    dgv1.CurrentRow.Cells["lvl"].Value = a[2];
                }
                else
                {
                    dgv1.Rows.Remove(dgv1.CurrentRow);
                }
            }
        }
    }
}
