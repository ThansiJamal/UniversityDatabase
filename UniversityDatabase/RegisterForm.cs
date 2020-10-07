using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniversityDatabase
{
    public partial class RegisterForm : Form
    {

       
        public RegisterForm()
        {
            InitializeComponent();
        
        }
        private void btnGetResult_Click(object sender, EventArgs e)
        {

            if (txtId.Text != "")
            {
                string rollnumber = txtId.Text;
                txtId.Text = null;
                Form1 result = new Form1(rollnumber); 
                result.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Enter Id");
            }
            //this.Close();



        }


        private void RegisterForm_Load(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }
    }
    }

