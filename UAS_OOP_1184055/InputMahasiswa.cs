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
    public partial class Mahasiswa : Form
    {
        string prodi;
        public Mahasiswa()
        {
            InitializeComponent();

            SqlConnection myConnection = new SqlConnection(@"Data Source=DESKTOP-35S3VGK\VELDISQL; Initial Catalog = UAS; Integrated Security = True");

            myConnection.Open();

            SqlCommand myCommand = new SqlCommand("SELECT * FROM ms_prodi", myConnection);
            SqlDataReader reader;

            reader = myCommand.ExecuteReader();
            DataTable myDataTable = new DataTable();
            myDataTable.Columns.Add("kode_prodi", typeof(string));
            myDataTable.Columns.Add("singkatan", typeof(string));
            myDataTable.Load(reader);

            cbProdi.ValueMember = "kode_prodi";
            cbProdi.DisplayMember = "singkatan";
            cbProdi.DataSource = myDataTable;

            myConnection.Close();
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
            txtNpm.Text = "";
            txtNamaMhs.Text = "";
            cbProdi.Text = "";

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtNpm.Text != "")
            {
                if (txtNamaMhs.Text != "")
                {
                    if (cbProdi.Text != "--Pilih Program Studi--")
                    {
                        string npm = txtNpm.Text;
                        string nama = txtNamaMhs.Text;
                        string prodi = this.prodi;

                        SqlConnection myConnection = new SqlConnection(@"Data Source=DESKTOP-35S3VGK\VELDISQL; Initial Catalog = UAS; Integrated Security = True");
                        string sql = "INSERT INTO ms_mhs ([npm],[nama_mhs]," + "[kode_prodi]) VALUES (@npm,@namaMhs,@kodeProdi)";

                        using (SqlConnection Connection = new SqlConnection(@"Data Source = DESKTOP-35S3VGK\VELDISQL; Initial Catalog = UAS; Integrated Security=True"))
                        {
                            try
                            {
                                Connection.Open();

                                using (SqlCommand command = new SqlCommand(sql, Connection))
                                {
                                    command.Parameters.Add("@npm", SqlDbType.VarChar).Value = npm;
                                    command.Parameters.Add("@namaMhs", SqlDbType.VarChar).Value = nama;
                                    command.Parameters.Add("@kodeProdi", SqlDbType.VarChar).Value = prodi;

                                    int rowsAdded = command.ExecuteNonQuery();
                                    if (rowsAdded > 0)
                                        MessageBox.Show("Data berhasil di simpan");
                                    else
                                        MessageBox.Show("Data tidak tersimpan");

                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("ERROR:" + ex.Message);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Pilih Program Studi !", "Infromasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                else
                {
                    MessageBox.Show("Nama harus diisi !", "Infromasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            clear();
        }

        private void txtNpm_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }

        private void txtNamaMhs_Leave(object sender, EventArgs e)
        {
            if (txtNamaMhs.Text == "")
            {
                epWrong.SetError(txtNamaMhs, "Nama Mahasiswa Tidak Boleh Kosong!");
            }
            else if ((txtNamaMhs.Text).Any(Char.IsLetter))
            {

                epCorrect.SetError(txtNamaMhs, "Betul!");
            }
            else
            {
                epWrong.SetError(txtNamaMhs, "Inputan hanya boleh huruf !");

            }
        }

        private void cbProdi_Leave(object sender, EventArgs e)
        {
            if (cbProdi.Text == "")
            {
                epWrong.SetError(cbProdi, "Prodi Tidak Boleh Kosong!");
            }
            else
            {
                epCorrect.SetError(cbProdi, "Betul!");

            }
        }

        private void cbProdi_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.prodi = cbProdi.SelectedValue.ToString();
        }
    }
}
