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
    public partial class FormGame : Form
    {
        public FormGame()
        {
            InitializeComponent();
        }

        public FormPermainan formmain;
        public static int song;
        /*public List<string> angka = new List<string>();
        public List<string> totalnama = new List<string>();*/

        // musik bg
        System.Media.SoundPlayer musik = new System.Media.SoundPlayer();

        private void btnstart_Click(object sender, EventArgs e)
        {
            Formisi isidata = new Formisi();
            isidata.Show();
            this.Hide();
        }

        private void FormGame_Load(object sender, EventArgs e)
        {
            musik.SoundLocation = Application.StartupPath + "\\laguular.wav";
            musik.Play();
            song = 1;
            if (song==1)
            {
                musik.Play();
            }
            else if (song == 2)
            {
                musik.Stop();
            }
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnboard_Click(object sender, EventArgs e)
        {
            FormScore score = new FormScore();
            score.Show();
            this.Hide();
        }

        private void btnreplay_Click(object sender, EventArgs e)
        {
            Formpilih replay = new Formpilih();
            replay.Show();
            this.Hide();
        }

        private void FormGame_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int d = 20;
            //exit
            g.FillEllipse(Brushes.NavajoWhite, btnexit.Location.X - d / 2, btnexit.Location.Y, d, d);
            g.FillEllipse(Brushes.NavajoWhite, btnexit.Location.X - d / 2, btnexit.Location.Y + btnexit.Height - d, d, d);
            g.FillRectangle(Brushes.NavajoWhite, btnexit.Location.X - d / 2, btnexit.Location.Y + d / 2, d / 2, btnexit.Height - d);
            g.FillEllipse(Brushes.NavajoWhite, btnexit.Location.X + btnexit.Width - d / 2, btnexit.Location.Y, d, d);
            g.FillEllipse(Brushes.NavajoWhite, btnexit.Location.X + btnexit.Width - d / 2, btnexit.Location.Y + btnexit.Height - d, d, d);
            g.FillRectangle(Brushes.NavajoWhite, btnexit.Location.X + btnexit.Width, btnexit.Location.Y + d / 2, d / 2, btnexit.Height - d);
            //board
            g.FillEllipse(Brushes.NavajoWhite, btnboard.Location.X - d / 2, btnboard.Location.Y, d, d);
            g.FillEllipse(Brushes.NavajoWhite, btnboard.Location.X - d / 2, btnboard.Location.Y + btnboard.Height - d, d, d);
            g.FillRectangle(Brushes.NavajoWhite, btnboard.Location.X - d / 2, btnboard.Location.Y + d / 2, d / 2, btnboard.Height - d);
            g.FillEllipse(Brushes.NavajoWhite, btnboard.Location.X + btnboard.Width - d / 2, btnboard.Location.Y, d, d);
            g.FillEllipse(Brushes.NavajoWhite, btnboard.Location.X + btnboard.Width - d / 2, btnboard.Location.Y + btnboard.Height - d, d, d);
            g.FillRectangle(Brushes.NavajoWhite, btnboard.Location.X + btnboard.Width, btnboard.Location.Y + d / 2, d / 2, btnboard.Height - d);
            //replay
            g.FillEllipse(Brushes.NavajoWhite, btnreplay.Location.X - d / 2, btnreplay.Location.Y, d, d);
            g.FillEllipse(Brushes.NavajoWhite, btnreplay.Location.X - d / 2, btnreplay.Location.Y + btnreplay.Height - d, d, d);
            g.FillRectangle(Brushes.NavajoWhite, btnreplay.Location.X - d / 2, btnreplay.Location.Y + d / 2, d / 2, btnreplay.Height - d);
            g.FillEllipse(Brushes.NavajoWhite, btnreplay.Location.X + btnreplay.Width - d / 2, btnreplay.Location.Y, d, d);
            g.FillEllipse(Brushes.NavajoWhite, btnreplay.Location.X + btnreplay.Width - d / 2, btnreplay.Location.Y + btnreplay.Height - d, d, d);
            g.FillRectangle(Brushes.NavajoWhite, btnreplay.Location.X + btnreplay.Width, btnreplay.Location.Y + d / 2, d / 2, btnreplay.Height - d);
            //start
            g.FillEllipse(Brushes.NavajoWhite, btnstart.Location.X - d / 2, btnstart.Location.Y, d, d);
            g.FillEllipse(Brushes.NavajoWhite, btnstart.Location.X - d / 2, btnstart.Location.Y + btnstart.Height - d, d, d);
            g.FillRectangle(Brushes.NavajoWhite, btnstart.Location.X - d / 2, btnstart.Location.Y + d / 2, d / 2, btnstart.Height - d);
            g.FillEllipse(Brushes.NavajoWhite, btnstart.Location.X + btnstart.Width - d / 2, btnstart.Location.Y, d, d);
            g.FillEllipse(Brushes.NavajoWhite, btnstart.Location.X + btnreplay.Width - d / 2, btnstart.Location.Y + btnstart.Height - d, d, d);
            g.FillRectangle(Brushes.NavajoWhite, btnstart.Location.X + btnstart.Width, btnstart.Location.Y + d / 2, d / 2, btnstart.Height - d);
            //setting
            g.FillEllipse(Brushes.NavajoWhite, btnsetting.Location.X - d / 2, btnsetting.Location.Y, d, d);
            g.FillEllipse(Brushes.NavajoWhite, btnsetting.Location.X - d / 2, btnsetting.Location.Y + btnsetting.Height - d, d, d);
            g.FillRectangle(Brushes.NavajoWhite, btnsetting.Location.X - d / 2, btnsetting.Location.Y + d / 2, d / 2, btnsetting.Height - d);
            g.FillEllipse(Brushes.NavajoWhite, btnsetting.Location.X + btnsetting.Width - d / 2, btnsetting.Location.Y, d, d);
            g.FillEllipse(Brushes.NavajoWhite, btnsetting.Location.X + btnsetting.Width - d / 2, btnsetting.Location.Y + btnsetting.Height - d, d, d);
            g.FillRectangle(Brushes.NavajoWhite, btnsetting.Location.X + btnsetting.Width, btnsetting.Location.Y + d / 2, d / 2, btnsetting.Height - d);
        }

        private void FormGame_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
        }

        private void btnsetting_Click(object sender, EventArgs e)
        {
            FormSetting pengaturan = new FormSetting();
            pengaturan.Show();
            this.Hide();
        }
    }
}
