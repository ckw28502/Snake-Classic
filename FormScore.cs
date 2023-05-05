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
    public partial class FormScore : Form
    {
        public FormScore()
        {
            InitializeComponent();
        }

        SqlDataReader baca;
        SqlConnection conn;
        string connstr;
        SqlCommand cmd;
        List<string> player = new List<string>();
        List<int> poin = new List<int>();
        int ctr = 0;

        private void FormScore_Load(object sender, EventArgs e)
        {
            connstr = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =" + Application.StartupPath + "\\snake.mdf; Integrated Security = True; Connect Timeout = 30";
            conn = new SqlConnection(connstr);
            conn.Open();
            connstr = "SELECT nama,score FROM skor ORDER BY score desc";
            cmd = new SqlCommand(connstr, conn);
            baca = cmd.ExecuteReader();
            while (baca.Read())
            {
                player.Add(baca[0].ToString());
                poin.Add(Convert.ToInt32(baca[1]));
            }
            for (int i = 0; i < player.Count; i++)
            {
                ctr++;
                if (i != 0)
                {
                    textBox1.Text+="\r\n";
                }
                textBox1.Text += ctr + ". " + player[i].ToString() + " - " + poin[i].ToString();
            }
            baca.Close();
            conn.Close();
        }

        private void FormScore_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormGame kembali = new FormGame();
            kembali.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormScore_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int d = 20;
            //main menu
            g.FillEllipse(Brushes.SteelBlue, btnmenu.Location.X - d / 2, btnmenu.Location.Y, d, d);
            g.FillEllipse(Brushes.SteelBlue, btnmenu.Location.X - d / 2, btnmenu.Location.Y + btnmenu.Height - d, d, d);
            g.FillRectangle(Brushes.SteelBlue, btnmenu.Location.X - d / 2, btnmenu.Location.Y + d / 2, d / 2, btnmenu.Height - d);
            g.FillEllipse(Brushes.SteelBlue, btnmenu.Location.X + btnmenu.Width - d / 2, btnmenu.Location.Y, d, d);
            g.FillEllipse(Brushes.SteelBlue, btnmenu.Location.X + btnmenu.Width - d / 2, btnmenu.Location.Y + btnmenu.Height - d, d, d);
            g.FillRectangle(Brushes.SteelBlue, btnmenu.Location.X + btnmenu.Width, btnmenu.Location.Y + d / 2, d / 2, btnmenu.Height - d);
        }

        private void btnmenu_Click(object sender, EventArgs e)
        {
            FormGame game = new FormGame();
            game.Show();
            this.Hide();
        }
    }
}
