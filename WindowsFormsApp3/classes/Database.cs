using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3.classes
{
    internal class Database
    {
        public static bool Authorization(TextBox login, TextBox password)
        {
            using (var cn = new MySqlConnection(Properties.Settings.Default.DiplomConnection))
            using (var cm = new MySqlCommand())
            {
                cm.Connection = cn;
                cm.CommandText = @"SELECT *
                                   FROM users  
                                   WHERE login = @p_login AND password = @p_password";

                cm.Parameters.AddWithValue("@p_login", login.Text);
                cm.Parameters.AddWithValue("@p_password", password.Text);

                var da = new MySqlDataAdapter(cm);
                var dt = new DataTable();

                try
                {
                    da.Fill(dt);

                    return dt.Rows.Count == 0;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
    }
}
