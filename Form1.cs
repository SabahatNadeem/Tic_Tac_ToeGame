using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using Microsoft.Win32;
 using System.Data.OleDb;
 using System.Speech;
  using System.Speech.Synthesis;
        using System.Media;

namespace tic_tac_toe_final_project
{
    public partial class Form1 : Form
    {
        System.Media.SoundPlayer player = new System.Media.SoundPlayer();
        bool turn = true;
        int turn_count = 0;
        int score1 = 0, score2 = 0;
        public Form1()
        {
            InitializeComponent();
            player.SoundLocation = "PimPoy.wav";
        }
        SpeechSynthesizer reader = new SpeechSynthesizer();
        Button b1 = new Button();
        Button b2 = new Button();
        Button b3 = new Button();
        Button b4 = new Button();
        Button b5 = new Button();
        Button b6 = new Button();
        Button b7 = new Button();
        Button b8 = new Button();
        Button b9 = new Button();
        Label l5 = new Label();
        Label l6 = new Label();
       /* private void computer_make_move()
        {
            Button move = null;
            move = look_for_win_or_block("O"); //look for win
            if (move == null)
            {
                move = look_for_win_or_block("X"); //look for block
                if (move == null)
                {
                    move = look_for_corner();
                    if (move == null)
                    {
                        move = look_for_open_space();
                    }//end if
                }//end if
            }//end if

            move.PerformClick();
        }
        private Button look_for_win_or_block()
        {
            if (b1.Text == mark)
            {


            }
        }
        private Button look_for_corner()
        {
            Console.WriteLine("Looking for corner");
            if (b1.Text == "O")
            {
                if (b3.Text == "")
                    return b3;
                if (b9.Text == "")
                    return b9;
                if (b7.Text == "")
                    return b7;
            }

            if (b3.Text == "O")
            {
                if (b1.Text == "")
                    return b1;
                if (b9.Text == "")
                    return b9;
                if (b7.Text == "")
                    return b7;
            }

            if (b9.Text == "O")
            {
                if (b1.Text == "")
                    return b3;
                if (b3.Text == "")
                    return b3;
                if (b7.Text == "")
                    return b7;
            }

            if (b7.Text == "O")
            {
                if (b1.Text == "")
                    return b3;
                if (b3.Text == "")
                    return b3;
                if (b9.Text == "")
                    return b9;
            }

            if (b1.Text == "")
                return b1;
            if (b3.Text == "")
                return b3;
            if (b7.Text == "")
                return b7;
            if (b9.Text == "")
                return b9;

            return null;
        }*/
        private void check_for_winner()
        {
            bool there_is_a_winner = false;
            //.............................................................horizontal    checks..................................///
            if ((b1.Text == b2.Text) && (b2.Text == b3.Text) && (!b1.Enabled))
            {
                there_is_a_winner = true;
                b1.BackColor = Color.Green;
                b2.BackColor = Color.Green;
                b3.BackColor = Color.Green;
            }
            else if ((b4.Text == b5.Text) && (b5.Text == b6.Text) && (!b4.Enabled))
            {
                there_is_a_winner = true;
                b4.BackColor = Color.Green;
                b5.BackColor = Color.Green;
                b6.BackColor = Color.Green;
            }
            else if ((b7.Text == b8.Text) && (b8.Text == b9.Text) && (!b7.Enabled))
            {
                there_is_a_winner = true;
                b7.BackColor = Color.Green;
                b8.BackColor = Color.Green;
                b9.BackColor = Color.Green;
            }
            //.................................................................Vertical   checks.................................................//
            else if ((b1.Text == b4.Text) && (b4.Text == b7.Text) && (!b1.Enabled))
            {
                there_is_a_winner = true;
                b1.BackColor = Color.Green;
                b4.BackColor = Color.Green;
                b7.BackColor = Color.Green;
            }
            else if ((b2.Text == b5.Text) && (b5.Text == b8.Text) && (!b2.Enabled))
            {
                there_is_a_winner = true;
                b5.BackColor = Color.Green;
                b2.BackColor = Color.Green;
                b8.BackColor = Color.Green;
            }
            else if ((b3.Text == b6.Text) && (b6.Text == b9.Text) && (!b3.Enabled))
            {
                there_is_a_winner = true;
                b6.BackColor = Color.Green;
                b9.BackColor = Color.Green;
                b3.BackColor = Color.Green;
            }
            //.................................................................Diagonal checks...............................................//
            else if ((b1.Text == b5.Text) && (b5.Text == b9.Text) && (!b1.Enabled))
            {
                there_is_a_winner = true;
                b1.BackColor = Color.Green;
                b5.BackColor = Color.Green;
                b9.BackColor = Color.Green;
            }
            else if ((b3.Text == b5.Text) && (b5.Text == b7.Text) && (!b3.Enabled))
            {
                there_is_a_winner = true;
                b5.BackColor = Color.Green;
                b7.BackColor = Color.Green;
                b3.BackColor = Color.Green;
            }

            if (there_is_a_winner)
            {
                disable_buttons();
                string winner = "";
                if (turn)
                {
                    winner = "O";
                    score2++;
                }
                else
                {
                    winner = "X";
                    score1++;
                }


                MessageBox.Show(winner + " Wins!");
                update_score();
            }
            else
            {
                if(turn_count==9)
                {
                    MessageBox.Show("Draw!");
                }
            }
        }
        private void update_score()
        {
            l5.Text = score1.ToString();
            l6.Text = score2.ToString();
        }
        private void disable_buttons()
        {
            b1.Enabled = false;
            b2.Enabled = false;
            b3.Enabled = false;
            b4.Enabled = false;
            b5.Enabled = false;
            b6.Enabled = false;
            b7.Enabled = false;
            b8.Enabled = false;
            b9.Enabled = false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            reader.Dispose();
            reader = new SpeechSynthesizer();
            reader.SpeakAsync("welcome to tic tac toe, let's play!");
            label1.BackColor = Color.Transparent;
            label1.Text = "Tic Tac Toe";
            label1.ForeColor = Color.White;
            WindowState = FormWindowState.Maximized;
            label1.Location = new Point(200, 300);
            label1.Size = new Size(400, 200);
            label1.Font = new Font("Showcard Gothic", 45.7f);
            button1.BackColor = Color.Plum;
            button1.Text = "Play";
            button1.FlatStyle = FlatStyle.Popup;
            button1.Location = new Point(400, 400);
            button1.Size = new Size(250, 80);
            button1.Font = new Font("Showcard Gothic", 25.7f);
           
         }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, Color.Aquamarine, Color.SteelBlue, 50F);
            e.Graphics.FillRectangle(brush, this.ClientRectangle);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            button1.Enabled = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
          player.PlayLooping();
           
