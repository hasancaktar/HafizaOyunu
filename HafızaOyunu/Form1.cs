using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HafızaOyunu
{
    public partial class Form1 : Form
    {
        Random r = new Random();
        List<string> resim = new List<string>()
        {
            "w","w","e","e","Y","Y","O","O","p","p",
            "h","h","m","m","i","i",",",",","V","V",
            "N","N","ö","ö","-","-","%","%","f","f",
            "!","!","b","b","Ğ","Ğ","@","@","İ","İ",
        };
        Label birinci, ikinci;
        public Form1()
        {

            InitializeComponent();
            ResimEkle();
            timer2.Start();

        }
        int playerOne = 0, playerTwo = 0;
        private void label1_Click(object sender, EventArgs e)
        {
            
            if (birinci != null && ikinci != null)
                return;

            Label labelTiklama = sender as Label;

            if (labelTiklama == null)
            {

                return;
            }


            if (labelTiklama.ForeColor == Color.Black)
            {
                
                return;
            }


            if (birinci == null)
            {
                birinci = labelTiklama;
                birinci.ForeColor = Color.Black;
                timer3.Start();
                return;
                
            }

            ikinci = labelTiklama;
            ikinci.ForeColor = Color.Black;


            Kazanan();
            if (birinci.Text == ikinci.Text)
            {
                birinci = null;
                ikinci = null;
            }
            else
                timer1.Start();
           // timer3.Start();
        }

        private void Kazanan()
        {
            Label label;
            for (int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
                label = tableLayoutPanel1.Controls[i] as Label;
                if (label != null && label.ForeColor == label.BackColor)
                    return;
            }
            MessageBox.Show("HEPSİ EŞLEŞTİ");
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            birinci.ForeColor = birinci.BackColor;
            ikinci.ForeColor = ikinci.BackColor;

            birinci = null;
            ikinci = null;
        }
        int sayac = 5;
        int sayac2 = 5;
        private void timer3_Tick(object sender, EventArgs e)
        {          
           sayac2--;
            if (sayac2 == 0)
            {
                sayac2 = 5;
                birinci.ForeColor = BackColor;
                MessageBox.Show("ikinci oyuncu");
                birinci = null;
                ikinci = null;
                timer3.Stop();                
            }
  
            //if (ikinci.ForeColor == Color.Black)
            //{
            //    sayac2 = 5;
            //    timer3.Stop();
            //}
            
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            sayac--;
            Label label;

            for (int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
                label = tableLayoutPanel1.Controls[i] as Label;
                label.ForeColor = Color.Black;

                if (sayac == 0)
                {
                    label.ForeColor = Color.Khaki;
                    timer2.Stop();
                }
            }
        }
        private void ResimEkle()
        {
            Label label;
            int random;
            for (int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
                if (tableLayoutPanel1.Controls[i] is Label)
                    label = (Label)tableLayoutPanel1.Controls[i];

                else
                    continue;

                random = r.Next(0, resim.Count);
                label.Text = resim[random];

                resim.RemoveAt(random);
            }
        }
    }
}
