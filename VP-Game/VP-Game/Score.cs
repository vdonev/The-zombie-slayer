using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VP_Game
{
  
    public class Score
    {
        string Name;
        int Points;

        public Score(string n,int p)
        {
            this.Name = n;
            this.Points = p;
        }

        public override string ToString()
        {
            return string.Format("{0}\t\t{1}",Name,Points);
        }

        public int getPoints()
        {
            return Points;
        }
    }
}
