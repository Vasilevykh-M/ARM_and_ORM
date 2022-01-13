using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace АРМ
{
    public partial class deliveriesForm : Form
    {
        public int USER;
        public deliveriesForm(int user)
        {
            InitializeComponent();

            this.USER = user;

            initialaze_dgv();
            show();


        }
        Dictionary<int, int> dicProduct = new Dictionary<int, int>();
        Dictionary<int, int> dicProvider = new Dictionary<int, int>();

        void initialaze_dgv()
        {
            DataGridViewComboBoxColumn providerCB = new DataGridViewComboBoxColumn();
            DataGridViewComboBoxColumn productCB = new DataGridViewComboBoxColumn();

            using (var db = new laba8_bdContext())
            {
                var product = db.Products.ToList();
                int id = 0;
                foreach (var egge in product)
                {
                    id = productCB.Items.Add(egge.NamePr);
                    dicProduct.Add(egge.Id, id);
                }

                var provider = db.Providers.ToList();

                foreach (var egge in provider)
                {
                    id = providerCB.Items.Add(egge.NamePr);
                    dicProvider.Add(egge.Id, id);
                }

            }

            productCB.DataPropertyName = "product";
            productCB.HeaderText = "Продукты";


            providerCB.DataPropertyName = "provider";
            providerCB.HeaderText = "Поставщики";

            dgv1.Columns.Add(providerCB);
            dgv1.Columns.Add(productCB);

        }

        void show()
        {
            using (var db = new laba8_bdContext())
            {
                var delays  = db.Delays.ToList();
                int prod, prov;
                foreach (var egge in delays)
                {
                    prod = dicProduct[(int)egge.IdProduct];
                    prov = dicProvider[(int)egge.IdProvider];
                    int id = dgv1.Rows.Add((dgv1.Columns[0] as DataGridViewComboBoxColumn).Items[prov],
                        (dgv1.Columns[1] as DataGridViewComboBoxColumn).Items[prod]);

                    dgv1.Rows[id].Tag = new List<int>() { prov, prod };

                }
            }
        }

        private void deliveriesForm_Load(object sender, EventArgs e)
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

            if (row.Cells[0].Value == null && row.Cells[1].Value == null)
            {
                row.ErrorText = $"Значение в стлобце не должно быть пустым";
                return;
            }

            using (var db = new laba8_bdContext())
            {

                List<int> prov_prod = (List<int>)row.Tag;

                int provider_id1 = (row.Cells[0] as DataGridViewComboBoxCell).Items.IndexOf(row.Cells[0].Value);

                int product_id1 = (row.Cells[1] as DataGridViewComboBoxCell).Items.IndexOf(row.Cells[1].Value);

                var key_provider1 = dicProvider.FirstOrDefault(x => x.Value == provider_id1).Key;
                var key_product1 = dicProduct.FirstOrDefault(x => x.Value == product_id1).Key;

                if (prov_prod != null) {

                    var delays = db.Delays.Find(dicProvider.FirstOrDefault(x => x.Value == prov_prod[0]).Key,
                        dicProduct.FirstOrDefault(x => x.Value == prov_prod[1]).Key);

                    if (delays != null)
                    {
                        db.Delays.Remove(delays);
                        Delay delay1 = new Delay() { IdProduct = key_product1, IdProvider = key_provider1 };
                        db.Delays.Add(delay1);
                        db.SaveChanges();
                        prov_prod = new List<int> { dicProvider[key_provider1], dicProduct[key_product1] };
                        row.Tag = prov_prod;
                        return;
                    }
                }
                prov_prod = new List<int> { dicProvider[key_provider1], dicProduct[key_product1] };

                row.Tag = prov_prod;

                Delay delay = new Delay() { IdProduct = key_product1, IdProvider = key_provider1 };

                db.Delays.Add(delay);
                db.SaveChanges();

                //DataGridViewComboBoxCell provider_cell = (DataGridViewComboBoxCell)row.Cells[0];
                //int provider_id = provider_cell.Items.IndexOf(row.Cells[0].Value);

                //DataGridViewComboBoxCell product_cell = (DataGridViewComboBoxCell)row.Cells[1];
                //int product_id = product_cell.Items.IndexOf(row.Cells[1].Value);

                //int id  = dgv1.Rows.Add(provider_cell, product_cell);

                //var key_provider = dicProvider.FirstOrDefault(x => x.Value == provider_id).Key;
                //var key_product = dicProduct.FirstOrDefault(x => x.Value == product_id).Key;

                //Delay a = new Delay() { IdProduct = key_product, IdProvider = key_provider };
                //dgv1.Rows[id].Tag = new List<int> { key_provider, key_product };

                //db.Delays.Add(a);
                //db.SaveChanges();
            }
        }

        private void dgv1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var row = e.Row;
            row.ErrorText = "";
            if (USER == 2)
            {
                row.ErrorText = "Нет доступа к редактированию данной таблицы";
                return;
            }

            if (row.Cells[0].Value == null && row.Cells[1].Value == null)
            {
                return;
            }

            using (var db = new laba8_bdContext())
            {
                List<int> prov_prod = (List<int>)row.Tag;

                //var obj = db.Delays.Where(user => user.IdProduct == prov_prod[1] && user.IdProvider == prov_prod[0]);
                int a1 = dicProduct.FirstOrDefault(x => x.Value == prov_prod[1]).Key;
                int a2 = dicProvider.FirstOrDefault(x => x.Value == prov_prod[0]).Key;
                var obj = db.Delays.Where(user => user.IdProduct == a1 && user.IdProvider == a2).ToArray()[0];
                db.Delays.Remove(obj);
                db.SaveChanges();
            }
        }
    }
}
