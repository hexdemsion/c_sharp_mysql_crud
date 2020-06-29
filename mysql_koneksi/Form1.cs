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

namespace mysql_koneksi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public MySqlConnection buat_koneksi()
        {
            MySqlBaseConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "localhost";
            builder.UserID = "root";
            builder.Password = "";
            builder.Database = "database_latihan_visual";

            String connString = builder.ToString();
            builder = null;
            MySqlConnection dbConn = new MySqlConnection(connString);
            return dbConn;
        }

        private void ambil_data(object sender, EventArgs e)
        {
            DataTable tabelmhs = new DataTable();
            MySqlConnection koneksi = buat_koneksi();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM mahasiswa", koneksi);

            try
            {
                koneksi.Open();
            }
            catch (Exception)
            {
                MessageBox.Show("Gagal membuka koneksi MySQL");
            }

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            adapter.Fill(tabelmhs);
            koneksi.Close();
            dataGridView1.DataSource = tabelmhs;
        }

    }
}
