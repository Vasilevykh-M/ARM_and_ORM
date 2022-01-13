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
    public partial class productForm : Form
    {
        int curRow = -1;
        public productForm(int user)
        {
            InitializeComponent();
            dgv1.Columns.Add("id", "id");
            dgv1.Columns["id"].Visible = false;
            //dgv1.Columns["id"].ReadOnly = true;
            dgv1.Columns.Add("id_groop", "Группа товара");
            dgv1.Columns.Add("name_pr", "Название товара");
            dgv1.Columns.Add("instruct", "Наличие инструкции к товару");
            dgv1.Columns.Add("term", "Срок хранения(в днях)");
            dgv1.Columns.Add("cost_pr", "Цена");

            this.user = user;
            show();
        }
        public int user;
        private void show()
        {
            using (var db = new laba8_bdContext())
            {
                var users = db.Products.ToList();
                foreach (var egge in users)
                {
                    int id = dgv1.Rows.Add(egge.Id, egge.IdGroop, egge.NamePr, egge.Instruct, egge.Term, egge.CostPr);
                    dgv1.Rows[id].Tag = new List<object>() { egge.Id, egge.IdGroop, egge.NamePr, egge.Instruct, egge.Term, egge.CostPr };
                }
            }
        }

        private void productForm_Load(object sender, EventArgs e)
        {

        }

        private void dgv1_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            var row = dgv1.Rows[e.RowIndex];
            row.ErrorText = "";
            if (user == 2)
            {
                row.ErrorText = "Нет доступа к редактированию данной таблицы";
                return;
            }
            

            foreach (var columnName in new[] { "id_groop", "name_pr", "instruct", "term", "cost_pr" })
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
                if (newid.HasValue)
                {
                    var user = db.Products.Find(newid);
                    user.IdGroop = Int32.Parse(row.Cells[1].Value.ToString());
                    user.NamePr = row.Cells[2].Value.ToString();
                    user.Instruct = bool.Parse(row.Cells[3].Value.ToString());
                    user.Term = Int32.Parse(row.Cells[4].Value.ToString());
                    user.CostPr = Int32.Parse(row.Cells[5].Value.ToString());
                    db.SaveChanges();
                }
                else
                {
                    Product user = new Product()
                    {
                        IdGroop = Int32.Parse(row.Cells[1].Value.ToString()),
                        NamePr = row.Cells[2].Value.ToString(),
                        Instruct = bool.Parse(row.Cells[3].Value.ToString()),
                        Term = Int32.Parse(row.Cells[4].Value.ToString()),
                        CostPr = Int32.Parse(row.Cells[5].Value.ToString())
                };
                    db.Products.Add(user);
                    db.SaveChanges();
                    var id = user.Id;

                    dgv1.Rows[e.RowIndex].Cells["id"].Value = (int)id;

                    var obj = db.Products.Find((int)id);

                    dgv1.Rows[e.RowIndex].Tag = new List<object>() { obj.Id, obj.IdGroop, obj.NamePr, obj.Instruct, obj.Term, obj.CostPr };

                }
            }
        }

        private void dgv1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {

            var row = e.Row;
            row.ErrorText = "";
            if (user == 2)
            {
                row.ErrorText = "Нет доступа к редактированию данной таблицы";
                return;
            }

            var newid = (int?)e.Row.Cells["id"].Value;

            if (!newid.HasValue)
                return;

            using (var db = new laba8_bdContext())
            {
                var user = db.Products.Find(newid);
                db.Products.Remove(user);
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
                    dgv1.CurrentRow.Cells["name_pr"].Value = a[2];
                    dgv1.CurrentRow.Cells["instruct"].Value = a[3];
                    dgv1.CurrentRow.Cells["term"].Value = a[4];
                    dgv1.CurrentRow.Cells["cost_pr"].Value = a[5];
                }
                else
                {
                    dgv1.Rows.Remove(dgv1.CurrentRow);
                }
            }
        }

        private void dgv2_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void dgv1_SelectionChanged(object sender, EventArgs e)
        {

        }
    }
}
