using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VP_Game
{
    public partial class Instructions : Form
    {
        public Instructions()
        {
            InitializeComponent();
            this.MinimizeBox = false;
            this.MaximizeBox = false;
          
            textBox1.AppendText("Играта The Zombie Slayer е адиктивна игра во која главна цел ни е постигнување на што поголем резултат(Score). За да постигнеме што поголем score потребно е да убиеме што е можно повеќе од чудовиштата што ја напаѓаат нашата планета.\n");
            textBox1.AppendText("Нашиот карактер го контролираме со стрелките од тастатурата и пукаме со space. \n");
            textBox1.AppendText("Со секое убиено зомби (чудовиште) добиваме 50 поени и постои шанса на тоа место да се појави медицински пакет или појачување на нашите куршуми. \n");
            textBox1.AppendText("Доколку дојдеме во контакт со зомби губиме 10% од нашето здравје. При здравје 0 играта завршува. \n");
            textBox1.AppendText("Во секој момент може да ја паузираме играта или да ја зачуваме со претискање на копчето 'p' со што се појавува нов прозоец од кој ја избираме нашата акција.\n");

        }

       
    }
}
