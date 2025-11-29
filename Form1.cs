using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tic_Tak_Toy.Properties;

namespace Tic_Tak_Toy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        stGameStatus GameStatus;
        enPlayer PlayerTurn = enPlayer.Player1;
       
        enum enPlayer { Player1, Player2}
        enum enWinner { Player1, Player2, Draw, InProgres}

        struct stGameStatus 
        { 
          public  enWinner Winner;
          public  short PlayCount;
          public  bool GameOver;
        }
  
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Color White = Color.White;

            Pen Pen = new Pen(White);
            Pen.Width = 15;


            Pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            Pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;


            //vertical
            e.Graphics.DrawLine(Pen, 600, 110, 600, 570);
            e.Graphics.DrawLine(Pen, 790, 110, 790, 570);

            //horizantol
            e.Graphics.DrawLine(Pen, 410, 263, 970, 263);
            e.Graphics.DrawLine(Pen, 410, 415, 970, 415);
           
        }


        void EndGame ()
        {
            lblTurn.Text = "Game Over";

            switch(GameStatus.Winner)
            {
                case enWinner.Player1:
                    lblWinner.Text = "Player1";
                    break;

                case enWinner.Player2:
                    lblWinner.Text = "Player2";
                    break ;

                default:
                    lblWinner.Text = "Draw";
                    break;
            }

            MessageBox.Show("GameOver", "GameOver", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }
        private bool CheckValues(Button btn1, Button btn2, Button btn3)
        {

            if (btn1.Tag.ToString() != "?" && btn1.Tag.ToString() == btn2.Tag.ToString() && btn1.Tag.ToString() == btn3.Tag.ToString())
            {

                btn1.BackColor = Color.GreenYellow;
                btn2.BackColor = Color.GreenYellow;
                btn3.BackColor = Color.GreenYellow;

                if (btn1.Tag.ToString() == "X")
                {
                    GameStatus.Winner = enWinner.Player1;
                    GameStatus.GameOver = true;
                    EndGame();
                    return true;
                }
                else
                {
                    GameStatus.Winner = enWinner.Player2;
                    GameStatus.GameOver = true;
                    EndGame();
                    return true;

                }
            }


            GameStatus.GameOver = false;
            return false;
        }
        private void CheckWinner ()
        {
            if (CheckValues(btn1, btn2, btn3))
                return;

            if(CheckValues(btn4 , btn5, btn6 ))
                return;

            if(CheckValues(btn7 , btn8, btn9 ))
                return;

            if(CheckValues(btn1 , btn4, btn7 ))
                return;

            if(CheckValues(btn2 , btn5, btn8 ))
                return;

            if(CheckValues(btn3 , btn6, btn9 ))
                return;

            if(CheckValues(btn1 , btn5, btn9 ))
                return;

            if(CheckValues(btn3 , btn5, btn7 ))
                return;


        }
        private void ChangeImage (Button btn)
        {

            if (btn.Tag.ToString() == "?" && GameStatus.GameOver != true)
            {
                switch(PlayerTurn)
                {
                    case enPlayer.Player1:

                        btn.BackgroundImage = Resources.X;
                        PlayerTurn = enPlayer.Player2;
                        btn.Tag = "X";
                        lblTurn.Text = "Player 1";
                        GameStatus.PlayCount++;
                        CheckWinner();

                        break;

                    case enPlayer.Player2:

                        btn.BackgroundImage = Resources.O;
                        PlayerTurn = enPlayer.Player1;
                        btn.Tag = "O";
                        lblTurn.Text = "Player 2";
                        GameStatus.PlayCount++;
                        CheckWinner();

                        break;

                }
            }
            else
            {
                MessageBox.Show("Wrong Choice", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            if (GameStatus.PlayCount == 9)
            {
                GameStatus.GameOver = true;
                GameStatus.Winner = enWinner.Draw;
                EndGame();
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            ChangeImage(btn2);
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            ChangeImage(btn3);
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            ChangeImage(btn4);
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            ChangeImage(btn5);
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            ChangeImage(btn6);
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            ChangeImage(btn7);
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            ChangeImage(btn8);
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            ChangeImage(btn9);
        }

        private void btn1_Click_1(object sender, EventArgs e)
        {
            ChangeImage(btn1);
        }


        void ResetButton(Button btn)
        {
            btn.BackgroundImage = Resources.question_mark_96;
            btn.Tag = "?";
            btn.BackColor = Color.Transparent;
        }

        private void ResetGame()
        {
            ResetButton(btn1);
            ResetButton(btn2);
            ResetButton(btn3);
            ResetButton(btn4);
            ResetButton(btn5);
            ResetButton(btn6);
            ResetButton(btn7);
            ResetButton(btn8);
            ResetButton(btn9);


            GameStatus.Winner = enWinner.InProgres;
            GameStatus.PlayCount = 0;
            GameStatus.GameOver = false;
            PlayerTurn = enPlayer.Player1;
            lblTurn.Text = "Player 1";
            lblWinner.Text = "In Progress";

        }
        private void btn_Restart_Click(object sender, EventArgs e)
        {
            ResetGame();
        }
    }
}
