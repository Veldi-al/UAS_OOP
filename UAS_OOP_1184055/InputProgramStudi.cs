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
    public partial class InputProgramStudi : Form
    {
        public InputProgramStudi()
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

        private void clear()
        {
            txtKodeProdi.Text = "";
            txtNamaProdi.Text = "";
            txtSingkatan.Text = "";
            txtBikul.Text = "";

        }

        private void btnSubmit_Click_1(object sender, EventArgs e)
        {
            string myCmd = "INSERT INTO ms_prodi VALUES ('"
                + txtKodeProdi.Text + "','"
                + txtNamaProdi.Text + "','"
                + txtSingkatan.Text + "','"
                + txtBikul.Text + "')";

            UpdateDB(myCmd);


        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void txtBikul_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }

        private void txtKodeProdi_Leave(object sender, EventArgs e)
        {
            if (txtKodeProdi.Text == "")
            {
                epWrong.SetError(txtKodeProdi, "Kode Program Studi Tidak Boleh Kosong!");

            }
            else
            {
                epCorrect.SetError(txtKodeProdi, "Betul");
            }

        }

        private void txtNamaProdi_Leave(object sender, EventArgs e)
        {
            if (txtNamaProdi.Text == "")
            {
                epWrong.SetError(txtNamaProdi, "Nama Program Studi Tidak Boleh Kosong!");

            }
            else
            {
                epCorrect.SetError(txtNamaProdi, "Betul");
            }
        }

        private void txtSingkatan_Leave(object sender, EventArgs e)
        {
            if (txtSingkatan.Text == "")
            {
                epWrong.SetError(txtSingkatan, "Singkatan Tidak Boleh Kosong!");

            }
            else
            {
                epCorrect.SetError(txtSingkatan, "Betul");
            }
        }
    }
}
