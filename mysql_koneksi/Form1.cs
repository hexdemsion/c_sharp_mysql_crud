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
            builder.UserID = "ro324324ot";
            builder.Password = "";
            builder.Database = "pt_bukit_makmur";

            String connString = builder.ToString();
            builder = null;
            MySqlConnection dbConn = new MySqlConnection(connString);
            return dbConn;
        }

        private void cek_koneksi(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection koneksi = buat_koneksi();
                koneksi.Open();
                MessageBox.Show("koneksi MySQL berhasil");
            }
            catch (Exception)
            {
                MessageBox.Show("koneksi MySQL gagal");
            }
        }

        private void ambil_data(object sender, EventArgs e)
        {
            MySqlConnection koneksi = buat_koneksi();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM karyawan", koneksi);
            try
            {
                koneksi.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int id = (int)reader["id"];
                    String nama = reader["nama"].ToString();
                    String alamat = reader["alamat"].ToString();
                    String info_karyawan = nama + " | " + alamat;

                    MessageBox.Show(info_karyawan);
                }
                koneksi.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("koneksi MySQL gagal");
            }
        }
    }
}
