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
    public partial class FormSetting : Form
    {
        public FormSetting()
        {
            InitializeComponent();
        }

        System.Media.SoundPlayer musik = new System.Media.SoundPlayer();
       
        private void FormSetting_Load(object sender, EventArgs e)
        {
            
            musik.SoundLocation = Application.StartupPath + "\\laguular.wav";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                FormGame game = new FormGame();
                game.Show();
                FormGame.song = 1;
                this.Hide();
            }
            if (radioButton2.Checked == true)
            {
                FormGame game = new FormGame();
                game.Show();
                FormGame.song = 2;
                this.Hide();
                musik.Stop();
            }
        }

        private void FormSetting_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int d = 20;

            g.FillEllipse(Brushes.DarkSeaGreen, btnSave.Location.X - d / 2, btnSave.Location.Y, d, d);
            g.FillEllipse(Brushes.DarkSeaGreen, btnSave.Location.X - d / 2, btnSave.Location.Y + btnSave.Height - d, d, d);
            g.FillRectangle(Brushes.DarkSeaGreen, btnSave.Location.X - d / 2, btnSave.Location.Y + d / 2, d / 2, btnSave.Height - d);
            g.FillEllipse(Brushes.DarkSeaGreen, btnSave.Location.X + btnSave.Width - d / 2, btnSave.Location.Y, d, d);
            g.FillEllipse(Brushes.DarkSeaGreen, btnSave.Location.X + btnSave.Width - d / 2, btnSave.Location.Y + btnSave.Height - d, d, d);
            g.FillRectangle(Brushes.DarkSeaGreen, btnSave.Location.X + btnSave.Width, btnSave.Location.Y + d / 2, d / 2, btnSave.Height - d);
        }
    }
}
