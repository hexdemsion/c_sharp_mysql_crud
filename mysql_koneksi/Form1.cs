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
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM mahasiswa", koneksi);
                koneksi.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                adapter.Fill(tabelmhs);
                koneksi.Close();
                dataGridView1.DataSource = tabelmhs;
            }
            catch (Exception)
            {
                MessageBox.Show("Error mengambil data");
            }
        }

        private void insert_data(object sender, EventArgs e)
        {
            String nama = textBox1.Text;
            String alamat = textBox2.Text;
            String stb = textBox3.Text;
            int nilai_tugas = int.Parse(textBox4.Text);
            int nilai_mid = int.Parse(textBox5.Text);
            int nilai_final = int.Parse(textBox6.Text);
            int nilai_akhir = int.Parse(textBox7.Text);
            String nilai_huruf = textBox8.Text;
            String keterangan = textBox9.Text;

            try
            {
                String query_input = 
                    "INSERT INTO mahasiswa (nama,alamat,stb,nilai_tugas,nilai_mid,nilai_final,nilai_akhir,nilai_huruf,keterangan) " +
                    "VALUES ('" + nama + "', '" + alamat + "', '" + stb + "', '" + nilai_tugas + "', '" + nilai_mid + "', '" + nilai_final +
                    "', '" + nilai_akhir + "', '" + nilai_huruf + "', '" + keterangan + "') ";
                MySqlConnection koneksi = buat_koneksi();
                MySqlCommand cmd = new MySqlCommand(query_input, koneksi);
                koneksi.Open();
                cmd.ExecuteNonQuery();
                koneksi.Close();
                MessageBox.Show("Data berhasil di-input");
            }
            catch (Exception)
            {
                MessageBox.Show("Data gagal di-input");
            }
        }
    }
}
