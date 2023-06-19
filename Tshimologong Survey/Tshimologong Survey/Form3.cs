using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tshimologong_Survey
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.ShowDialog();

            this.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
        
            lblSurveyDisp.Text = Form2.TotalSurveys;
            lblOldestPerson.Text = Form2.OldestPerson;
        }
    }
}
