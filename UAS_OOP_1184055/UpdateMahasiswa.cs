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
    public partial class UpdateMahasiswa : Form
    {
        public UpdateMahasiswa()
        {
            InitializeComponent();
        }

        private DataSet ds_Mhs;

        public DataSet CreateMhsDataSet()
        {
            DataSet myDataSet = new DataSet();

            try
            {

                SqlConnection myConnection = new SqlConnection(@"Data Source=DESKTOP-35S3VGK\VELDISQL; Initial Catalog = UAS; Integrated Security = True");


                SqlCommand myCommand = new SqlCommand();


                myCommand.Connection = myConnection;


                myCommand.CommandText = "SELECT * FROM ms_mhs";
                myCommand.CommandType = CommandType.Text;


                SqlDataAdapter myDataAdapter = new SqlDataAdapter();
                myDataAdapter.SelectCommand = myCommand;
                myDataAdapter.TableMappings.Add("Table", "Mahasiswa");


                myDataAdapter.Fill(myDataSet);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return myDataSet;
        }

        private void RefreshDataSet()
        {

            ds_Mhs = CreateMhsDataSet();

            dgMhs.DataSource = ds_Mhs.Tables["Mahasiswa"];
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshDataSet();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            {
                SqlConnection myConnection = new SqlConnection(@"Data Source=DESKTOP-35S3VGK\VELDISQL; Initial Catalog = UAS; Integrated Security = True");
                myConnection.Open();
                SqlDataAdapter myAdapter = new SqlDataAdapter("select * from ms_mhs", myConnection);
                SqlCommandBuilder myCmdBuilder = new SqlCommandBuilder(myAdapter);
                myAdapter.InsertCommand = myCmdBuilder.GetInsertCommand();
                myAdapter.UpdateCommand = myCmdBuilder.GetUpdateCommand();
                myAdapter.DeleteCommand = myCmdBuilder.GetDeleteCommand();

                SqlTransaction myTransaction;
                myTransaction = myConnection.BeginTransaction();
                myAdapter.DeleteCommand.Transaction = myTransaction;
                myAdapter.UpdateCommand.Transaction = myTransaction;
                myAdapter.InsertCommand.Transaction = myTransaction;

                try
                {
                    int rowsUpdated = myAdapter.Update(ds_Mhs, "Mahasiswa");

                    myTransaction.Commit();

                    MessageBox.Show(rowsUpdated.ToString() + "Baris diperbarui", "Informasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    RefreshDataSet();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to update: " + ex.Message);
                    myTransaction.Rollback();
                }

                MessageBox.Show(myAdapter.InsertCommand.CommandText);
                MessageBox.Show(myAdapter.UpdateCommand.CommandText);
            }
        }


    }
}
