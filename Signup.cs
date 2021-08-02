using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Libarary_management_win_app
{
    public partial class Signup : Form
    {
        String a;
        public Signup()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Unsaved data wil be lost '\n' Are you sure u want to exit?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Hide();
                Login_form lf = new Login_form();
                lf.Show();
            }
        }
        string password;

        private void btn_sign_Click(object sender, EventArgs e)
        {
            
            if (txt_password.Text == txt_confirm.Text)
            {
                password = txt_password.Text;
            }
            else
            {
                MessageBox.Show("Make sure your password is correct", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

             MySqlConnection conn = new MySqlConnection();
             conn.ConnectionString = ("server=localhost;uid=root;pwd=;database=library;port=3307");
             MySqlCommand cmd = new MySqlCommand();
             cmd.Connection = conn;
             conn.Open();
             cmd.CommandText = "insert into logintable(username,pass) value ('" + txt_username.Text + "','" + password + "')";

            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Account created", "Data saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    

    }
}
