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
    public partial class IssueBook : Form
    {
        public IssueBook()
        {
            InitializeComponent();
        }

        private void IssueBook_Load(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "server=localhost;uid=root;pwd=;database=library;port=3307";
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select book_name from addbook";
            conn.Open();

            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                for(int i=0; i < dr.FieldCount; i++)
                {
                    book_name_box.Items.Add(dr.GetString(i));
                }
            }
            dr.Close();
            conn.Close();
        }

        int count;

        private void search_stu_btn_Click(object sender, EventArgs e)
        {
            String enroll_no = Enroll_search_txt.Text;
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "server=localhost;uid=root;pwd=;database=library;port=3307";
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from addstudent where enroll_no ='" + enroll_no + "'";

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);


            //-------------------------------Code to count issued book----------------------------------------------

            cmd.CommandText = "select count(stu_enroll) from irbook where stu_enroll = '" + enroll_no + "' and book_return_date is null";
            MySqlDataAdapter da1 = new MySqlDataAdapter(cmd);
            da1.Fill(ds);

            count = int.Parse(ds.Tables[0].Rows[0][0].ToString());
            //------------------------------------------------------------------------------------------------------

            if(ds.Tables[0].Rows.Count != 0)
            {
                stu_name_txt.Text = ds.Tables[0].Rows[0][1].ToString();
                department_txt.Text = ds.Tables[0].Rows[0][3].ToString();
                semester_txt.Text = ds.Tables[0].Rows[0][4].ToString();
                contact_txt.Text = ds.Tables[0].Rows[0][5].ToString();
                email_txt.Text = ds.Tables[0].Rows[0][6].ToString();
            }
            else
            {
                stu_name_txt.Clear();
                department_txt.Clear();
                semester_txt.Clear();
                contact_txt.Clear();
                email_txt.Clear();
                MessageBox.Show("Invalid enroll number", "Wrong enroll", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Issue_book_btn_Click(object sender, EventArgs e)
        {
            if(stu_name_txt.Text != "")
            {
                if(book_name_box.SelectedIndex !=-1 && count <= 2)
                {
                    String enroll_no = Enroll_search_txt.Text;
                    String stu_name = stu_name_txt.Text;
                    String stu_department = department_txt.Text;
                    String stu_semester = semester_txt.Text;
                    String stu_contact = contact_txt.Text;
                    String stu_email = email_txt.Text;
                    String book_name = book_name_box.Text;
                    String book_issue_date = dateTimePicker1.Text;

                    MySqlConnection conn = new MySqlConnection();
                    conn.ConnectionString = "server=localhost;uid=root;pwd=;database=library;port=3307";
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.CommandText = "insert into irbook(stu_enroll,stu_name,stu_department,stu_semester,stu_contact,stu_email,book_name,book_issue_date) " +
                                      "values ('" + enroll_no + "','" + stu_name + "','" + stu_department + "','" + stu_semester + "','" + stu_contact + "','" + stu_email + "','" + book_name + "','" + book_issue_date + "')";

                    cmd.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("Book Issued", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Select A Book. OR Maximum Number Of Book Has Been Issued", "Select A Book", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Enter Valid Enroll Number", "Student not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Enroll_search_txt_TextChanged(object sender, EventArgs e)
        {
            if(Enroll_search_txt.Text == "")
            {
                stu_name_txt.Clear();
                department_txt.Clear();
                semester_txt.Clear();
                contact_txt.Clear();
                email_txt.Clear();
            }
        }

        private void refresh_btn_Click(object sender, EventArgs e)
        {
            Enroll_search_txt.Text = "";
        }

        private void exit_btn_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Do You Really Want To Exit?","Exit",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
