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
    public partial class ViewStudent : Form
    {
        public ViewStudent()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Datas will be deleted", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                MySqlConnection conn = new MySqlConnection();
                conn.ConnectionString = "server=localhost;uid=root;pwd=;database=library;port=3307";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "delete from addstudent where stu_id = '" + rowid + "'";

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                MessageBox.Show("Data deleted successfully", "Deleting", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ViewStudent_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;

            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "server=localhost;uid=root;pwd=;database=library;port=3307";
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;

            cmd.CommandText = "select * from addstudent";

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            ViewStudent_dataGridView.DataSource = ds.Tables[0];
        }
        int stu_id;
        int rowid;
        private void ViewStudent_dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ViewStudent_dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                stu_id = int.Parse(ViewStudent_dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            panel2.Visible = true;

            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "server=localhost;uid=root;pwd=;database=library;port=3307";
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;

            cmd.CommandText = "select * from addstudent where stu_id='" + stu_id + "'";

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            rowid = int.Parse(ds.Tables[0].Rows[0][0].ToString());

            stu_name_txt.Text = ds.Tables[0].Rows[0][1].ToString();
            enroll_txt.Text = ds.Tables[0].Rows[0][2].ToString();
            department_txt.Text = ds.Tables[0].Rows[0][3].ToString();
            semester_txt.Text = ds.Tables[0].Rows[0][4].ToString();
            contact_txt.Text = ds.Tables[0].Rows[0][5].ToString();
            email_txt.Text = ds.Tables[0].Rows[0][6].ToString();
        }

        private void stu_search_txt_TextChanged(object sender, EventArgs e)
        {
            if (stu_search_txt.Text != "")
            {
                Image image = Image.FromFile("D:/Library Management System/Liberay Management System/search1.gif");
                pictureBox1.Image = image;

                MySqlConnection conn = new MySqlConnection();
                conn.ConnectionString = "server=localhost;uid=root;pwd=;database=library;port=3307";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from addstudent where stu_name LIKE '" + stu_search_txt.Text + "%'";

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                ViewStudent_dataGridView.DataSource = ds.Tables[0];
            }
            else
            {
                Image image = Image.FromFile("D:/Library Management System/Liberay Management System/search.gif");
                pictureBox1.Image = image;

                MySqlConnection conn = new MySqlConnection();
                conn.ConnectionString = "server=localhost;uid=root;pwd=;database=library;port=3307";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from addstudent";

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                ViewStudent_dataGridView.DataSource = ds.Tables[0];
            }
        }

        private void refresh_btn_Click(object sender, EventArgs e)
        {
            stu_search_txt.Clear();
            panel2.Visible = false;
        }

        private void update_btn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Datas will be change", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                String stu_name = stu_name_txt.Text;
                String enroll_number = enroll_txt.Text;
                String department = department_txt.Text;
                String semester = semester_txt.Text;
                String contact = contact_txt.Text;
                String email = email_txt.Text;

                MySqlConnection conn = new MySqlConnection();
                conn.ConnectionString = "server=localhost;uid=root;pwd=;database=library;port=3307";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "update addstudent set stu_name ='" + stu_name + "', enroll_no ='" + enroll_number + "', department= '" + department + "'" +
                                 ", semester ='" + semester + "', contact ='" + contact + "',email ='" + email + "' where stu_id ='" + rowid + "'";

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                MessageBox.Show("Data updated successfully", "Data success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
