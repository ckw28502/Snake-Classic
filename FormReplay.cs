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

namespace Tugas_Proyek
{
    public partial class FormReplay : Form
    {
        public FormReplay()
        {
            InitializeComponent();
        }
        Graphics g;
        //apple
        Random rnd = new Random();
        int xaple, yaple, jenisaple, ctr;
        Bitmap[] apple;
        Rectangle food;
        //blink
        int idxapple, blink;
        //snake
        bool turn = true;
        int head_x;
        int head_y;
        int tail_x;
        int tail_y;
        List<Bitmap> b = new List<Bitmap>();
        List<int> left_up = new List<int>();
        List<int> left_down = new List<int>();
        List<int> right_up = new List<int>();
        List<int> right_down = new List<int>();
        List<int> left = new List<int>();
        List<int> top = new List<int>();
        Bitmap head = new Bitmap(Resource1.head_left);
        Bitmap tail = new Bitmap(Resource1.tail_left);
        bool start = false;
        bool first = true;
        //skor
        int score;
        bool eat = false;

        private void timer1_Tick(object sender, EventArgs e)
        {
            blink++;//time buat blink
            if (replay_x.Count > 0)
            {
                if (first)
                {
                    first = false;
                    head_x = replay_x.Dequeue();
                    head_y = replay_y.Dequeue();
                    for (int i = b.Count - 1; i >= 0; i--)
                    {
                        if (i == b.Count - 1)
                        {
                            left[i] = head_x + 30;
                            top[i] = head_y;
                        }
                        else
                        {
                            left[i] = left[i + 1] + 30;
                            top[i] = top[i + 1];
                        }
                    }
                    tail_x = left[0] + 30;
                    tail_y = top[0];
                }
                else
                {
                    if (eat)
                    {
                        b.Add(b[b.Count - 1]);
                        left.Add(head_x);
                        top.Add(head_y);
                        eat = false;
                    }
                    else
                    {
                        if (bomb)
                        {
                            if (b.Count > 1)
                            {
                                left.RemoveAt(0);
                                top.RemoveAt(0);
                                b.RemoveAt(0);
                                bomb = false;
                            }
                        }
                        if (b.Count > 0)
                        {
                            tail_x = left[0];
                            tail_y = top[0];
                        }
                        else
                        {
                            tail_x = head_x;
                            tail_y = head_y;
                        }
                        for (int i = 0; i < b.Count; i++)
                        {
                            if (i == b.Count - 1)
                            {
                                left[i] = head_x;
                                top[i] = head_y;
                            }
                            else
                            {
                                left[i] = left[i + 1];
                                top[i] = top[i + 1];
                            }
                        }
                    }
                    if (replay_x.Count > 0)
                    {
                        head_x = replay_x.Dequeue();
                        head_y = replay_y.Dequeue();
                    }
                }
                if (left[0] > tail_x)
                {
                    if (left[0] - 30 != tail_x)
                    {
                        tail = new Bitmap(Resource1.tail_left);
                    }
                    else
                    {
                        tail = new Bitmap(Resource1.tail_right);
                    }
                }
                else if (left[0] < tail_x)
                {
                    if (left[0] + 30 != tail_x)
                    {
                        tail = new Bitmap(Resource1.tail_right);
                    }
                    else
                    {
                        tail = new Bitmap(Resource1.tail_left);
                    }
                }
                else if (top[0] < tail_y)
                {
                    if (top[0] + 30 != tail_y)
                    {
                        tail = new Bitmap(Resource1.tail_down);
                    }
                    else
                    {
                        tail = new Bitmap(Resource1.tail_up);
                    }
                }
                else if (top[0] > tail_y)
                {
                    if (top[0] - 30 != tail_y)
                    {
                        tail = new Bitmap(Resource1.tail_up);
                    }
                    else
                    {
                        tail = new Bitmap(Resource1.tail_down);
                    }
                }
                for (int i = 0; i < b.Count; i++)
                {
                    int before_x;
                    int before_y;
                    int after_x;
                    int after_y;
                    if (i == 0)
                    {
                        before_x = tail_x;
                        before_y = tail_y;
                    }
                    else
                    {
                        before_x = left[i - 1];
                        before_y = top[i - 1];
                    }
                    if (i == b.Count - 1)
                    {
                        after_x = head_x;
                        after_y = head_y;
                    }
                    else
                    {
                        after_x = left[i + 1];
                        after_y = top[i + 1];
                    }
                    if (before_x == left[i] && after_x == left[i])
                    {
                        b[i] = new Bitmap(Resource1.straight_vertical);
                    }
                    else if (before_y == top[i] && after_y == top[i])
                    {
                        b[i] = new Bitmap(Resource1.straight_horizontal);
                    }
                    else if ((before_y < top[i] && before_y + 30 == top[i] && after_x < left[i] && after_x + 30 == left[i]) || (after_y < top[i] && after_y + 30 == top[i] && before_x < left[i] && before_x + 30 == left[i]) || (before_y > top[i] && before_y - 30 != top[i] && after_x < left[i] && after_x + 30 == left[i]) || (after_y < top[i] && after_y + 30 == top[i] && before_x > left[i] && before_x - 30 != left[i]) || (before_y < top[i] && before_y + 30 == top[i] && after_x > left[i] && after_x - 30 != left[i]) || (after_y > top[i] && after_y - 30 != top[i] && before_x < left[i] && before_x + 30 == left[i]))
                    {
                        b[i] = new Bitmap(Resource1.turn_left_up);
                        left_up.Add(i);
                    }
                    else if ((before_y < top[i] && before_y + 30 == top[i] && after_x > left[i] && after_x - 30 == left[i]) || (after_y < top[i] && after_y + 30 == top[i] && before_x > left[i] && before_x - 30 == left[i]) || (before_y > top[i] && before_y - 30 != top[i] && after_x > left[i] && after_x - 30 == left[i]) || (after_y < top[i] && after_y + 30 == top[i] && before_x < left[i] && before_x + 30 != left[i]) || (before_y < top[i] && before_y + 30 == top[i] && after_x < left[i] && after_x + 30 != left[i]) || (after_y > top[i] && after_y - 30 != top[i] && before_x > left[i] && before_x - 30 == left[i]))
                    {
                        b[i] = new Bitmap(Resource1.turn_right_up);
                        right_up.Add(i);
                    }
                    else if ((before_y > top[i] && before_y - 30 == top[i] && after_x < left[i] && after_x + 30 == left[i]) || (after_y > top[i] && after_y - 30 == top[i] && before_x < left[i] && before_x + 30 == left[i]) || (before_y < top[i] && before_y + 30 != top[i] && after_x < left[i] && after_x + 30 == left[i]) || (after_y > top[i] && after_y - 30 == top[i] && before_x > left[i] && before_x - 30 != left[i]) || (before_y > top[i] && before_y - 30 == top[i] && after_x > left[i] && after_x - 30 != left[i]) || (after_y < top[i] && after_y + 30 != top[i] && before_x < left[i] && before_x + 30 == left[i]))
                    {
                        b[i] = new Bitmap(Resource1.turn_left_down);
                        left_down.Add(i);
                    }
                    else if ((before_y > top[i] && before_y - 30 == top[i] && after_x > left[i] && after_x - 30 == left[i]) || (after_y > top[i] && after_y - 30 == top[i] && before_x > left[i] && before_x - 30 == left[i]) || (before_y < top[i] && before_y + 30 != top[i] && after_x > left[i] && after_x - 30 == left[i]) || (after_y > top[i] && after_y - 30 == top[i] && before_x < left[i] && before_x + 30 != left[i]) || (before_y > top[i] && before_y - 30 == top[i] && after_x < left[i] && after_x + 30 != left[i]) || (after_y < top[i] && after_y + 30 != top[i] && before_x > left[i] && before_x - 30 == left[i]))
                    {
                        b[i] = new Bitmap(Resource1.turn_right_down);
                        right_down.Add(i);
                    }
                }
                string kepala = "";
                if (ular.Count > 0)
                {
                    kepala = ular.Dequeue();
                }
                if (kepala == "up")
                {
                    head = new Bitmap(Resource1.head_up);
                }
                else if (kepala == "down")
                {
                    head = new Bitmap(Resource1.head_down);
                }
                else if (kepala == "left")
                {
                    head = new Bitmap(Resource1.head_left);
                }
                else if (kepala == "right")
                {
                    head = new Bitmap(Resource1.head_right);
                }
                if (blink <= 10)//ubah angka kalau timer2 ticknya ditambah
                {
                    if (blink >= 6)
                    {
                        idxapple++;
                        if (idxapple >= 3)//reset index buat gak error
                        {
                            idxapple = 0;
                        }
                    }
                }
                else
                {
                    blink = 0;
                }
                cekeat();//untuk cek udah makan atau belum
                Invalidate();
            }
            else
            {
                timer1.Stop();
                timer2.Stop();
                timer3.Stop();
                MessageBox.Show("Replay selesai\nscore : " + score.ToString());
                Formpilih pilih = new Formpilih();
                pilih.Show();
                this.Close();
            }
        }
        bool bomb = false;
        private void cekeat()
        {
            Rectangle handler = new Rectangle(head_x, head_y, 40, 40);
            if (handler.IntersectsWith(food))
            {
                if (jenisaple != 3)
                {
                    eat = true;
                    if (jenisaple == 0)
                    {
                        score += 5;
                    }
                    else if (jenisaple == 1)
                    {
                        score += 10;
                    }
                    else if (jenisaple == 2)
                    {
                        score += 15;
                    }
                }
                else if (jenisaple == 3)
                {
                    bomb = true;
                    score -= 10;
                }
                label_skor.Text = "SCORE = " + score.ToString();
                timer3.Start();
                ctr = 0;
                idxapple = 0;
                blink = 0;
            }
        }

