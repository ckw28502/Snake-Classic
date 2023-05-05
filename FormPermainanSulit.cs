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
using System.Xml;

namespace Tugas_Proyek
{
    public partial class FormPermainanSulit : Form
    {
        
        public FormPermainanSulit()
        {
            InitializeComponent();
        }

        public static string nama3 = "";

        String connStr;
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader reader;
        int data;

        string akhir;
        Graphics g;
        //random rintangan
        Bitmap[] rintangan;
        List<Rectangle> listrintangan = new List<Rectangle>();
        //apple
        Random rnd = new Random();
        int xaple, yaple, jenisaple, ctr;
        //blink
        int idxapple, blink;
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
        private void FormPermainanSulit_Load(object sender, EventArgs e)
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
            // nambah gambar lewat sini
            ctr = 0;
            blink = 0;
            idxapple = 0;
            apple = new Bitmap[4];
            apple[0] = new Bitmap(Resource1.applegreen);
            apple[1] = new Bitmap(Resource1.applered);
            apple[2] = new Bitmap(Resource1.applegold);
            apple[3] = new Bitmap(Resource1.Bombnew);
            DoubleBuffered = true;
            
            //rintangan
            rintangan = new Bitmap[1];
            rintangan[0] = new Bitmap(Resource1.rintangan);
            // konsep e di tumpuk jdi gambar jelek di tumpuk sama label nya biar bagus tapi ttp pake point ini kalo ular mau makan
            listrintangan.Add(new Rectangle(29,57,188,40)); //kiri atas
            listrintangan.Add(new Rectangle(29,97,40,178));// kiri atas (bawah e)
            listrintangan.Add(new Rectangle(539, 57, 188, 40)); //kanan atas
            listrintangan.Add(new Rectangle(687, 97, 40, 178)); //kanan atas (bawah e)

            listrintangan.Add(new Rectangle(29, 489, 40, 178)); //kiri bawah
            listrintangan.Add(new Rectangle(29, 667, 188, 40)); //kiri bawah
            listrintangan.Add(new Rectangle(539, 667, 188, 40)); //kanan bawah
            listrintangan.Add(new Rectangle(687, 489, 40, 178)); //kanan bawah

            listrintangan.Add(new Rectangle(275, 235, 188, 40)); //tengah atas
            listrintangan.Add(new Rectangle(275, 275, 43, 64)); //tengah kiri atas
            listrintangan.Add(new Rectangle(180, 299, 138, 40)); //tengah kiri
            listrintangan.Add(new Rectangle(420, 275, 43, 64)); //tengah kanan atas
            listrintangan.Add(new Rectangle(420, 299, 138, 40)); //tengah kanan

            listrintangan.Add(new Rectangle(275, 489, 188, 40)); //tengah bawah
            listrintangan.Add(new Rectangle(275, 425, 43, 64)); //tengah kiri bawah
            listrintangan.Add(new Rectangle(180, 425, 138, 40)); //tengah kiri
            listrintangan.Add(new Rectangle(420, 425, 43, 64)); //tengah kanan atas
            listrintangan.Add(new Rectangle(420, 425, 138, 40)); //tengah kanan

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

