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

namespace Tugas_Proyek
{
    public partial class Formisi : Form
    {
        public Formisi()
        {
            InitializeComponent();
        }
        String connStr; 
        SqlConnection conn;
        
        
        private void Formisi_Load(object sender, EventArgs e)
        {
            connStr = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =" + Application.StartupPath + "\\snake.mdf; Integrated Security = True; Connect Timeout = 30";
            try
            {
                conn = new SqlConnection(connStr);
                conn.Open();
                conn.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
                conn.Close();
            }
        }
        private void btnmulaigame_Click(object sender, EventArgs e)
        {
            if (rdbmudah.Checked == true)
            {
                FormPermainan main = new FormPermainan();
                main.Show();
                this.Hide();
                FormPermainan.nama = textBox1.Text;
            }
            if (rdbsedang.Checked == true)
            {
                FormPermainanSedang sedang = new FormPermainanSedang();
                sedang.Show();
                this.Hide();
                FormPermainanSedang.nama2 = textBox1.Text;
            }
            if (rdbsulit.Checked == true)
            {
                FormPermainanSulit sulit = new FormPermainanSulit();
                sulit.Show();
                this.Hide();
                FormPermainanSulit.nama3 = textBox1.Text;
            }
        }

        private void Formisi_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int d = 10;
            // mulai game
            g.FillEllipse(Brushes.LightGray, btnmulaigame.Location.X - d / 2, btnmulaigame.Location.Y, d, d);
            g.FillEllipse(Brushes.LightGray, btnmulaigame.Location.X - d / 2, btnmulaigame.Location.Y + btnmulaigame.Height - d, d, d);
            g.FillRectangle(Brushes.LightGray, btnmulaigame.Location.X - d / 2, btnmulaigame.Location.Y + d / 2, d / 2, btnmulaigame.Height - d);
            g.FillEllipse(Brushes.LightGray, btnmulaigame.Location.X + btnmulaigame.Width - d / 2, btnmulaigame.Location.Y, d, d);
            g.FillEllipse(Brushes.LightGray, btnmulaigame.Location.X + btnmulaigame.Width - d / 2, btnmulaigame.Location.Y + btnmulaigame.Height - d, d, d);
            g.FillRectangle(Brushes.LightGray, btnmulaigame.Location.X + btnmulaigame.Width, btnmulaigame.Location.Y + d / 2, d / 2, btnmulaigame.Height - d);
        }

        private void Formisi_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormGame balik = new FormGame();
            balik.Show();
        }
    }
}
