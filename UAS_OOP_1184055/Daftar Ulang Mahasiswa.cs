using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace UAS_OOP_1184055
{
    public partial class Daftar_Ulang_Mahasiswa : Form
    {
        public Daftar_Ulang_Mahasiswa()
        {
            InitializeComponent();
        }

        private void UpdateDB(string cmd)
        {
            try
            {
                SqlConnection myConnection = new SqlConnection(@"Data Source=DESKTOP-35S3VGK\VELDISQL; Initial Catalog = UAS; Integrated Security = True");
                myConnection.Open();
                SqlCommand myCommand = new SqlCommand();
                myCommand.Connection = myConnection;
                myCommand.CommandText = cmd;
                myCommand.ExecuteNonQuery();
                MessageBox.Show("Data Berhasil Disubmit !", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string myCmd = "INSERT INTO tr_daftar_ulang VALUES ('"
                + txtNpm.Text + "','"
                + gbGrade.Text + "','"
                + txtTotal.Text + "',')";
            UpdateDB(myCmd);
        }

        private void clear()
        {
            txtNpm.Text = "";
            gbGrade.Text = "";
            txtTotal.Text = "";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void Daftar_Ulang_Mahasiswa_Load(object sender, EventArgs e)
        {

        }
    }
}
