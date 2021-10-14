using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;
using System.Diagnostics;


namespace Loading
{
    public partial class Login : Form
    {

        

        public Login()
        {
            InitializeComponent();
        }
    


        private void label3_Click(object sender, EventArgs e)
        {


        }

        private void Login_Load(object sender, EventArgs e)
        {
           

        }
     

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" && textBox2.Text.Trim() == "")
            {
                MessageBox.Show("Ju lutemi shkruani të dhënat", "Error",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else

            {
                SQLiteConnection sql_con = new SQLiteConnection("Data Source=fresh.db;Version=3;");

                string query = "SELECT * FROM LOGIN WHERE Username=@user AND Password=@pass";

                sql_con.Open();

                SQLiteCommand sql_cmd = new SQLiteCommand(query, sql_con);
                sql_cmd.Parameters.Add(new SQLiteParameter("@user", textBox1.Text));
                sql_cmd.Parameters.Add(new SQLiteParameter("@pass", textBox2.Text));
                SQLiteDataAdapter DB = new SQLiteDataAdapter(sql_cmd);
                DataTable DT = new DataTable();
                DB.Fill(DT);

                


                if (DT.Rows.Count > 0)
                {
                    MenuKryesore home = new MenuKryesore();
                    home.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Login Failed", "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
                }

            }

           
        }

    


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.White;
            panel3.BackColor = Color.White;
            panel4.BackColor = SystemColors.Control;
            textBox2.BackColor = SystemColors.Control;
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.BackColor = Color.White;
            panel4.BackColor = Color.White;
            textBox1.BackColor = SystemColors.Control;
            panel3.BackColor = SystemColors.Control;
            
        }

        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
          
        }
        private void pictureBox3_MouseUp(object sender, MouseEventArgs e)
        {
      
        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.facebook.com/rilind.arifi.71/");
        }
    }
}
