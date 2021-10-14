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

namespace Loading
{
    public partial class Regjistrimi_i_doktoreve : Form
    {
        int Record_ID;
        public Regjistrimi_i_doktoreve()
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
        public void populate()
        {
            Sqliteconnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            string CommandText = "select * from regjistrimiDoktoreve";
            DB = new SQLiteDataAdapter(CommandText, sql_con);
            DS.Reset();
            DB.Fill(DS);
            DT = DS.Tables[0];
            dataGridView2.DataSource = DT;

            sql_con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MenuKryesore menu = new MenuKryesore();
            menu.Show();
            this.Hide();
        }

        private void Regjistrimi_i_doktoreve_Load(object sender, EventArgs e)
        {
            populate();
        }
        void fshitedhenat(Control control)
        {
            foreach (Control cont in control.Controls)
            {
                if (cont is TextBox)
                    ((TextBox)cont).Clear();
                else
                    fshitedhenat(cont);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            fshitedhenat(this);

            textBox1.Text = "Dr. ";
            textBox2.Text = "383";
            richTextBox1.Text = "";
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || richTextBox1.Text == "")
            {
                MessageBox.Show("Mbusheni Të Dhënat", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string txtQuery = "insert into regjistrimiDoktoreve(EmridheMbiemri, Adresa,NumriTelefonit) values('" + textBox1.Text + "','" + richTextBox1.Text + "','" + textBox2.Text+ "')";
                ExecuteQuery(txtQuery);
                populate();
                MessageBox.Show("Të Dhënat u Regjistruan me sukses", "Të Dhënat", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button4_Click(object sender, EventArgs e)
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
                    string txtQuery = "delete from regjistrimiDoktoreve where ID='" + Record_ID + "'";
                    ExecuteQuery(txtQuery);
                    populate();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || richTextBox1.Text == "")
            {
                MessageBox.Show("Mbusheni Të Dhënat", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string txtQuery = "update regjistrimiDoktoreve set EmridheMbiemri='" + textBox1.Text + "',Adresa='" + richTextBox1.Text + "',NumriTelefonit='" + textBox2.Text + "'where ID='" + Record_ID + "'";
                ExecuteQuery(txtQuery);
                populate();
                MessageBox.Show("Të Dhënat u Edituan me sukses", "Të Dhënat", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];


                Record_ID = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString());
                textBox1.Text = row.Cells["EmridheMbiemri"].Value.ToString();
                textBox2.Text = row.Cells["NumriTelefonit"].Value.ToString();
                richTextBox1.Text = row.Cells["Adresa"].Value.ToString();

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
