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
    public partial class CompleteBook : Form
    {
        public CompleteBook()
        {
            InitializeComponent();
        }

        private void CompleteBook_Load(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "server=localhost;uid=root;pwd=;database=library;port=3307";
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from irbook where book_return_date is null";

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            MySqlCommand cmd1 = new MySqlCommand();
            cmd1.Connection = conn;
            cmd1.CommandText = "select * from irbook where book_return_date is not null";
            MySqlDataAdapter da1 = new MySqlDataAdapter(cmd1);
            DataSet DS1 = new DataSet();
            da1.Fill(DS1);
            dataGridView2.DataSource = DS1.Tables[0];
        }
    }
}