        private void FormReplay_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            if (left[0] < tail_x)
            {
                tail_y -= 1;
                g.DrawImage(tail, tail_x, tail_y, 40, 40);
                tail_y += 1;
            }
            else if (top[0] < tail_y)
            {
                tail_x += 1;
                g.DrawImage(tail, tail_x, tail_y, 40, 40);
                tail_x -= 1;
            }
            else if (top[0] > tail_y)
            {
                tail_x -= 1;
                g.DrawImage(tail, tail_x, tail_y, 40, 40);
                tail_x += 1;
            }
            else
            {
                g.DrawImage(tail, tail_x, tail_y, 40, 40);
            }

            foreach (int item in left_up)
            {
                left[item] -= 1;
                top[item] -= 1;
            }
            foreach (int item in right_up)
            {
                left[item] += 1;
                top[item] -= 1;
            }
            foreach (int item in left_down)
            {
                left[item] -= 1;
                top[item] += 1;
            }
            foreach (int item in right_down)
            {
                left[item] += 1;
                top[item] += 1;
            }
            for (int i = 0; i < b.Count; i++)
            {
                g.DrawImage(b[i], left[i], top[i], 40, 40);
            }
            foreach (int item in left_up)
            {
                left[item] += 1;
                top[item] += 1;
            }
            foreach (int item in right_up)
            {
                left[item] -= 1;
                top[item] += 1;
            }
            foreach (int item in left_down)
            {
                left[item] += 1;
                top[item] -= 1;
            }
            foreach (int item in right_down)
            {
                left[item] -= 1;
                top[item] -= 1;
            }
            left_up.Clear();
            left_down.Clear();
            right_down.Clear();
            right_up.Clear();
            g.DrawImage(head, head_x, head_y, 40, 40);
            if (turn == false)
            {
                turn = true;
            }
            if (start == false)
            {
                timer1.Start();
                start = true;
            }
            //apple
            Graphics f = e.Graphics;

