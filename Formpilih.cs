using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace Tugas_Proyek
{
    public partial class Formpilih : Form
    {
        public Formpilih()
        {
            InitializeComponent();
        }


        SqlDataReader read;
        SqlConnection conn;
        string connstr;
        SqlCommand cmd;
        string name;
        List<string> nama = new List<string>();
        List<int> id = new List<int>();
        List<int> tingkat = new List<int>();
        List<int> poin = new List<int>();
        List<DateTime> tgl = new List<DateTime>();
        List<Button> btn = new List<Button>();
        bool t = true;
        string orderby = "";
        string where = "";
        List<Button> del = new List<Button>();
        private void Formpilih_Load(object sender, EventArgs e)
        {
            connstr = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =" + Application.StartupPath + "\\snake.mdf; Integrated Security = True; Connect Timeout = 30";
            conn = new SqlConnection(connstr);
            connstr = "SELECT id,nama,score,kesulitan,tanggal FROM skor";
            isi();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.TranslateTransform(panel1.AutoScrollPosition.X, panel1.AutoScrollPosition.Y);
            Graphics g = e.Graphics;
            int x = 0;
            if (t)
            {
                btn.Clear();
                del.Clear();
            }
            for (int i = 0; i < id.Count; i++)
            {
                g.FillRectangle(Brushes.Goldenrod, 0, 0 + x, panel1.Width, 200);
                Font fnama = new Font("Arial", 20, FontStyle.Bold);
                Font lain = new Font("Arial", 12, FontStyle.Regular);
                g.DrawString("Nama: " + nama[i], fnama, Brushes.Black, 10, 10 + x);
                g.DrawString("Score : " + poin[i].ToString(), lain, Brushes.Black, 10, 50 + x);
                g.DrawString("Tanggal :" + tgl[i].ToString("dd/MM/yyyy"), lain, Brushes.Black, 10, 90 + x);
                g.DrawString("Kesulitan : " + kesulitan.Items[tingkat[i]].ToString(), lain, Brushes.Black, 170, 50 + x);
                if (t)
                {
                    Button b = new Button();
                    b.Text = "Play";
                    b.Size = new Size(100, 78);
                    b.BackColor = Color.Green;
                    b.Location = new Point(panel1.Width - 300, 59 + x);
                    btn.Add(b);
                    b.Click += new EventHandler(btn_click);
                    panel1.Controls.Add(b);
                    Button d = new Button();
                    d.Text = "Delete";
                    d.Size = new Size(100, 78);
                    d.BackColor = Color.Red;
                    d.Location = new Point(panel1.Width - 130, 59 + x);
                    del.Add(d);
                    d.Click += new EventHandler(delete);
                    panel1.Controls.Add(d);
                }
                x += 250;
            }
            t = false;
        }

        private void delete(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            for (int i = 0; i < del.Count; i++)
            {
                if (del[i] == b)
                {
                    conn.Open();
                    cmd = new SqlCommand("DELETE skor WHERE id = " + id[i].ToString(), conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    isi();
                }
            }
        }

        private void btn_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            for (int i = 0; i < btn.Count; i++)
            {
                if (btn[i] == b)
                {
                    StreamWriter writer = new StreamWriter(Application.StartupPath + "\\replay.txt");
                    writer.Write(id[i].ToString() + ".xml");
                    writer.Close();
                    FormReplay replay = new FormReplay();
                    replay.ShowDialog();
                    this.Hide();
                }
            }
        }

        private void chknama_CheckedChanged(object sender, EventArgs e)
        {
            if (chknama.Checked)
            {
                txtnama.Enabled = true;
            }
            else
            {
                txtnama.Enabled = false;
            }
        }

        private void chkscore_CheckedChanged(object sender, EventArgs e)
        {
            if (chkscore.Checked)
            {
                skor.Enabled = true;
                cmbskor.Enabled = true;
            }
            else
            {
                skor.Enabled = false;
                cmbskor.Enabled = false;
            }
        }

        private void chktanggal_CheckedChanged(object sender, EventArgs e)
        {
            if (chktanggal.Checked)
            {
                tglafter.Enabled = true;
                tglbefore.Enabled = true;
            }
            else
            {
                tglafter.Enabled = false;
                tglbefore.Enabled = false;
            }
        }

        private void chkkesulitan_CheckedChanged(object sender, EventArgs e)
        {
            if (chkkesulitan.Checked)
            {
                kesulitan.Enabled = true;
            }
            else
            {
                kesulitan.Enabled = false;
            }
        }

        private void btnsort_Click(object sender, EventArgs e)
        {
            if (sort.SelectedIndex < 0 || sc.SelectedIndex < 0)
            {
                MessageBox.Show("Inputan sorting tidak valid!");
            }
            else
            {
                string by = "";
                if (sort.SelectedIndex == 2)
                {
                    by = "id";
                }
                else
                {
                    by = sort.SelectedItem.ToString().ToLower();
                }
                orderby = " ORDER BY " + by + " " + sc.SelectedItem.ToString();
                isi();
            }
        }

        private void isi()
        {
            id.Clear();
            nama.Clear();
            poin.Clear();
            tingkat.Clear();
            tgl.Clear();
            panel1.Controls.Clear();
            t = true;
            conn.Open();
            if (orderby.Length == 0)
            {
                orderby = " ORDER BY id DESC";
                cmd = new SqlCommand(connstr + where + orderby, conn);
                orderby = "";
            }
            else
            {
                cmd = new SqlCommand(connstr + where + orderby, conn);
            }
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                id.Add(Convert.ToInt32(read[0]));
                nama.Add(read[1].ToString());
                poin.Add(Convert.ToInt32(read[2]));
                tingkat.Add(Convert.ToInt32(read[3]));
                tgl.Add(Convert.ToDateTime(read[4].ToString()));
            }
            read.Close();
            conn.Close();
            panel1.Invalidate();
        }

        private void filter_Click(object sender, EventArgs e)
        {
            where = "";
            bool syarat = false;
            if (chknama.Checked && txtnama.TextLength > 0)
            {
                syarat = and(syarat);
                where += " CHARINDEX('" + txtnama.Text + "',nama) > 0";

            }
            if (chkscore.Checked && skor.Value >= 0 && cmbskor.SelectedIndex >= 0)
            {
                syarat = and(syarat);
                where += " score " + cmbskor.SelectedItem.ToString() + " " + skor.Value.ToString();
            }
            if (chktanggal.Checked && tglafter.Value > tglbefore.Value)
            {
                syarat = and(syarat);
                where += " tanggal BETWEEN '" + tglbefore.Value.ToString() + "' AND '" + tglafter.Value.ToString() + "'";
            }
            if (chkkesulitan.Checked && kesulitan.SelectedIndex >= 0)
            {
                syarat = and(syarat);
                where += " kesulitan = " + kesulitan.SelectedIndex;
            }
            isi();
        }

        private bool and(bool a)
        {
            if (a)
            {
                where += " AND";
            }
            else
            {
                where += " WHERE";
                a = true;
            }
            return a;
        }

        private void Formpilih_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormGame game = new FormGame();
            game.Show();
        }

        private void btnreset_Click_1(object sender, EventArgs e)
        {
            where = "";
            orderby = "";
            isi();
        }

        private void Formpilih_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int d = 20;
            //reset
            g.FillEllipse(Brushes.DarkKhaki, btnreset.Location.X - d / 2, btnreset.Location.Y, d, d);
            g.FillEllipse(Brushes.DarkKhaki, btnreset.Location.X - d / 2, btnreset.Location.Y + btnreset.Height - d, d, d);
            g.FillRectangle(Brushes.DarkKhaki, btnreset.Location.X - d / 2, btnreset.Location.Y + d / 2, d / 2, btnreset.Height - d);
            g.FillEllipse(Brushes.DarkKhaki, btnreset.Location.X + btnreset.Width - d / 2, btnreset.Location.Y, d, d);
            g.FillEllipse(Brushes.DarkKhaki, btnreset.Location.X + btnreset.Width - d / 2, btnreset.Location.Y + btnreset.Height - d, d, d);
            g.FillRectangle(Brushes.DarkKhaki, btnreset.Location.X + btnreset.Width, btnreset.Location.Y + d / 2, d / 2, btnreset.Height - d);
        }

        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int d = 20;
            //filter
            g.FillEllipse(Brushes.DarkKhaki, filter.Location.X - d / 2, filter.Location.Y, d, d);
            g.FillEllipse(Brushes.DarkKhaki, filter.Location.X - d / 2, filter.Location.Y + filter.Height - d, d, d);
            g.FillRectangle(Brushes.DarkKhaki, filter.Location.X - d / 2, filter.Location.Y + d / 2, d / 2, filter.Height - d);
            g.FillEllipse(Brushes.DarkKhaki, filter.Location.X + filter.Width - d / 2, filter.Location.Y, d, d);
            g.FillEllipse(Brushes.DarkKhaki, filter.Location.X + filter.Width - d / 2, filter.Location.Y + filter.Height - d, d, d);
            g.FillRectangle(Brushes.DarkKhaki, filter.Location.X + filter.Width, filter.Location.Y + d / 2, d / 2, filter.Height - d);
        }

        private void groupBox2_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int d = 20;
            //sort
            g.FillEllipse(Brushes.DarkKhaki, btnsort.Location.X - d / 2, btnsort.Location.Y, d, d);
            g.FillEllipse(Brushes.DarkKhaki, btnsort.Location.X - d / 2, btnsort.Location.Y + btnsort.Height - d, d, d);
            g.FillRectangle(Brushes.DarkKhaki, btnsort.Location.X - d / 2, btnsort.Location.Y + d / 2, d / 2, btnsort.Height - d);
            g.FillEllipse(Brushes.DarkKhaki, btnsort.Location.X + btnsort.Width - d / 2, btnsort.Location.Y, d, d);
            g.FillEllipse(Brushes.DarkKhaki, btnsort.Location.X + btnsort.Width - d / 2, btnsort.Location.Y + btnsort.Height - d, d, d);
            g.FillRectangle(Brushes.DarkKhaki, btnsort.Location.X + btnsort.Width, btnsort.Location.Y + d / 2, d / 2, btnsort.Height - d);
        }
    }
}
