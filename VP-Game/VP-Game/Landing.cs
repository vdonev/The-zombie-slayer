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
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace VP_Game
{
    public partial class Landing : Form
    {
        private string FileName;
        private Scene Scene;
        public Landing()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Scene s = null;
            Form1 f1 = new Form1(s, "Untitled");
            f1.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Instructions f3 = new Instructions();
            f3.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HighScores hs = new HighScores();
            hs.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFile();
        }

        private void openFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Game file (*.game)|*.game";
            openFileDialog.Title = "Open game file";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileName = openFileDialog.FileName;
                try
                {
                    using (FileStream fileStream = new FileStream(FileName, FileMode.Open))
                    {
                        IFormatter formater = new BinaryFormatter();
                        Scene = (Scene)formater.Deserialize(fileStream);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Could not read file: " + FileName);
                    FileName = null;
                    return;
                }

                Form1 f1 = new Form1(Scene,FileName);
                f1.ShowDialog();
            }
        }

        
    }
}
