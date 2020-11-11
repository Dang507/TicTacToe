using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace coCaroForm
{
    public partial class Form1 : Form
    {
        bool turn = true;
        int turn_cout = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn )
              
                b.Text = "X";
            else
                b.Text = "O";
            turn = !turn;
            b.Enabled = false;
            turn_cout++;
            checkWinner();
            
        }
        private void checkWinner ()
        {
            bool winner = false;
            //check ngang

            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
                     winner = true;
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
                     winner = true;
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
                     winner = true;

            //check doc

            if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
                winner = true;
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
                winner = true;
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
                winner = true;

            //check cheo

            if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
                winner = true;         
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!C1.Enabled))
                winner = true;
            if (winner)
            {
                
                String slogan = "";
                if (turn)
                    slogan = "O";
                else
                    slogan = "X";
                disbaleBtn();
                MessageBox.Show(slogan + " Win òi", " Yeah !!!");
            }
            else
            {
                if (turn_cout == 9)
                    MessageBox.Show("Draw", "Again");
            }

        }

        private void disbaleBtn ()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }
            }
            catch { }
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;
            turn_cout = 0; 
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                }
            }
            catch { }


        }

        private void mouse_enter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
                if (b.Enabled)
                {
                    if (turn)

                        b.Text = "X";
                    else
                        b.Text = "O";
            }
        }

        private void mouse_leave(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
            {
                b.Text = "";
            }
        }
    }
}