            label1.Hide();
            button1.Hide();
          
            b1.Show();
            b2.Show();
            b3.Show();
            b4.Show();
            b5.Show();
            b6.Show();
            b7.Show();
            b8.Show();
            b9.Show();
            b1.BackColor = Color.Silver;
            b2.BackColor = Color.Silver;
            b3.BackColor = Color.Silver;
            b4.BackColor = Color.Silver;
            b5.BackColor = Color.Silver;
            b6.BackColor = Color.Silver;
            b7.BackColor = Color.Silver;
            b8.BackColor = Color.Silver;
            b9.BackColor = Color.Silver;
            b1.Size = new Size(150, 150);
            b2.Size = new Size(150, 150);
            b3.Size = new Size(150, 150);
            b4.Size = new Size(150, 150);
            b5.Size = new Size(150, 150);
            b6.Size = new Size(150, 150);
            b7.Size = new Size(150, 150);
            b8.Size = new Size(150, 150);
            b9.Size = new Size(150, 150);
            b1.Location = new Point(300, 100);
            b2.Location = new Point(480, 100);
            b3.Location = new Point(660, 100);
            b4.Location = new Point(300, 280);
            b5.Location = new Point(480, 280);
            b6.Location = new Point(660, 280);
            b7.Location = new Point(300, 460);
            b8.Location = new Point(480, 460);
            b9.Location = new Point(660, 460);
            b1.Font = new Font("Showcard Gothic", 39.7f);
            b2.Font = new Font("Showcard Gothic", 39.7f);
            b3.Font = new Font("Showcard Gothic", 39.7f);
            b4.Font = new Font("Showcard Gothic", 39.7f);
            b5.Font = new Font("Showcard Gothic", 39.7f);
            b6.Font = new Font("Showcard Gothic", 39.7f);
            b7.Font = new Font("Showcard Gothic", 39.7f);
            b8.Font = new Font("Showcard Gothic", 39.7f);
            b9.Font = new Font("Showcard Gothic", 39.7f);
            Button b10 = new Button();
            Button b11 = new Button();
            Button b12 = new Button();
            Button b13 = new Button();
            b10.Text = "New game";
            b11.Text = "Exit";
            b12.Text = "Reset";
            b13.Text = "Stop,Resume music";
            
            b10.BackColor = Color.Orange;
            b11.BackColor = Color.Orange;
            b12.BackColor = Color.Orange;
            b13.BackColor = Color.Orange;

