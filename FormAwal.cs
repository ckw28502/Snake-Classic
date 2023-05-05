using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tugas_Proyek
{
    public partial class FormAwal : Form
    {
        public FormAwal()
        {
            InitializeComponent();
        }

        public FormAwal formawal;
        public List<string> listusername = new List<string>();
        public List<string> listpassword = new List<string>();

        private void FormAwal_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtboxusername.Text == "" && txtboxpassword.Text == "")
            {
                MessageBox.Show("Username Dan Password Harus Diisi!");
            }
            else if (txtboxusername.Text == "" || txtboxpassword.Text == "")
            {
                MessageBox.Show("Kolom Username Atau Password Tidak boleh kosong!");
            }
            else if (txtboxusername.Text != "" && txtboxpassword.Text != "")
            {
                for (int i = 0; i < listusername.Count; i++)
                {
                    if (txtboxusername.Text != listusername[i])
                    {
                        MessageBox.Show("Username Yang anda masukkan Belum Terdaftar!");
                    }
                    else if (txtboxpassword.Text != listpassword[i])
                    {
                        MessageBox.Show("Password Yang anda masukkan salah/Belum Terdaftar!");
                    }
                    else if (txtboxusername.Text == listusername[i] && txtboxpassword.Text == listpassword[i])
                    {
                        MessageBox.Show("Silahkan Bermain ! " + listusername[i]);
                        FormGame game = new FormGame();
                        game.Show();
                        this.Hide();
                    }
                }
            }
        }

        private void btnregister_Click(object sender, EventArgs e)
        {
            FormRegister regis = new FormRegister();
            regis.formawal = this;
            regis.Show();
            this.Hide();
        }
    }
}