            /*if (jenisaple == 0)
            {
                f.DrawImage(apple[1], food);
            }
            else if (jenisaple == 1)
            {
                f.DrawImage(apple[0], food);
            }
            else if (jenisaple == 2)
            {
                f.DrawImage(apple[2], food);
            }
            else if (jenisaple == 3 ^ jenisaple == 4)
            {
                f.DrawImage(apple[3], food);
            }*/
            //blink
            if (jenisaple == 0)
            {
                apple[0] = new Bitmap(Resource1.applered);
                apple[1] = new Bitmap(Resource1.bgproyek);
                apple[2] = new Bitmap(Resource1.applered);
                apple[3] = new Bitmap(Resource1.bgproyek);
                f.DrawImage(apple[idxapple], food);
            }
            else if (jenisaple == 1)
            {
                apple[0] = new Bitmap(Resource1.applegreen);
                apple[1] = new Bitmap(Resource1.bgproyek);
                apple[2] = new Bitmap(Resource1.applegreen);
                apple[3] = new Bitmap(Resource1.bgproyek);
                f.DrawImage(apple[idxapple], food);
            }
            else if (jenisaple == 2)
            {
                apple[0] = new Bitmap(Resource1.applegold);
                apple[1] = new Bitmap(Resource1.bgproyek);
                apple[2] = new Bitmap(Resource1.applegold);
                apple[3] = new Bitmap(Resource1.bgproyek);
                f.DrawImage(apple[idxapple], food);
            }
            else if (jenisaple == 3 ^ jenisaple == 4)
            {
                apple[0] = new Bitmap(Resource1.Bombnew);
                apple[1] = new Bitmap(Resource1.bgproyek);
                apple[2] = new Bitmap(Resource1.Bombnew);
                apple[3] = new Bitmap(Resource1.bgproyek);
                f.DrawImage(apple[idxapple], food);
            }

