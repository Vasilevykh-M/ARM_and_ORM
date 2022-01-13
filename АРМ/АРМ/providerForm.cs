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
    public partial class providerForm : Form
    {
        public providerForm(int user)
        {
            InitializeComponent();
            dgv1.Columns.Add("id", "id");
            dgv1.Columns["id"].Visible = false;
            dgv1.Columns.Add("name_pr", "Название поставщика");
            dgv1.Columns.Add("id_bank", "id_bank");
            dgv1.Columns["id_bank"].Visible = false;
            dgv1.Columns.Add("code_payment", "Счёт");
            dgv1.Columns.Add("count_delays", "Кол-во просрочек поставок");
            dgv1.Columns.Add(new CalendarColumn
            {
                Name = "data_coop",
                HeaderText = "Дата договора"
            });

            dgv2.Columns.Add("id", "id");
            dgv2.Columns["id"].Visible = false;
            dgv2.Columns.Add("name_bank", "Название банка");
            dgv2.Columns.Add("lvl_licenses", "Уровень лицензии");
            dgv2.Columns.Add("active", "Активы");

            this.USER = user;
            show1();
            show2();
        }
        int USER;

        private void show1()
        {
            using (var db = new laba8_bdContext())
            {
                var users = db.Providers.ToList();
                foreach (var egge in users)
                {
                    int id = dgv1.Rows.Add(
                        egge.Id,egge.NamePr, egge.IdBank, 
                        egge.CodePayment, egge.CountDelays, egge.DataCoop);
                    dgv1.Rows[id].Tag = new List<object>() { 
                        egge.Id, egge.NamePr, egge.IdBank, 
                        egge.CodePayment, egge.CountDelays, egge.DataCoop };
                }
            }
        }

        private void show2()
        {
            using (var db = new laba8_bdContext())
            {
                var users = db.Banks.ToList();
                foreach (var egge in users)
                {
                    int id = dgv2.Rows.Add(
                        egge.Id, egge.NameBank, egge.LvlLicenses, egge.Active);
                    dgv2.Rows[id].Tag = new List<object>() {
                        egge.Id, egge.NameBank, egge.LvlLicenses, egge.Active };
                }
            }
        }

        private void providerForm_Load(object sender, EventArgs e)
        {

        }

        private void dgv1_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            var row = dgv1.Rows[e.RowIndex];
            row.ErrorText = "";
            if (USER == 2)
            {
                row.ErrorText = "Нет доступа к редактированию данной таблицы";
                return;
            }


            foreach (var columnName in new[] { "name_pr", "code_payment", "count_delays", "data_coop"})
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
                    var user = db.Providers.Find(newid);
                    user.NamePr = row.Cells["name_pr"].Value.ToString();
                    user.CodePayment = row.Cells["code_payment"].Value.ToString();
                    user.CountDelays = Int32.Parse(row.Cells["count_delays"].Value.ToString());
                    user.DataCoop = (DateTime)row.Cells["data_coop"].Value;
                    db.SaveChanges();
                }
                else
                {
                    Provider user = new Provider()
                    {
                        NamePr = row.Cells["name_pr"].Value.ToString(),
                        CodePayment = row.Cells["code_payment"].Value.ToString(),
                        CountDelays = Int32.Parse(row.Cells["count_delays"].Value.ToString()),
                        DataCoop = (DateTime)row.Cells["data_coop"].Value
                };
                    db.Providers.Add(user);
                    db.SaveChanges();
                    var id = user.Id;

                    dgv1.Rows[e.RowIndex].Cells["id"].Value = (int)id;

                    var obj = db.Providers.Find((int)id);

                    dgv1.Rows[e.RowIndex].Tag = new List<object>() 
                    {
                        obj.Id, 
                        obj.NamePr, 
                        obj.IdBank, 
                        obj.CodePayment,
                        obj.CountDelays,
                        obj.DataCoop
                    };

                }
            }
        }

        private void dgv2_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            var row = dgv2.Rows[e.RowIndex];
            row.ErrorText = "";
            if (USER == 2)
            {
                row.ErrorText = "Нет доступа к редактированию данной таблицы";
                return;
            }


            foreach (var columnName in new[] { "name_bank", "lvl_licenses", "active"})
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

            var newid = (int?)dgv2.Rows[e.RowIndex].Cells["id"].Value;

            using (var db = new laba8_bdContext())
            {
                if (newid.HasValue)
                {
                    var user = db.Banks.Find(newid);
                    user.NameBank = row.Cells["name_bank"].Value.ToString();
                    user.LvlLicenses = Int32.Parse(row.Cells["lvl_licenses"].Value.ToString());
                    user.Active = Int32.Parse(row.Cells["active"].Value.ToString());
                    db.SaveChanges();
                }
                else
                {
                    Bank user = new Bank()
                    {
                        NameBank = row.Cells["name_bank"].Value.ToString(),
                        LvlLicenses = Int32.Parse(row.Cells["lvl_licenses"].Value.ToString()),
                        Active = Int32.Parse(row.Cells["active"].Value.ToString()),
                    };
                    db.Banks.Add(user);
                    db.SaveChanges();
                    var id = user.Id;

                    dgv2.Rows[e.RowIndex].Cells["id"].Value = (int)id;

                    var obj = db.Banks.Find((int)id);

                    dgv1.Rows[e.RowIndex].Tag = new List<object>() 
                    {
                        obj.Id,
                        obj.NameBank,
                        obj.LvlLicenses,
                        obj.Active
                    };

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
                var user = db.Providers.Find(newid);
                db.Providers.Remove(user);
                db.SaveChanges();
            }
        }

        private void dgv2_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var newid = (int?)e.Row.Cells["id"].Value;

            if (!newid.HasValue)
                return;

            using (var db = new laba8_bdContext())
            {
                var user = db.Banks.Find(newid);
                db.Banks.Remove(user);
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
                    dgv1.CurrentRow.Cells["name_pr"].Value = a[1];
                    dgv1.CurrentRow.Cells["code_payment"].Value = a[3];
                    dgv1.CurrentRow.Cells["count_delays"].Value = a[4];
                    dgv1.CurrentRow.Cells["data_coop"].Value = a[5];
                }
                else
                {
                    dgv1.Rows.Remove(dgv1.CurrentRow);
                }
            }
        }

        private void dgv2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                dgv2.CancelEdit();

                if (dgv1.CurrentRow.Cells["id"].Value != null)
                {
                    List<object> a = (List<object>)dgv1.CurrentRow.Tag;
                    dgv2.CurrentRow.Cells["name_bank"].Value = a[1];
                    dgv2.CurrentRow.Cells["lvl_licenses"].Value = a[2];
                    dgv2.CurrentRow.Cells["active"].Value = a[3];
                }
                else
                {
                    dgv2.Rows.Remove(dgv1.CurrentRow);
                }
            }
        }

        private void dgv1_SelectionChanged(object sender, EventArgs e)
        {
            lbBank.Items.Clear();
            using (var db = new laba8_bdContext())
            {
                if (dgv1.CurrentRow.Cells["id_bank"].Value == null)
                {
                    return;
                }
                int id = Int32.Parse(dgv1.CurrentRow.Cells["id_bank"].Value.ToString());
                var bank1 = db.Banks.Find(id);
                lbBank.Items.Add(bank1.ToString());
            }
        }

        private void btbChange_Click(object sender, EventArgs e)
        {
            if (USER == 2)
            {
                MessageBox.Show("Вы не имеете доступа для редактирванния данных таблиц");
                return;
            }
            int id = Int32.Parse(dgv2.CurrentRow.Cells["id"].Value.ToString());
            int newid = Int32.Parse(dgv1.CurrentRow.Cells["id"].Value.ToString());
            using (var db = new laba8_bdContext())
            {
                var user = db.Providers.Find(newid);
                user.IdBank = id;
                db.SaveChanges();
                dgv1.CurrentRow.Cells["id_bank"].Value = id;
            }
        }

        private void btnProv_Click(object sender, EventArgs e)
        {
            dgv1.Rows.Clear();
            using (var db = new laba8_bdContext())
            {
                var users = db.Providers.Where(user=>user.IdBank == null).ToList();
                foreach (var egge in users)
                {
                    int id = dgv1.Rows.Add
                        (egge.Id, egge.NamePr, egge.IdBank, 
                        egge.CodePayment, egge.CountDelays, egge.DataCoop);
                    dgv1.Rows[id].Tag = new List<object>() 
                    { egge.Id, egge.NamePr, egge.IdBank,
                        egge.CodePayment, egge.CountDelays, egge.DataCoop };
                }
            }
        }

        private void btnBank_Click(object sender, EventArgs e)
        {
            dgv2.Rows.Clear();
            using (var db = new laba8_bdContext())
            {
                var query = from b in db.Banks
                            join p in db.Providers on b.Id equals p.IdBank into gj
                            from sub in gj.DefaultIfEmpty()
                            select new {Id = b.Id, NameBank = b.NameBank, 
                               LvlLicenses = b.LvlLicenses, Active = b.Active, provider_id = sub.NamePr };
                var abc = query.Where(pr => pr.provider_id == null);

                foreach (var egge in abc)
                {
                    int id = dgv2.Rows.Add(egge.Id, egge.NameBank, egge.LvlLicenses, egge.Active);
                    dgv2.Rows[id].Tag = new List<object>() { egge.Id, egge.NameBank, egge.LvlLicenses, egge.Active };
                }
            }
        }

        private void btDefault_Click(object sender, EventArgs e)
        {
            dgv1.Rows.Clear();
            dgv2.Rows.Clear();
            show1();
            show2();
        }
    }
}
