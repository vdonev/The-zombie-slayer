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
    public partial class HighScores : Form
    {
        public HighScores()
        {
            InitializeComponent();
            List<Score> Scores = new List<Score>();
            StreamReader reader = new StreamReader("scores.txt");
            string line;
            while((line = reader.ReadLine()) != null)
            {
                string name = line.Split(',')[0];
                int score = Int32.Parse(line.Split(',')[1]);
                Scores.Add(new Score(name,score));
            }
            List<Score> SortedList = Scores.OrderBy(o => o.getPoints()).Reverse().ToList();
            foreach (Score s in SortedList)
            {
                listBox1.Items.Add(s);
            }
            
        }

        
    }
}
