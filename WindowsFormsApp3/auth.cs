using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp3.classes;

namespace WindowsFormsApp3
{
    public partial class auth : Form
    {
        public auth()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void log_Click(object sender, EventArgs e)
        {
            if (Validator.ValidateLogin(login.Text, password.Text))
            {
                if (Database.Authorization(login, password))
                {
                    MainForm formMain = new MainForm();
                    formMain.Show();
                    Hide();
                }
                else
                {
                    MessageBox.Show("Входные данные некорректны. Пожалуйста, проверьте правильность введенного логина и пароля и повторите попытку.", "Ошибка авторизации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
