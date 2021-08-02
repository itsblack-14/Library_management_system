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
    public partial class AddBooks : Form
    {
        public AddBooks()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {   if (MessageBox.Show("Unsaved data will be deleated '\n'Are u sure want to cancel?", "Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Hide();
            }
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            String bname = bookname_txt.Text;
            String aname = authorname_txt.Text;
            String publication = publication_txt.Text;
            String date = dateTimePicker1.Text;
            int bprice = int.Parse(bookprice_txt.Text);
            int bquantity = int.Parse(quantity_txt.Text);

            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "server=localhost;uid=root;pwd=;database=library;port=3307";
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            conn.Open();
            cmd.CommandText = "insert into addbook(book_name,author_name,publication,purches_date,book_price,book_quantity) " +
                              "values('"+bname+"','"+aname+"','"+publication+"','"+date+"','"+bprice+"','"+bquantity+"')";
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Data saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            bookname_txt.Clear();
            authorname_txt.Clear();
            publication_txt.Clear();
            bookprice_txt.Clear();
            quantity_txt.Clear();
        }
    }
}
