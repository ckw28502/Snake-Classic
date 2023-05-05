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
using System.Data.SqlClient;

namespace Tugas_Proyek
{
    public partial class FormPermainanSedang : Form
    {
        public FormPermainanSedang()
        {
            InitializeComponent();
        }

        public static string nama2 = "";
        SqlDataReader reader;
        String connStr;
        SqlConnection conn;
        SqlCommand cmd;
        int data;
        string akhir;
        Graphics g;
        //apple
        Random rnd = new Random();
        int xaple, yaple, jenisaple, ctr,idxapple, blink;
        Bitmap[] apple;
        Rectangle food;
        //snake
        bool turn = true;
        int x = -30;
        int y = 0;
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
        int gamesound;
        //skor
        int score;
        bool eat = false;
        //replay
        Queue<int> replay_x = new Queue<int>();
        Queue<int> replay_y = new Queue<int>();
        Queue<string> ular = new Queue<string>();
        Queue<int> apple_x = new Queue<int>();
        Queue<int> apple_y = new Queue<int>();
        Queue<int> warna = new Queue<int>();

        // musik bg
        System.Media.SoundPlayer musik = new System.Media.SoundPlayer();
        private void FormPermainanSedang_Load(object sender, EventArgs e)
        {
            musik.SoundLocation = Application.StartupPath + "\\laguular.wav";
            //musik.Play();
            gamesound = FormGame.song;
            if (gamesound == 1)
            {
                pictureBox1.BackgroundImage = Resource1.soundOn;
                musik.Play();
            }
            else if (gamesound == 2)
            {
                pictureBox1.BackgroundImage = Resource1.soundOff;
                musik.Stop();
            }

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
            apple = new Bitmap[4];//array harus 4 untuk bisa blink
            apple[0] = new Bitmap(Resource1.applegreen);
            apple[1] = new Bitmap(Resource1.applered);
            apple[2] = new Bitmap(Resource1.applegold);
            apple[3] = new Bitmap(Resource1.Bombnew);
            DoubleBuffered = true;

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
            conn.Open();
            cmd = new SqlCommand("SELECT ISNULL(MAX(id),-1) FROM skor", conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                data = Convert.ToInt32(reader[0]) + 1;
            }
            reader.Close();
            conn.Close();
        }
        bool bomb = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            blink++;//time buat blink
            for (int i = 0; i < b.Count; i++)
            {
                if (left[i] == head_x && top[i] == head_y)
                {
                    timer1.Stop();
                    timer2.Stop();
                    timer3.Stop();
                    replay();
                    akhir = nama2;
                    musik.Stop();
                    MessageBox.Show(akhir + "\nGame Over\nScore = " + score.ToString());

                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    conn.Open();

                    try
                    {
                        connStr = "INSERT INTO skor(id,nama,score,kesulitan,tanggal) VALUES( " + data.ToString() + ",'" + akhir + "'," + score.ToString() + ",1,GETDATE())";
                        cmd = new SqlCommand(connStr, conn);

                        cmd.ExecuteNonQuery();

                    }
                    catch (Exception error)
                    {
                        MessageBox.Show(error.Message);
                    }
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }

                    FormGame game = new FormGame();
                    game.Show();
                    this.Close();
                }
            }
            if (head_x == tail_x && head_y == tail_y)
            {
                timer1.Stop();
                timer2.Stop();
                timer3.Stop();
                akhir = nama2;
                musik.Stop();
                replay();
                MessageBox.Show("Game Over\nScore = " + score.ToString());
                try
                {
                    connStr = "INSERT INTO skor(id,nama,score,kesulitan,tanggal) VALUES( " + data.ToString() + ",'" + akhir + "'," + score.ToString() + ",1,GETDATE())";
                    cmd = new SqlCommand(connStr, conn);

                    cmd.ExecuteNonQuery();

                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                FormGame game = new FormGame();
                game.Show();
                this.Close();
            }
            if (first)
            {
                first = false;
                head_x += x;
                head_y += y;
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
                        else
                        {
                            timer1.Stop();
                            timer2.Stop();
                            timer3.Stop();
                            replay();
                            akhir = nama2;
                            musik.Stop();
                            MessageBox.Show(akhir + "\nGame Over\nScore = " + score.ToString());

                            if (conn.State == ConnectionState.Open)
                            {
                                conn.Close();
                            }
                            conn.Open();

                            try
                            {
                                connStr = "INSERT INTO skor(id,nama,score,kesulitan,tanggal) VALUES( " + data.ToString() + ",'" + akhir + "'," + score.ToString() + ",1,GETDATE())";
                                cmd = new SqlCommand(connStr, conn);

                                cmd.ExecuteNonQuery();

                            }
                            catch (Exception error)
                            {
                                MessageBox.Show(error.Message);
                            }
                            if (conn.State == ConnectionState.Open)
                            {
                                conn.Close();
                            }

                            FormGame game = new FormGame();
                            game.Show();
                            this.Close();
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
                head_x += x;
                head_y += y;
                if (head_x < 0)
                {
                    timer1.Stop();
                    timer2.Stop();
                    timer3.Stop();
                    replay();
                    akhir = nama2;
                    musik.Stop();
                    MessageBox.Show(akhir + "\nGame Over\nScore = " + score.ToString());

                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    conn.Open();

                    try
                    {
                        connStr = "INSERT INTO skor(id,nama,score,kesulitan,tanggal) VALUES( " + data.ToString() + ",'" + akhir + "'," + score.ToString() + ",1,GETDATE())";
                        cmd = new SqlCommand(connStr, conn);

                        cmd.ExecuteNonQuery();

                    }
                    catch (Exception error)
                    {
                        MessageBox.Show(error.Message);
                    }
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }

                    FormGame game = new FormGame();
                    game.Show();
                    this.Close();
                }
                else if (head_y < 0)
                {
                    timer1.Stop();
                    timer2.Stop();
                    timer3.Stop();
                    replay();
                    akhir = nama2;
                    musik.Stop();
                    MessageBox.Show(akhir + "\nGame Over\nScore = " + score.ToString());

                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    conn.Open();

                    try
                    {
                        connStr = "INSERT INTO skor(id,nama,score,kesulitan,tanggal) VALUES( " + data.ToString() + ",'" + akhir + "'," + score.ToString() + ",1,GETDATE())";
                        cmd = new SqlCommand(connStr, conn);

                        cmd.ExecuteNonQuery();

                    }
                    catch (Exception error)
                    {
                        MessageBox.Show(error.Message);
                    }
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }

                    FormGame game = new FormGame();
                    game.Show();
                    this.Close();
                }
                else if (head_x + 30 > this.Width)
                {
                    timer1.Stop();
                    timer2.Stop();
                    timer3.Stop();
                    replay();
                    akhir = nama2;
                    musik.Stop();
                    MessageBox.Show(akhir + "\nGame Over\nScore = " + score.ToString());

                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    conn.Open();

                    try
                    {
                        connStr = "INSERT INTO skor(id,nama,score,kesulitan,tanggal) VALUES( " + data.ToString() + ",'" + akhir + "'," + score.ToString() + ",1,GETDATE())";
                        cmd = new SqlCommand(connStr, conn);

                        cmd.ExecuteNonQuery();

                    }
                    catch (Exception error)
                    {
                        MessageBox.Show(error.Message);
                    }
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }

                    FormGame game = new FormGame();
                    game.Show();
                    this.Close();
                }
                else if (head_y + 30 > this.Height)
                {
                    timer1.Stop();
                    timer2.Stop();
                    timer3.Stop();
                    replay();
                    akhir = nama2;
                    musik.Stop();
                    MessageBox.Show(akhir + "\nGame Over\nScore = " + score.ToString());

                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    conn.Open();

                    try
                    {
                        connStr = "INSERT INTO skor(id,nama,score,kesulitan,tanggal) VALUES( " + data.ToString() + ",'" + akhir + "'," + score.ToString() + ",1,GETDATE())";
                        cmd = new SqlCommand(connStr, conn);

                        cmd.ExecuteNonQuery();

                    }
                    catch (Exception error)
                    {
                        MessageBox.Show(error.Message);
                    }
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }

                    FormGame game = new FormGame();
                    game.Show();
                    this.Close();
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
            if (y < 0)
            {
                ular.Enqueue("up");
                head = new Bitmap(Resource1.head_up);
            }
            else if (y > 0)
            {
                ular.Enqueue("down");
                head = new Bitmap(Resource1.head_down);
            }
            else if (x < 0)
            {
                ular.Enqueue("left");
                head = new Bitmap(Resource1.head_left);
            }
            else if (x > 0)
            {
                ular.Enqueue("right");
                head = new Bitmap(Resource1.head_right);
            }
            if (blink <= 50)//ubah angka kalau timer2 ticknya ditambah please
            {
                if (blink >= 35)
                {
                    idxapple++;
                    if (idxapple >= 3)//reset index buat gak error, disesuaikan dengan jumlah array apple
                    {
                        idxapple = 0;
                    }
                }
            }
            else
            {
                blink = 0;
            }
            replay_x.Enqueue(head_x);
            replay_y.Enqueue(head_y);
            cekeat();//untuk cek udah makan atau belum
            Invalidate();
        }

        private void replay()
        {
            XmlWriterSettings set = new XmlWriterSettings();
            set.Indent = true;
            XmlWriter write = XmlWriter.Create(Application.StartupPath + "\\" + data.ToString() + ".xml", set);
            write.WriteStartDocument();
            write.WriteStartElement("replay");
            write.WriteElementString("wall", "0");
            write.WriteStartElement("ular");
            while (replay_x.Count > 0)
            {
                write.WriteElementString("x", replay_x.Dequeue().ToString());
                write.WriteElementString("y", replay_y.Dequeue().ToString());
                write.WriteElementString("kepala", ular.Dequeue().ToString());
            }
            write.WriteEndElement();
            write.WriteStartElement("apple");
            while (apple_x.Count > 0)
            {
                write.WriteElementString("apple_x", apple_x.Dequeue().ToString());
                write.WriteElementString("apple_y", apple_y.Dequeue().ToString());
                write.WriteElementString("warna", warna.Dequeue().ToString());
            }
            write.WriteEndElement();
            write.WriteEndElement();
            write.WriteEndDocument();
            write.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (gamesound == 1)
            {
                pictureBox1.BackgroundImage = Resource1.soundOff;
                gamesound = 2;
                musik.Stop();
            }
            else if (gamesound == 2)
            {
                pictureBox1.BackgroundImage = Resource1.soundOn;
                gamesound = 1;
                musik.Play();
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
            bool spawn = false;
            while (!spawn)
            {
                spawn = true;
                //random lokasi
                //ini tak ubah supaya muncul di dalam box
                xaple = rnd.Next(60, 755 - 75);
                yaple = rnd.Next(60, 755 - 75);

                //random warna
                jenisaple = rnd.Next(0, 4);

                food = new Rectangle(xaple, yaple, 40, 40);
                ctr = 0;
                //untuk reset blink
                blink = 0;
                idxapple = 0;
                Rectangle handler = new Rectangle(head_x, head_y, 40, 40);
                if (handler.IntersectsWith(food))
                {
                    spawn = false;
                }
                handler = new Rectangle(tail_x, tail_y, 40, 40);
                if (handler.IntersectsWith(food))
                {
                    spawn = false;
                }
                for (int i = 0; i < b.Count; i++)
                {
                    handler = new Rectangle(left[i], top[i], 40, 40);
                    if (handler.IntersectsWith(food))
                    {
                        spawn = false;
                    }
                }
            }
            apple_x.Enqueue(xaple);
            apple_y.Enqueue(yaple);
            warna.Enqueue(jenisaple);
            timer3.Stop();
        }

        private void FormPermainanSedang_KeyDown(object sender, KeyEventArgs e)
        {
            if (turn)
            {
                if ((e.KeyCode == Keys.W || e.KeyCode == Keys.Up) && y == 0 && head_x >= 0 && head_x <= this.Width)
                {
                    y = -30;
                    x = 0;
                    turn = false;
                }
                else if ((e.KeyCode == Keys.A || e.KeyCode == Keys.Left) && x == 0 && head_y >= 0 && head_y <= this.Height)
                {
                    x = -30;
                    y = 0;
                    turn = false;
                }
                else if ((e.KeyCode == Keys.D || e.KeyCode == Keys.Right) && x == 0 && head_y >= 0 && head_y <= this.Height)
                {
                    x = 30;
                    y = 0;
                    turn = false;
                }
                else if ((e.KeyCode == Keys.S || e.KeyCode == Keys.Down) && y == 0 && head_x >= 0 && head_x <= this.Width)
                {
                    y = 30;
                    x = 0;
                    turn = false;
                }
            }
        }

        

        private void FormPermainanSedang_Paint(object sender, PaintEventArgs e)
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

            //blink
            if (jenisaple == 0)
            {
                apple[0] = new Bitmap(Resource1.applered);
                apple[1] = new Bitmap(Resource1.bgproyek);//kalau bisa cariin gambar buat blinknya
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
            else if (jenisaple == 2 )
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

        private void cekeat()//mengecek apakah apple telah dimakan
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
                else if (jenisaple == 3 ^ jenisaple == 4)
                {
                    bomb = true;
                    score -= 10;
                }
                label_skor.Text = "SCORE = " + score.ToString();
                timer3.Start();
                ctr = 0;
                //blink reset ketika dimakan
                idxapple = 0;
                blink = 0;
            }

        }

    }
}