            b10.FlatStyle = FlatStyle.Popup;
            b11.FlatStyle = FlatStyle.Popup;
            b12.FlatStyle = FlatStyle.Popup;
            b13.FlatStyle = FlatStyle.Popup;

            b10.Location = new Point(1000, 500);
            b13.Location = new Point(1180, 600);

            b11.Location = new Point(1000, 600);
            b12.Location = new Point(1180, 500);
            b10.Size = new Size(150, 80);
            b11.Size = new Size(150, 80);
            b12.Size = new Size(150, 80);
            b13.Size = new Size(150, 120);

            b10.Font = new Font("Showcard Gothic", 19.7f);
            b11.Font = new Font("Showcard Gothic", 19.7f);
            b13.Font = new Font("Showcard Gothic", 19.7f);

            b10.ForeColor = SystemColors.ButtonFace;
            b13.ForeColor = SystemColors.ButtonFace;

            b11.ForeColor = SystemColors.ButtonFace;
            b12.Font = new Font("Showcard Gothic", 19.7f);
            b12.ForeColor = SystemColors.ButtonFace;
            Label l1 = new Label();
            Label l2 = new Label();
            Label l3 = new Label();
            Label l4 = new Label();
            l1.Location = new Point(1000, 50);
            l1.Size = new Size(250, 50);
            l1.Font = new Font("Showcard Gothic", 20.7f);
            l1.Text = "Turn";
            l1.TextAlign = ContentAlignment.MiddleCenter;
            l1.BackColor = Color.Orange;
            l1.ForeColor = Color.White;
            l2.Location = new Point(1000, 100);
            l2.Size = new Size(250, 50);
            l2.Font = new Font("Calibri", 20.7f);
            l2.TextAlign = ContentAlignment.MiddleCenter;
            l2.BackColor = Color.White;
            l2.ForeColor = Color.Black;
            l3.Location = new Point(980, 250);
            l3.Size = new Size(150, 50);
            l3.Font = new Font("Showcard Gothic", 20.7f);
            l3.Text = "Player 1";
            l3.TextAlign = ContentAlignment.MiddleCenter;
            l3.BackColor = Color.Green;
            l3.ForeColor = Color.White;
            l4.Location = new Point(1130, 250);
            l4.Size = new Size(150, 50);
            l4.Font = new Font("Showcard Gothic", 20.7f);
            l4.Text = "Player 2";
            l4.TextAlign = ContentAlignment.MiddleCenter;
            l4.BackColor = Color.Green;
            l4.ForeColor = Color.White;
            l5.Location = new Point(980, 300);
            l5.Size = new Size(150, 80);
            l5.Font = new Font("Calibri", 30.7f);
            l5.Text = score1.ToString();
            l5.TextAlign = ContentAlignment.MiddleCenter;
            l5.BackColor = Color.White;
            l5.ForeColor = Color.Black;
            l6.Location = new Point(1130, 300);
            l6.Size = new Size(150, 80);
            l6.Font = new Font("Calibri", 30.7f);
            l6.Text = score2.ToString();
            l6.TextAlign = ContentAlignment.MiddleCenter;
            l6.BackColor = Color.White;
            l6.ForeColor = Color.Black;
            if (turn)
                l2.Text = "Player 1";
            if (!turn)
                l2.Text = "Player 2";
            this.Controls.Add(b1);
            this.Controls.Add(b2);
            this.Controls.Add(b3);
            this.Controls.Add(b4);
            this.Controls.Add(b5);
            this.Controls.Add(b6);
            this.Controls.Add(b7);
            this.Controls.Add(b8);
            this.Controls.Add(b9);
            this.Controls.Add(b10);
            this.Controls.Add(b11);
            this.Controls.Add(b12);
            this.Controls.Add(b13);

            this.Controls.Add(l1);
            this.Controls.Add(l2);
            this.Controls.Add(l3);
            this.Controls.Add(l4);
            this.Controls.Add(l5);
            this.Controls.Add(l6);
            b1.Click += delegate
            {
                if (!turn)
                    l2.Text = "Player 1";
                else
                    l2.Text = "Player 2";
                if (turn)
                    b1.Text = "X";
                else
                    b1.Text = "O";
                turn = !turn;
                b1.Enabled = false;
                turn_count++;
                check_for_winner();
            };
            b2.Click += delegate
            {
                if (!turn)
                    l2.Text = "Player 1";
                else
                    l2.Text = "Player 2";
                if (turn)
                    b2.Text = "X";
                else
                    b2.Text = "O";
                turn = !turn;
                b2.Enabled = false;
                turn_count++;
                check_for_winner();
            };
            b3.Click += delegate
            {
                if (!turn)
                    l2.Text = "Player 1";
                else
                    l2.Text = "Player 2";
                if (turn)
                    b3.Text = "X";
                else
                    b3.Text = "O";
                turn = !turn;
                b3.Enabled = false;
                turn_count++;
                check_for_winner();
            };

