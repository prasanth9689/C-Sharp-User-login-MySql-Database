using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;

namespace User_login
{
    public partial class Form1 : Form
    {
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader dr;

        public Form1()
        {
            InitializeComponent();
            con = new MySqlConnection("Server=127.0.0.1;Database=skyblue;User=root;Password=;");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                MessageBox.Show("Enter username!");
                return;
            }

            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Enter password!");
                return;
            }

            login();
        }

        private void login()
        {
            string user = txtUserName.Text;
            string pass = txtPassword.Text;

            //    string connectionString = "Server=127.0.0.1;Database=skyblue;User=root;Password=;";
            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM user WHERE username ='" + user + "' AND password ='" + pass + "'";
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("Login sucess Welcome to Homepage");
            }
            else
            {
                MessageBox.Show("Invalid Login please check username and password");
            }
            con.Close();
        }
    }
}
