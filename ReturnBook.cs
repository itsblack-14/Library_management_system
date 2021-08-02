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
    public partial class ReturnBook : Form
    {
        public ReturnBook()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void search_stu_btn_Click(object sender, EventArgs e)
        {
            String enroll = enroll_search_txt.Text;
                MySqlConnection conn = new MySqlConnection();
                conn.ConnectionString = "server=localhost;uid=root;pwd=;database=library;port=3307";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from irbook where stu_enroll ='" + enroll + "' and book_return_date is null";

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

            if(ds.Tables[0].Rows.Count != 0)
            {
               dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                MessageBox.Show("Invalid Enroll Or Student No Book Issued", "Student Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReturnBook_Load(object sender, EventArgs e)
        {
            return_panel.Visible = false;
            enroll_search_txt.Clear();
        }
        String book_name, issue_date;
        int rowid;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            return_panel.Visible = true;

            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                book_name = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                issue_date = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                rowid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            book_name_txt.Text = book_name;
            issue_date_txt.Text = issue_date;
        }

        private void enroll_search_txt_TextChanged(object sender, EventArgs e)
        {
            return_panel.Visible = false;
            dataGridView1.DataSource = null;
        }

        private void refresh_btn_Click(object sender, EventArgs e)
        {
            enroll_search_txt.Text = "";
        }

        private void exit_btn_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Do You Really Want To Exit?","Exit",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void Cancel_btn_Click(object sender, EventArgs e)
        {
            return_panel.Visible = false;
        }

        private void Return_btn_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "server=localhost;uid=root;pwd=;database=library;port=3307";
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            conn.Open();

            cmd.CommandText = "update irbook set book_return_date ='" + dateTimePicker1.Text + "' where stu_enroll ='" + enroll_search_txt.Text + "' and id ='" + rowid + "'";
            cmd.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Book Returned Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ReturnBook_Load(this, null);
        }
    }
}