            timer2.Start();
            if (start == false)
            {
                score = 0;
                timer1.Start();
                timer3.Start();//start apple
                start = true;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            ctr++;
            if (ctr > 5)
            {
                timer3.Start();
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            //random lokasi
            xaple = apple_x.Dequeue();
            yaple = apple_y.Dequeue();
            //random warna
            jenisaple = warna.Dequeue();
            food = new Rectangle(xaple, yaple, 40, 40);
            ctr = 0;
            //untuk reset blink
            blink = 0;
            idxapple = 0;
            timer3.Stop();
        }

        //replay
        string nama;
        Queue<int> replay_x = new Queue<int>();
        Queue<int> replay_y = new Queue<int>();
        Queue<string> ular = new Queue<string>();
        Queue<int> apple_x = new Queue<int>();
        Queue<int> apple_y = new Queue<int>();
        Queue<int> warna = new Queue<int>();
        private void FormReplay_Load(object sender, EventArgs e)
        {
            blink = 0;
            idxapple = 0;
            this.Height = 755;
            StreamReader reader = new StreamReader(Application.StartupPath + "\\replay.txt");
            nama = reader.ReadToEnd();
            reader.Close();
            Play();
        }
        int wall;
        private void Play()
        {
            XmlReader read = XmlReader.Create(Application.StartupPath + "\\" + nama);
            string node = "";
            while (read.Read())
            {
                switch (read.NodeType)
                {
                    case XmlNodeType.Element:
                        node = read.Name;
                        break;
                    case XmlNodeType.Text:
                        if (node == "x")
                        {
                            replay_x.Enqueue(Convert.ToInt32(read.Value));
                        }
                        else if (node == "y")
                        {
                            replay_y.Enqueue(Convert.ToInt32(read.Value));
                        }
                        else if (node == "kepala")
                        {
                            ular.Enqueue(read.Value);
                        }
                        else if (node == "apple_x")
                        {
                            apple_x.Enqueue(Convert.ToInt32(read.Value));
                        }
                        else if (node == "apple_y")
                        {
                            apple_y.Enqueue(Convert.ToInt32(read.Value));
                        }
                        else if (node == "warna")
                        {
                            warna.Enqueue(Convert.ToInt32(read.Value));
                        }
                        else if (node == "wall")
                        {
                            wall = Convert.ToInt32(read.Value);
                            if (wall == 0) 
                            {
                                this.Controls.Remove(label1);
                                this.Controls.Remove(label2);
                                this.Controls.Remove(label3);
                                this.Controls.Remove(label4);
                                this.Controls.Remove(label5);
                                this.Controls.Remove(label6);
                                this.Controls.Remove(label7);
                                this.Controls.Remove(label8);
                                this.Controls.Remove(label9);
                                this.Controls.Remove(label10);
                                this.Controls.Remove(label11);
                                this.Controls.Remove(label12);
                                this.Controls.Remove(label13);
                                this.Controls.Remove(label14);
                                this.Controls.Remove(label15);
                                this.Controls.Remove(label16);
                                this.Controls.Remove(label17);
                                this.Controls.Remove(label18);
                            }
                        }
                        break;
                }
            }
            read.Close();
            head_x = 350;
            head_y = 350;
            left.Add(head_x + 30);
            top.Add(head_y);
            tail_x = head_x + 60;
            tail_y = head_y;
            Bitmap bmp = new Bitmap(Resource1.straight_horizontal);
            b.Add(bmp);
            DoubleBuffered = true;
            //apple
            ctr = 0;
            apple = new Bitmap[4];
            apple[0] = new Bitmap(Resource1.applegreen);
            apple[1] = new Bitmap(Resource1.applered);
            apple[2] = new Bitmap(Resource1.applegold);
            apple[3] = new Bitmap(Resource1.Bombnew);
            DoubleBuffered = true;
        }
    }
}
