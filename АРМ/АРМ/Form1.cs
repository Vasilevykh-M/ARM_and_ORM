using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;

namespace АРМ
{
    public partial class autentForm : Form
    {
        public autentForm()
        {
            InitializeComponent();
            btnStart.Enabled = false;
            userBD.Enabled = false;
            productBd.Enabled = false;
            providerBd.Enabled = false;
            DelaysBd.Enabled = false;
        }

        public int user;

        

        private void autentForm_Load(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e) // 0 админ 1 юзер 2 гость
        {
            int index = cbState.SelectedIndex;

            if(index == 1) // гость
            {
                user = 2;
                userBD.Enabled = false;
                productBd.Enabled = true;
                providerBd.Enabled = true;
                DelaysBd.Enabled = true;
                return;
            }
            using (var db = new laba8_bdContext())
            {
                if (index == 0) // аутентификация
                {
                    var passowrd = db.Users.Where(user => user.Login == tbLogin.Text).Select(user => user.Password);
                    if (passowrd == null)
                    {
                        lblState.Text = "Пользователя с таким логином не существует";
                        return;
                    }


                    if (!BCrypt.Net.BCrypt.Verify(tbPassword.Text, passowrd.ToArray()[0].ToString()))
                    {
                        lblState.Text = "Пароль не верный";
                        return;
                    }
                    lblState.Text = "Добро пожаловать " + tbLogin.Text;
                    user = db.Users.Where(user => user.Login == tbLogin.Text).Select(user => user.Lvl).ToArray()[0];

                    productBd.Enabled = true;
                    providerBd.Enabled = true;
                    DelaysBd.Enabled = true;

                    if (user != 0)
                        userBD.Enabled = false;
                    else
                        userBD.Enabled = true;
                }
                else // регистрация(только user) админоа может назначить только другой админ изнутри БД
                {
                    var passowrd = db.Users.Where(user => user.Login == tbLogin.Text);
                    if(passowrd.Count() > 0)
                    {
                        lblState.Text = "Пользователя с таким логином уже существует";
                        return;
                    }
                    if(tbPassword.Text=="")
                    {
                        lblState.Text = "Ведите пароль";
                        return;
                    }
                    var password = BCrypt.Net.BCrypt.HashPassword(tbPassword.Text);

                    db.Users.Add(new User() { Login = tbLogin.Text, Password = password, Lvl = 1 });
                    db.SaveChanges();
                    lblState.Text = $"Пользователь {tbLogin.Text} создан";
                }
            }
            if (user == 0)
                userBD.Enabled = true;
            else
                userBD.Enabled = false;
        }

        private void cbState_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnStart.Enabled = true;

        }

        private void userBD_Click(object sender, EventArgs e)
        {
            UserForm userForm = new UserForm();
            userForm.Show();
        }

        private void providerBd_Click(object sender, EventArgs e)
        {
            providerForm ProviderForm = new providerForm(user);
            ProviderForm.Show();
        }

        private void productBd_Click(object sender, EventArgs e)
        {
            productForm productForm = new productForm(user);
            productForm.Show();
        }

        private void DelaysBd_Click(object sender, EventArgs e)
        {
            deliveriesForm DeliveriesForm = new deliveriesForm(user);
            DeliveriesForm.Show();
        }
    }
}
