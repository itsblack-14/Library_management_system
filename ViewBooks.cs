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
    public partial class ViewBooks : Form
    {
        public ViewBooks()
        {
            InitializeComponent();
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
                panel2.Visible = false;
        }

        private void ViewBooks_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;

            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "server=localhost;uid=root;pwd=;database=library;port=3307";
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            
            cmd.CommandText = "select * from addbook";

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            viebook_dataGridView.DataSource = ds.Tables[0];
        }
        int book_id;
        int rowid;
        private void viebook_dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(viebook_dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                book_id = int.Parse(viebook_dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            panel2.Visible = true;

            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "server=localhost;uid=root;pwd=;database=library;port=3307";
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;

            cmd.CommandText = "select * from addbook where book_id='"+book_id+"'";

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            rowid = int.Parse(ds.Tables[0].Rows[0][0].ToString());

            bookname_txt.Text = ds.Tables[0].Rows[0][1].ToString();
            authorname_txt.Text = ds.Tables[0].Rows[0][2].ToString();
            publication_txt.Text = ds.Tables[0].Rows[0][3].ToString();
            date_txt.Text = ds.Tables[0].Rows[0][4].ToString();
            price_txt.Text = ds.Tables[0].Rows[0][5].ToString();
            quantity_txt.Text = ds.Tables[0].Rows[0][6].ToString();
        }

        private void book_search_txt_TextChanged(object sender, EventArgs e)
        {
            if(book_search_txt.Text != "")
            {
                MySqlConnection conn = new MySqlConnection();
                conn.ConnectionString = "server=localhost;uid=root;pwd=;database=library;port=3307";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;

                cmd.CommandText = "select * from addbook where book_name LIKE '"+book_search_txt.Text+"%'";

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                viebook_dataGridView.DataSource = ds.Tables[0];
            }
            else
            {
                MySqlConnection conn = new MySqlConnection();
                conn.ConnectionString = "server=localhost;uid=root;pwd=;database=library;port=3307";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;

                cmd.CommandText = "select * from addbook";

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                viebook_dataGridView.DataSource = ds.Tables[0];
            }
        }

        private void book_btn_Click(object sender, EventArgs e)
        {
            book_search_txt.Clear();
            panel2.Visible = false;
        }

        private void update_btn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are u sure u want to change datas?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                String book_name = bookname_txt.Text;
                String author_name = authorname_txt.Text;
                String publication = publication_txt.Text;
                String purches_date = date_txt.Text;
                float book_price = float.Parse(price_txt.Text);
                int book_quantity = int.Parse(quantity_txt.Text);

                MySqlConnection conn = new MySqlConnection();
                conn.ConnectionString = "server=localhost;uid=root;pwd=;database=library;port=3307";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;

                cmd.CommandText = "update addbook set book_name = '" + book_name + "', author_name = '" + author_name + "', publication = '" + publication + "'," +
                                  "purches_date = '" + purches_date + "',book_price = '" + book_price + "',book_quantity = '" + book_quantity + "' where book_id = '" + rowid + "'";

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                MessageBox.Show("Data updated successfully", "Data succed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are u sure u want to delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                MySqlConnection conn = new MySqlConnection();
                conn.ConnectionString = "server=localhost;uid=root;pwd=;database=library;port=3307";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;

                cmd.CommandText = "delete from addbook where book_id = '"+rowid+"'";

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                MessageBox.Show("Data deleted successfully", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
