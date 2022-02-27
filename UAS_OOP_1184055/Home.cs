using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UAS_OOP_1184055
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void mahasiswaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mahasiswa TampilMahasiswa = new Mahasiswa();
            TampilMahasiswa.MdiParent = this;
            TampilMahasiswa.Show();
        }

        private void prodiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InputProgramStudi TampilProdi = new InputProgramStudi();
            TampilProdi.MdiParent = this;
            TampilProdi.Show();
        }

        private void daftarUlangToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Daftar_Ulang_Mahasiswa TampilDaftarUlang = new Daftar_Ulang_Mahasiswa();
            TampilDaftarUlang.MdiParent = this;
            TampilDaftarUlang.Show();
        }

        private void mahasiswaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ViewMahasiswa LihatMahasiswa = new ViewMahasiswa();
            LihatMahasiswa.MdiParent = this;
            LihatMahasiswa.Show();
        }

        private void prodiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ViewProdi LihatProdi = new ViewProdi();
            LihatProdi.MdiParent = this;
            LihatProdi.Show();
        }

        private void mahasiswaToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            UpdateMahasiswa EditMahasiswa = new UpdateMahasiswa();
            EditMahasiswa.MdiParent = this;
            EditMahasiswa.Show();
        }

        private void prodiToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            UpdateProdi EditProdi = new UpdateProdi();
            EditProdi.MdiParent = this;
            EditProdi.Show();
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }
    }
}