        private void timer2_Tick(object sender, EventArgs e)
        {
            ctr++;
            // cepetno buah biar keluar e cepet
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
                foreach (Rectangle item in listrintangan)
                {
                    if (item.IntersectsWith(food))
                    {
                        spawn = false;
                    }
                }
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

        private void FormPermainanSulit_KeyDown(object sender, KeyEventArgs e)
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
                    akhir = nama3;
                    musik.Stop();
                    MessageBox.Show(akhir + "\nGame Over\nScore = " + score.ToString());
                    

                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    conn.Open();

                    try
                    {
                        connStr = "INSERT INTO skor(id,nama,score,kesulitan,tanggal) VALUES( " + data.ToString() + ",'" + akhir + "'," + score.ToString() + ",2,GETDATE())";
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
                replay();
                akhir = nama3;
                musik.Stop();
                MessageBox.Show(akhir + "\nGame Over\nScore = " + score.ToString());

                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                conn.Open();

                try
                {
                    connStr = "INSERT INTO skor(id,nama,score,kesulitan,tanggal) VALUES( " + data.ToString() + ",'" + akhir + "'," + score.ToString() + ",2,GETDATE())";
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
                if (crash)
                {
                    timer1.Stop();
                    timer2.Stop();
                    timer3.Stop();
                    replay();
                    akhir = nama3;
                    musik.Stop();
                    MessageBox.Show(akhir + "\nGame Over\nScore = " + score.ToString());

                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    conn.Open();

                    try
                    {
                        connStr = "INSERT INTO skor(id,nama,score,kesulitan,tanggal) VALUES( " + data.ToString() + ",'" + akhir + "'," + score.ToString() + ",2,GETDATE())";
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
                else if (eat)
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
                            akhir = nama3;
                            musik.Stop();
                            MessageBox.Show(akhir + "\nGame Over\nScore = " + score.ToString());

                            if (conn.State == ConnectionState.Open)
                            {
                                conn.Close();
                            }
                            conn.Open();

                            try
                            {
                                connStr = "INSERT INTO skor(id,nama,score,kesulitan,tanggal) VALUES( " + data.ToString() + ",'" + akhir + "'," + score.ToString() + ",2,GETDATE())";
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
                    tail_x = left[0];
                    tail_y = top[0];
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
                    akhir = nama3;
                    musik.Stop();
                    MessageBox.Show(akhir + "\nGame Over\nScore = " + score.ToString());

                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    conn.Open();

                    try
                    {
                        connStr = "INSERT INTO skor(id,nama,score,kesulitan,tanggal) VALUES( " + data.ToString() + ",'" + akhir + "'," + score.ToString() + ",2,GETDATE())";
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
                    akhir = nama3;
                    musik.Stop();
                    MessageBox.Show(akhir + "\nGame Over\nScore = " + score.ToString());

                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    conn.Open();

                    try
                    {
                        connStr = "INSERT INTO skor(id,nama,score,kesulitan,tanggal) VALUES( " + data.ToString() + ",'" + akhir + "'," + score.ToString() + ",2,GETDATE())";
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
                    akhir = nama3;
                    musik.Stop();
                    MessageBox.Show(akhir + "\nGame Over\nScore = " + score.ToString());

                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    conn.Open();

                    try
                    {
                        connStr = "INSERT INTO skor(id,nama,score,kesulitan,tanggal) VALUES( " + data.ToString() + ",'" + akhir + "'," + score.ToString() + ",2,GETDATE())";
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
                    akhir = nama3;
                    musik.Stop();
                    MessageBox.Show(akhir + "\nGame Over\nScore = " + score.ToString());

                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    conn.Open();

                    try
                    {
                        connStr = "INSERT INTO skor(id,nama,score,kesulitan,tanggal) VALUES( " + data.ToString() + ",'" + akhir + "'," + score.ToString() + ",2,GETDATE())";
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
            if (blink<=10)//ubah angka kalau timer2 ticknya ditambah
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
            replay_x.Enqueue(head_x);
            replay_y.Enqueue(head_y);
            cekeat();//untuk cek udah makan atau belum
            //yang dibawah ini di uncommment kalau mau cek tembok , masih gak sama dengan di form replay kalau bisa di bantu bikin lebih baik -Alan
            //cekapple();//untuk cek makanan kena tembok atau gak
            Invalidate();
        }

        private void replay()
        {
            XmlWriterSettings set = new XmlWriterSettings();
            set.Indent = true;
            XmlWriter write = XmlWriter.Create(Application.StartupPath + "\\" + data.ToString() + ".xml", set);
            write.WriteStartDocument();
            write.WriteStartElement("replay");
            write.WriteElementString("wall", "1");
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

        private void FormPermainanSulit_Paint(object sender, PaintEventArgs e)
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
            //rintangan
            //masih coba coba
            Graphics a = e.Graphics;
            foreach (Rectangle x in listrintangan)
            {
                a.DrawImage(rintangan[0], x);
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

        bool bomb = false;
        bool crash = false;
        private void cekeat()//mengecek apakah apple telah dimakan
        {
            Rectangle handler = new Rectangle(head_x, head_y, 40, 40);
            foreach (Rectangle item in listrintangan)
            {
                if (handler.IntersectsWith(item))
                {
                    crash = true;
                }
            }
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
        private void cekapple()
        {
            foreach (Rectangle obs in listrintangan)//obstacle diganti dengan nama list obstacle yang dibuat
            {
                if (obs.IntersectsWith(food))
                {
                    timer3.Start();
                    ctr = 0;

                    //blink reset ketika dimakan
                    idxapple = 0;
                    blink = 0;
                }
            }

        }

    }
}
