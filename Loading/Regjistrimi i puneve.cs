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
using PagedList;



namespace Loading
{
    public partial class Form1 : Form
    {
        int Record_ID;
        
       
        public Form1()
        {
            InitializeComponent();
            
        }
        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;
        private SQLiteDataAdapter DB;
        private DataSet DS = new DataSet();
        private DataTable DT = new DataTable();
        private void Sqliteconnection()
        {
             sql_con = new SQLiteConnection("Data Source=fresh.db;Version=3;");
        }
        private void ExecuteQuery(string txtQuery)
        {
            Sqliteconnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = txtQuery;
            sql_cmd.ExecuteNonQuery();
            sql_con.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
           
        }
        public void populate()
        {
            Sqliteconnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            string CommandText = "select * from regjisitrimiPuneve";
            DB = new SQLiteDataAdapter(CommandText, sql_con);
            DS.Reset();
            DB.Fill(DS);
            DT = DS.Tables[0];
            dataGridView2.DataSource = DT;
            sql_con.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            populate();
            selectEmri();



        }
        
        bool check = true;
    
        void fshitedhenat(Control control)
        {
            foreach(Control cont in control.Controls)
            {
                if (cont is TextBox)
                    ((TextBox)cont).Clear();
                else
                    fshitedhenat(cont);
            }
        }
       
        private void button10_Click_2(object sender, EventArgs e)
        {
            fshitedhenat(this);

            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            textBox2.Text = "";
            dateTimePicker1.Text = "";
            dateTimePicker2.Text = "";
            textBox6.Text = "";
            textBox5.Text = "";
            textBox4.Text = "";
            textBox7.Text = "";
            btn1dn.BackColor = Color.White;
            btn2dn.BackColor = Color.White;
            btn3dn.BackColor = Color.White;
            btn4dn.BackColor = Color.White;
            btn5dn.BackColor = Color.White;
            btn6dn.BackColor = Color.White;
            btn7dn.BackColor = Color.White;
            btn8dn.BackColor = Color.White;
            button7.BackColor = Color.White;
            btn2dp.BackColor = Color.White;
            btn3dp.BackColor = Color.White;
            btn4dp.BackColor = Color.White;
            btn5dp.BackColor = Color.White;
            btn6dp.BackColor = Color.White;
            btn7dp.BackColor = Color.White;
            btn8dp.BackColor = Color.White;
            btn1mn.BackColor = Color.White;
            btn2mn.BackColor = Color.White;
            btn3mn.BackColor = Color.White;
            btn4mn.BackColor = Color.White;
            btn5mn.BackColor = Color.White;
            btn6mn.BackColor = Color.White;
            btn7mn.BackColor = Color.White;
            btn8mn.BackColor = Color.White;
            btn1mp.BackColor = Color.White;
            btn2mp.BackColor = Color.White;
            btn3mp.BackColor = Color.White;
            btn4mp.BackColor = Color.White;
            btn5mp.BackColor = Color.White;
            btn6mp.BackColor = Color.White;
            btn7mp.BackColor = Color.White;
            btn8mp.BackColor = Color.White;

        }

