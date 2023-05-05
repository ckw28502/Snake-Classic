using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Xml;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
namespace Tugas_Proyek
{
    public partial class FormRegister : Form
    {
        public FormRegister()
        {
            InitializeComponent();
        }

        public FormAwal formawal;
        FormRegister registrasi;
        string username;
        string password;

        private void FormRegister_Load(object sender, EventArgs e)
        {
            registrasi = new FormRegister();
            
        }

        private void btnregis_Click(object sender, EventArgs e)
        {
            if (txtboxuser.Text == "" || txtboxpass.Text == "")
            {
                MessageBox.Show("Tidak Boleh ada yang Kosong!");
            }
            else if (txtboxuser.Text != "" && txtboxpass.Text != "")
            {
                MessageBox.Show("Register Berhasil");
                username = txtboxuser.Text;
                password = txtboxpass.Text;
                formawal.listusername.Add(username);
                formawal.listpassword.Add(password);

                this.Hide();
                formawal.Show();

                XmlWriterSettings set = new XmlWriterSettings();
                set.Indent = true;

                XmlWriter akhir = XmlWriter.Create("HasilRegistrasi.xml", set);
                akhir.WriteStartDocument();

                akhir.WriteStartElement("Data");
                for (int i = 0; i < formawal.listusername.Count; i++)
                {
                    akhir.WriteStartElement("Pengguna");
                    akhir.WriteElementString("Username", formawal.listusername[i]);
                    akhir.WriteElementString("Password", formawal.listpassword[i]);
                    akhir.WriteEndElement();
                }
                akhir.WriteEndElement();

                akhir.WriteEndDocument();
                akhir.Close();
            }
        }

        
    }
}