            b4.Click += delegate
            {
                if (!turn)
                    l2.Text = "Player 1";
                else
                    l2.Text = "Player 2";
                if (turn)
                    b4.Text = "X";
                else
                    b4.Text = "O";
                turn = !turn;
                b4.Enabled = false;
                turn_count++;
                check_for_winner();
            };
            b5.Click += delegate
            {
                if (!turn)
                    l2.Text = "Player 1";
                else
                    l2.Text = "Player 2";
                if (turn)
                    b5.Text = "X";
                else
                    b5.Text = "O";
                turn = !turn;
                b5.Enabled = false;
                turn_count++;
                check_for_winner();
            };
            b6.Click += delegate
            {
                if (!turn)
                    l2.Text = "Player 1";
                else
                    l2.Text = "Player 2";
                if (turn)
                    b6.Text = "X";
                else
                    b6.Text = "O";
                turn = !turn;
                b6.Enabled = false;
                turn_count++;
                check_for_winner();
            };

            b7.Click += delegate
            {
                if (!turn)
                    l2.Text = "Player 1";
                else
                    l2.Text = "Player 2";
                if (turn)
                    b7.Text = "X";
                else
                    b7.Text = "O";
                turn = !turn;
                b7.Enabled = false;
                turn_count++;
                check_for_winner();
            };
            b8.Click += delegate
            {
                if (!turn)
                    l2.Text = "Player 1";
                else
                    l2.Text = "Player 2";
                if (turn)
                    b8.Text = "X";
                else
                    b8.Text = "O";
                turn = !turn;
                b8.Enabled = false;
                turn_count++;
                check_for_winner();
            };
            b9.Click += delegate
            {
                if (!turn)
                    l2.Text = "Player 1";
                else
                    l2.Text = "Player 2";
                if (turn)
                    b9.Text = "X";
                else
                    b9.Text = "O";
                turn = !turn;
                b9.Enabled = false;
                turn_count++;
                check_for_winner();
            };
            b10.Click += delegate
            {
                turn = true;
                turn_count = 0;
                if (turn)
                    l2.Text = "Player 1";
                else
                    l2.Text = "Player 2";
                b1.Enabled = true;
                b2.Enabled = true;
                b3.Enabled = true;
                b4.Enabled = true;
                b5.Enabled = true;
                b6.Enabled = true;
                b7.Enabled = true;
                b8.Enabled = true;
                b9.Enabled = true;
                b1.Text = "";
                b2.Text = "";
                b3.Text = "";
                b4.Text = "";
                b5.Text = "";
                b6.Text = "";
                b7.Text = "";
                b8.Text = "";
                b9.Text = "";
                b1.BackColor = Color.Silver;
                b2.BackColor = Color.Silver;
                b3.BackColor = Color.Silver;
                b4.BackColor = Color.Silver;
                b5.BackColor = Color.Silver;
                b6.BackColor = Color.Silver;
                b7.BackColor = Color.Silver;
                b8.BackColor = Color.Silver;
                b9.BackColor = Color.Silver;
            };
            b13.Click += delegate
            {
               
                   player.Stop();
               
                

            };

            b11.Click += delegate
            {
                Application.Exit(); 
            };
            b12.Click += delegate
            {
                score1 = 0;
                score2 = 0;
                update_score();
                turn = true;
                turn_count = 0;
                if (turn)
                    l2.Text = "Player 1";
                else
                    l2.Text = "Player 2";
                b1.Enabled = true;
                b2.Enabled = true;
                b3.Enabled = true;
                b4.Enabled = true;
                b5.Enabled = true;
                b6.Enabled = true;
                b7.Enabled = true;
                b8.Enabled = true;
                b9.Enabled = true;
                b1.Text = "";
                b2.Text = "";
                b3.Text = "";
                b4.Text = "";
                b5.Text = "";
                b6.Text = "";
                b7.Text = "";
                b8.Text = "";
                b9.Text = "";
                b1.BackColor = Color.Silver;
                b2.BackColor = Color.Silver;
                b3.BackColor = Color.Silver;
                b4.BackColor = Color.Silver;
                b5.BackColor = Color.Silver;
                b6.BackColor = Color.Silver;
                b7.BackColor = Color.Silver;
                b8.BackColor = Color.Silver;
                b9.BackColor = Color.Silver;
            };
        }
    }
}
