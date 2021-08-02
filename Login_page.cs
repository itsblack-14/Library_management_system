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
    public partial class Login_form : Form
    {
        public Login_form()
        {
            InitializeComponent();
        }

        private void Login_form_Load(object sender, EventArgs e)
        {

        }

        private void password_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Signup su = new Signup();
            su.Show();
        }

        private void username_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void exit_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void username_txt_MouseClick(object sender, MouseEventArgs e)
        {
            if (username_txt.Text == "Username")
            {
                username_txt.Clear();
            }
        }

        private void password_txt_MouseClick(object sender, MouseEventArgs e)
        {
            if (password_txt.Text == "Password")
            {
                password_txt.Clear();
                password_txt.PasswordChar = '*';
            }
        }

        private void ig_picbox_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://instagram.com/itsblack_14?igshid=t6cs5wxsisg2");
        }

        private void fb_picbox_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/zk56115");
        }

        private void tw_picbox_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://twitter.com/itsblack_14?s=09");
        }

        private void Login_btn_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "server=localhost;uid=root;pwd=;database=library;port=3307";
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;

            cmd.CommandText = "select * from logintable where username='" + username_txt.Text + "' and pass='" + password_txt.Text + "'";
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            

            if (ds.Tables[0].Rows.Count != 0)
            {
                this.Hide();
                Dashboard db = new Dashboard();
                db.Show();
                
            }
            else
            {
                MessageBox.Show("Invalid username or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
