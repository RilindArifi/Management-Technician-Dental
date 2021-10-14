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
    public partial class Doktorët : Form
    {
        
        
        public Doktorët()
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

        private void Doktoret_Load(object sender, EventArgs e)
        {
          populate();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MenuKryesore menu = new MenuKryesore();
            menu.Show();
            this.Hide();
        }
        public void populate()
        {
            Sqliteconnection();
            sql_con.Open();
            string query = "select * from regjisitrimiPuneve";
            DB = new SQLiteDataAdapter(query, sql_con);
            SQLiteCommandBuilder builder = new SQLiteCommandBuilder(DB);
            DB.Fill(DS);
            dataGridView2.DataSource = DS.Tables[0]; ;
            sql_con.Close();
        }

       

        private void Reset_Click(object sender, EventArgs e)
        {
            Doktorët doktorët = new Doktorët();
            doktorët.Show();
            this.Hide();
        }

        private void kerkodokin_TextChanged(object sender, EventArgs e)
        {
           

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void kerko_TextChanged(object sender, EventArgs e)
        {
            string query = "";
            if (comboBox1.SelectedItem.ToString().Equals("Doktoret"))
            {
               query = "select * from regjisitrimiPuneve where EmriDoktorit= '" + kerko.Text + "'";
            }
            else if(comboBox1.SelectedItem.ToString().Equals("Pacientet"))
            {
                query = "select * from regjisitrimiPuneve where EmriPacientit= '" + kerko.Text + "'";
            }


            if(kerko.Text == "")
            {
                this.OnLoad(e);
            }
        }
    }
}
