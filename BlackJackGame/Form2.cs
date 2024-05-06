using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlackJackGame
{
    public partial class Form2 : Form
    {
        Random rnd = new Random();
        public int my_counter = 0;
        public int enemy_counter = 0;
        public int card;
        public int seccard;
        public Form2()
        {
            InitializeComponent();
            button2.Enabled = false;
            this.Height += 145;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.Text = "Hit";
            button2.Enabled = true;
            button3.Enabled = true;
            if (my_counter <= 21)
            {
                int firstCard = rnd.Next(2, 12);
                my_counter += firstCard;
                Cards(firstCard);
                label2.Text = "Your count:" + my_counter;

            }
            else if (my_counter >= 22)
            {
                button3.Enabled = false;
                MessageBox.Show("You've already had more than 21.");

            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button3.Enabled = false;
            int hit = rnd.Next(5, 5);
            for (int i = 0; i < hit; i++)
            {
                int secondcard = rnd.Next(2, 12);
                seccard += secondcard;
                Cards(secondcard);
                label3.Text = "Enemy count:" + seccard;
                await Task.Delay(1500);
                if (seccard >= 17 && seccard <= 21)
                {
                    break;
                }
                if (seccard > 21)
                {
                    break;
                }


            }

            if (seccard > my_counter && seccard < 22)
            {
                LoseMessage();
            }
            else if (seccard == my_counter)
            {
                DialogResult result = MessageBox.Show("It's tie!", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                    BackMenu();
                }
            }
            else if (seccard < my_counter && my_counter < 22)
            {
                WinMessage();
            }
            else if (seccard > 21 && my_counter > 21 && seccard > my_counter)
            {
                WinMessage();
            }
            else if (seccard > 21 && my_counter > 21 && seccard < my_counter)
            {
                LoseMessage();
            }
            else if (seccard > 21 && my_counter < 22)
            {
                WinMessage();
            }
            else if (seccard < 22 && my_counter > 21)
            {
                LoseMessage();
            }
        }
        private void WinMessage()
        {
            DialogResult result = MessageBox.Show("You win!", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                BackMenu();
            }
        }
        private void LoseMessage()
        {
            DialogResult result = MessageBox.Show("You lose!", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                BackMenu();
            }
        }
    
        private void Cards(int num)
        {
            switch (num)
            {
                case 2:
                    pictureBox1.Image = Properties.Resources.two;
                    break;
                case 3:
                    pictureBox1.Image = Properties.Resources.three;
                    break;
                case 4:
                    pictureBox1.Image = Properties.Resources.four;
                    break;
                case 6:
                    pictureBox1.Image = Properties.Resources.six;
                    break;
                case 7:
                    pictureBox1.Image = Properties.Resources.seven;
                    break;
                case 8:
                    pictureBox1.Image = Properties.Resources.eight;
                    break;
                case 9:
                    pictureBox1.Image = Properties.Resources.nine;
                    break;
                case 10:
                    pictureBox1.Image = Properties.Resources.ten;
                    break;
                case 11:
                    pictureBox1.Image = Properties.Resources.tuz;
                    break;
            }
        }
        public void BackMenu()
        {
            Form1 f2 = new Form1();
            this.Hide();
            f2.ShowDialog();
            this.Close();
        }
    }
}