        private void dataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button4_Click_2(object sender, EventArgs e)
        {
            DialogResult exit;
            exit = MessageBox.Show("Jeni i sigurt qe doni të Fshijni të Dhënat", "Të Dhënat", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (exit == DialogResult.Yes)
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Nuk është Fshir", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    string txtQuery = "delete from regjisitrimiPuneve where ID='" + Record_ID + "'";
                    ExecuteQuery(txtQuery);
                    populate();
                }
            }


           
            
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
          if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Mbusheni Të Dhënat", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string txtQuery = "insert into regjisitrimiPuneve(EmriPacientit, EmriDoktorit,Materiali,NgjyraDhembit,DataPranimit,DataDorzimit,Pagesa,NrAntarve,Dhembi) values('" + textBox1.Text + "','" + comboBox1.SelectedItem.ToString() + "','" + comboBox3.SelectedItem.ToString() + "','" + comboBox2.SelectedItem.ToString() + "','" + dateTimePicker1.Text + "','" + dateTimePicker2.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + btn4dn.Text + "')";
                ExecuteQuery(txtQuery);
                populate();
                MessageBox.Show("Të Dhënat u Regjistruan me sukses", "Të Dhënat", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Mbusheni Të Dhënat", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string txtQuery = "update regjisitrimiPuneve set EmriPacientit='" + textBox1.Text + "',EmriDoktorit='" + comboBox1.SelectedItem.ToString() + "',Materiali='" + comboBox3.SelectedItem.ToString() + "',NgjyraDhembit='" + comboBox2.SelectedItem.ToString() + "',DataPranimit='" + dateTimePicker1.Text + "',DataDorzimit='" + dateTimePicker2.Text + "',Pagesa='" + textBox2.Text + "',NrAntarve='" + textBox3.Text + "'where ID='" + Record_ID + "'";
                ExecuteQuery(txtQuery);
                populate();
                MessageBox.Show("Të Dhënat u Edituan me sukses", "Të Dhënat", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            MenuKryesore menu = new MenuKryesore();
            menu.Show();
            this.Hide();
        }
        Bitmap bitmap;

        private void button5_Click_2(object sender, EventArgs e)
        {
            Panel panel = new Panel();
            this.Controls.Add(panel);
            Graphics graphics = panel.CreateGraphics();
            Size size = this.ClientSize;
            bitmap = new Bitmap(this.Size.Width, Size.Height, graphics);
            graphics = Graphics.FromImage(bitmap);
            Point point = PointToScreen(panel.Location);
            graphics.CopyFromScreen(point.X, point.Y, 0, 0, size);
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage_2(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, 0, 0);
        }
        
        private void btn4dn_Click_1(object sender, EventArgs e)
        {
            string oldValue = textBox4.Text;
            if (check == true)
            {
            
             btn4dn.BackColor = Color.Red;
                textBox4.Text = oldValue+" 4";
             
            }
            else if (check == false)
            {
                btn4dn.BackColor = Color.White;
                textBox4.Text = oldValue;
            }
            check = !check;
    
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];


                Record_ID = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString());
                textBox1.Text = row.Cells["EmriPacientit"].Value.ToString();
                textBox2.Text = row.Cells["Pagesa"].Value.ToString();
                textBox3.Text = row.Cells["NrAntarve"].Value.ToString();
                comboBox1.Text = row.Cells["EmriDoktorit"].Value.ToString();
                comboBox2.Text = row.Cells["NgjyraDhembit"].Value.ToString();
                comboBox3.Text = row.Cells["Materiali"].Value.ToString();
            }
        }
        public void selectEmri()
        {
            Sqliteconnection();
            try
            {
                sql_con.Open();
                string Query = "select * from regjistrimiDoktoreve ";
                sql_cmd = new SQLiteCommand(Query, sql_con);
                SQLiteDataReader myrader;
                myrader = sql_cmd.ExecuteReader();
                while (myrader.Read())
                {
                    string emri = myrader.GetString(1);
                    comboBox1.Items.Add(emri);
                }
     

                 sql_con.Close();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void btn1dn_Click(object sender, EventArgs e)
        {
            string oldValue = textBox4.Text;
            if (check == true)
            {

                btn1dn.BackColor = Color.Red;
                textBox4.Text = oldValue + " 4";

            }
            else if (check == false)
            {
                btn1dn.BackColor = Color.White;
                textBox4.Text = oldValue;
            }
            check = !check;
        }


        private void btn1mp_Click(object sender, EventArgs e)
        {
            string oldValue = textBox6.Text;
            if (check == true)
            {

                btn1mp.BackColor = Color.Red;

                textBox6.Text = oldValue + "  1";

            }
            else if (check == false)
            {
                btn1mp.BackColor = Color.White;
                textBox6.Text = oldValue;
                


            }
            check = !check;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string oldValue = textBox7.Text;
            if (check == true)
            {

                button7.BackColor = Color.Red;

                textBox7.Text = oldValue + "  1";

            }
            else if (check == false)
            {
                button7.BackColor = Color.White;
                textBox7.Text = oldValue;



            }
            check = !check;
        }

        private void btn2mp_Click(object sender, EventArgs e)
        {
            string oldValue = textBox6.Text;
            if (check == true)
            {

                btn2mp.BackColor = Color.Red;
                textBox6.Text = oldValue + "  2";

            }
            else if (check == false)
            {
                btn2mp.BackColor = Color.White;
                textBox6.Text = oldValue;
                

            }
            check = !check;
        }

        private void btn3mp_Click(object sender, EventArgs e)
        {
            string oldValue = textBox6.Text;
            if (check == true)
            {

                btn3mp.BackColor = Color.Red;
                textBox6.Text = oldValue + "  3";

            }
            else if (check == false)
            {
                btn3mp.BackColor = Color.White;
                textBox6.Text = oldValue;


            }
            check = !check;
        }

        private void btn4mp_Click(object sender, EventArgs e)
        {
            string oldValue = textBox6.Text;
            if (check == true)
            {

                btn4mp.BackColor = Color.Red;
                textBox6.Text = oldValue + "  4";

            }
            else if (check == false)
            {
                btn4mp.BackColor = Color.White;
                textBox6.Text = oldValue;


            }
            check = !check;
        }

        private void btn5mp_Click(object sender, EventArgs e)
        {
            string oldValue = textBox6.Text;
            if (check == true)
            {

                btn5mp.BackColor = Color.Red;
                textBox6.Text = oldValue + "  5";

            }
            else if (check == false)
            {
                btn5mp.BackColor = Color.White;
                textBox6.Text = oldValue;


            }
            check = !check;
        }

        private void btn6mp_Click(object sender, EventArgs e)
        {
            string oldValue = textBox6.Text;
            if (check == true)
            {

                btn6mp.BackColor = Color.Red;
                textBox6.Text = oldValue + "  6";

            }
            else if (check == false)
            {
                btn6mp.BackColor = Color.White;
                textBox6.Text = oldValue;


            }
            check = !check;
        }

        private void btn7mp_Click(object sender, EventArgs e)
        {
            string oldValue = textBox6.Text;
            if (check == true)
            {

                btn7mp.BackColor = Color.Red;
                textBox6.Text = oldValue + "  7";

            }
            else if (check == false)
            {
                btn7mp.BackColor = Color.White;
                textBox6.Text = oldValue;


            }
            check = !check;
        }

        private void btn8mp_Click(object sender, EventArgs e)
        {
            string oldValue = textBox6.Text;
            if (check == true)
            {

                btn8mp.BackColor = Color.Red;
                textBox6.Text = oldValue + "  8";

            }
            else if (check == false)
            {
                btn8mp.BackColor = Color.White;
                textBox6.Text = oldValue;


            }
            check = !check;
        }

        private void btn1mn_Click(object sender, EventArgs e)
        {
            string oldValue = textBox5.Text;
            if (check == true)
            {

                btn1mn.BackColor = Color.Red;
                textBox5.Text = oldValue + "  1";

            }
            else if (check == false)
            {
                btn1mn.BackColor = Color.White;
                textBox5.Text = oldValue;


            }
            check = !check;
        }
    }
}
