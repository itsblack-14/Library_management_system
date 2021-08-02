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
    public partial class AddStudent : Form
    {
        public AddStudent()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void exit_btn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Unsaved datas will be lost '\n'Are u sure want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Hide();
            }
        }

        private void refresh_btn_Click(object sender, EventArgs e)
        {
            stu_name_txt.Clear();
            enrollno_txt.Clear();
            department_txt.Clear();
            semester_txt.Clear();
            contact_txt.Clear();
            email_txt.Clear();
        }

        private void save_info_btn_Click(object sender, EventArgs e)

        {
            if (stu_name_txt.Text != "" && enrollno_txt.Text != "" && department_txt.Text != "" && semester_txt.Text != "" && contact_txt.Text != "" && email_txt.Text != "")
            {

                String name = stu_name_txt.Text;
                String enroll = enrollno_txt.Text;
                String department = department_txt.Text;
                String semester = semester_txt.Text;
                String contact = contact_txt.Text;
                String email = email_txt.Text;

                MySqlConnection conn = new MySqlConnection();
                conn.ConnectionString = "server=localhost;uid=root;pwd=;database=library;port=3307";
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                conn.Open();
                cmd.CommandText = "insert into addstudent(stu_name,enroll_no,department,semester,contact,email) values ('" + name + "','" + enroll + "','" + department + "','" + semester + "','" + contact + "','" + email + "')";
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Data saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("You need to fill every field above", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }  


    }
}
