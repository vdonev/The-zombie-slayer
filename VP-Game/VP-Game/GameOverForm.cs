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

namespace VP_Game
{
    public partial class GameOverForm : Form
    {
        private int score;
        public GameOverForm(int score)
        {
            InitializeComponent();
            this.score = score;
            label2.Text = "Your score was : " + score;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            File.AppendAllText("scores.txt",name+","+score+"\n");
            this.Close();
            DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            File.AppendAllText("scores.txt", name + "," + score + "\n");
            this.Close();
            DialogResult = DialogResult.Cancel;
        }
    }
}
