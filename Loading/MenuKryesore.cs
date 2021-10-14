using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Loading
{
    public partial class MenuKryesore : Form
    {
        public MenuKryesore()
        {
            InitializeComponent();
            
        }

        private void MenuKryesore_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void fileSystemWatcher2_Changed(object sender, System.IO.FileSystemEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            DialogResult exit;
            exit = MessageBox.Show("Jeni i sigurt qe doni te mbylleni aplicationin", "Exit Aplication", MessageBoxButtons.YesNo,MessageBoxIcon.Information);
            if (exit == DialogResult.Yes)
            {
                Application.Exit();
            }
            
        }

        private void button7_Click(object sender, EventArgs e)
        {   Doktorët doc = new Doktorët();
            doc.Show();
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
           

            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Regjistrimi_i_doktoreve Rdoktoreve = new Regjistrimi_i_doktoreve();
            Rdoktoreve.Show();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }
    }
}
