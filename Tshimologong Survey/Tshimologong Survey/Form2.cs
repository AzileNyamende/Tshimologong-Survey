using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//the following declarations for the use of database functions
using System.Data.OleDb;
using System.Data.SqlClient;
namespace Tshimologong_Survey
{
    public partial class Form2 : Form
    {
        OleDbConnection conn;
        OleDbDataAdapter adapter;
        DataTable dt;
        string sAmapiano = "Amapano ";
        string sKwaito = "Kwaito ";
        string sRap = "Hip Hop/Rap ";
        string sHouseMusic = "House Music ";
        string sTraditionalMusic = "Traditional Music ";
        string sJazz = "Jazz";

        public static string TotalSurveys;
        public static string OldestPerson;


        public Form2()
        {
            InitializeComponent();
        }
        void GetSurvey()
        {
            conn = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = Survey Records.accdb;Persist Security Info = True");
            dt = new DataTable();
            adapter = new OleDbDataAdapter("SELECT *FROM Survey", conn);
            conn.Open();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {

            OleDbConnection connection = new OleDbConnection();
            connection.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = Survey Records.accdb;Persist Security Info = True";
            connection.Open();
            OleDbCommand command1 = new OleDbCommand();
            command1.Connection = connection;
            command1.Connection = connection;

       if (cbAmapiano.Checked == true)
                command1.CommandText = "INSERT INTO Survey (Surname, FirstName, MobileNumber, EmailAdress, Birthdate, Age, likes) Values ('" + txtSurname.Text + "','" + txtFirstName.Text + "','" + txtNumber.Text + "','" + txtEmail.Text + "','" + dtpBirthDate.Value + "','" + txtAge.Text + "','"+sAmapiano+"')";
            else

       if (cbKwaito.Checked == true)
                command1.CommandText = "INSERT INTO Survey (Surname, FirstName, MobileNumber, EmailAdress, Birthdate, Age, likes) Values ('" + txtSurname.Text + "','" + txtFirstName.Text + "','" + txtNumber.Text + "','" + txtEmail.Text + "','" + dtpBirthDate.Value + "','" + txtAge.Text + "','" + sKwaito + "')";
            else

       if (cbHipHop.Checked == true)
                command1.CommandText = "INSERT INTO Survey (Surname, FirstName, MobileNumber, EmailAdress, Birthdate, Age, likes) Values ('" + txtSurname.Text + "','" + txtFirstName.Text + "','" + txtNumber.Text + "','" + txtEmail.Text + "','" + dtpBirthDate.Value + "','" + txtAge.Text + "','" + sRap + "')";
            else
               
       if (cbHouse.Checked == true)
                command1.CommandText = "INSERT INTO Survey (Surname, FirstName, MobileNumber, EmailAdress, Birthdate, Age, likes) Values ('" + txtSurname.Text + "','" + txtFirstName.Text + "','" + txtNumber.Text + "','" + txtEmail.Text + "','" + dtpBirthDate.Value + "','" + txtAge.Text + "','" + sHouseMusic + "')";
            else
               
      if (cbTM.Checked == true)
            command1.CommandText = "INSERT INTO Survey (Surname, FirstName, MobileNumber, EmailAdress, Birthdate, Age) Values ('" + txtSurname.Text + "','" + txtFirstName.Text + "','" + txtNumber.Text + "','" + txtEmail.Text + "','" + dtpBirthDate.Value + "','" + txtAge.Text + "')";
            else

      if (cbJazz.Checked == true)
                command1.CommandText = "INSERT INTO Survey (Surname, FirstName, MobileNumber, EmailAdress, Birthdate, Age, likes) Values ('" + txtSurname.Text + "','" + txtFirstName.Text + "','" + txtNumber.Text + "','" + txtEmail.Text + "','" + dtpBirthDate.Value + "','" + txtAge.Text + "','" + sJazz + "')";
       else
                command1.CommandText = "INSERT INTO Survey (Surname, FirstName, MobileNumber, EmailAdress, Birthdate, Age) Values ('" + txtSurname.Text + "','" + txtFirstName.Text + "','" + txtNumber.Text + "','" + txtEmail.Text + "','" + dtpBirthDate.Value + "','" + txtAge.Text + "')";

            command1.ExecuteNonQuery();
            connection.Close();
            GetSurvey();

            //Getting the total number of survey's
            String cs = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = Survey Records.accdb;Persist Security Info = True";
            OleDbConnection con1 = new OleDbConnection(cs);
            con1.Open();
            OleDbCommand com = new OleDbCommand("select Max(id) as ID from Survey",
            con1);
            com.CommandType = CommandType.Text;
            OleDbDataReader r = com.ExecuteReader();
            r.Read();
            //Count Number of Rows in database
            int temp;
            if (r["ID"].ToString() != "")
            {
                temp = int.Parse(r["ID"].ToString());//+1
            }
            else
            {
                temp = 1;
            }
            lblRowCount.Text = temp.ToString();
            r.Close();
            con1.Close();
            TotalSurveys = lblRowCount.Text;
            this.Hide();
            Form1 f1 = new Form1();
            f1.ShowDialog();
            this.Close();
        }



        private void Form2_Load(object sender, EventArgs e)
        {
            //Get Maximum Age from database
            GetSurvey();
            String cs = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = Survey Records.accdb;Persist Security Info = True";
            OleDbConnection con1 = new OleDbConnection(cs);
            con1.Open();
            OleDbCommand com = new OleDbCommand("select Max(age) as Age from Survey",
            con1);
            com.CommandType = CommandType.Text;
            OleDbDataReader r = com.ExecuteReader();
            r.Read();
            //Get Max Age
            int temp;
            if (r["Age"].ToString() != "")
            {
                temp = int.Parse(r["Age"].ToString());//+1
            }
            else
            {
                temp = 1;
            }
            lblOldestPerson.Text = temp.ToString();
            r.Close();
            con1.Close();
            OldestPerson = lblOldestPerson.Text;
        }

        private void button1_Click(object sender, EventArgs e) 
        {


        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            txtSurname.Text = "";
            txtFirstName.Text = "";
            txtEmail.Text = "";
            txtNumber.Text = "";
            txtAge.Text = "";
            cbAmapiano.Checked = false;
            cbKwaito.Checked = false;
            cbHipHop.Checked = false;
            cbHouse.Checked = false;
            cbTM.Checked = false;
            cbJazz.Checked = false;
        }
    }
}

