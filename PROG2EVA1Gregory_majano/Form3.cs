using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROG2EVA1Gregory_majano
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            
               
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            img2.Visible = false;
        }

        private void img3_Click(object sender, EventArgs e)
        {
            img3.Visible = false;
        }

        private void img4_Click(object sender, EventArgs e)
        {
            img4.Visible = false;
        }

        private void img1_Click(object sender, EventArgs e)
        {
            img1.Visible = false;
        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form1 fm = new Form1();
            fm.Show();


        }

        private void picluna_Click(object sender, EventArgs e)
        {
           
        }
    }
}
