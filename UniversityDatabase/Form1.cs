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
    public partial class Form1 : Form
    {
        string RollNumber = string.Empty;
        public Form1(string rollno)
        {
            InitializeComponent();
            RollNumber = rollno;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          // lblClose.Left = Screen.PrimaryScreen.WorkingArea.Width - lblClose.Width;
            #region DatabaseOperation
            SqlConnection connect = new SqlConnection(@"Server=DESKTOP-1GLFNAF\SQLEXPRESS;Database=UniversityDatabase;trusted_connection=true");
            connect.Open();
            //MessageBox.Show("Connect Succesfully");
            SqlCommand cmd = new SqlCommand("StudentGet", connect);
            cmd.CommandType = CommandType.StoredProcedure;
           cmd.Parameters.AddWithValue("StudentsID", RollNumber) ;
            SqlDataReader dr = cmd.ExecuteReader();
            #endregion
            #region ResultPresentation
            if (dr.Read())
            {
                lblRollNo.Text = dr["StudentsID"].ToString();
                lblName.Text = dr["Name"].ToString();
                lblMalayalam.Text = dr["Malayalam"].ToString();
                lblEnglish.Text = dr["English"].ToString();
                lblHindi.Text = dr["Hindi"].ToString();
                lblPlace.Text = dr["Place"].ToString();
                lblTotal.Text = dr["Total"].ToString();
                lblPercentage.Text = dr["Percentage"].ToString()+"%";
            }
            else
            {
                MessageBox.Show("No Data", this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            if (Convert.ToInt32(lblMalayalam.Text) > 50)
            {
                lblMalayalamStatus.Text = "P";
                lblMalayalamStatus.ForeColor = Color.Green;
            }
            else
            {
                lblMalayalamStatus.Text = "F";
                lblMalayalamStatus.ForeColor = Color.Red;
                lblMalayalam.Text = "--";

            }
            if (Convert.ToInt32(lblEnglish.Text) > 50)
            {
                lblEnglishStatus.Text = "P";
                lblEnglishStatus.ForeColor = Color.Green;
            }
            else
            {
                lblEnglishStatus.Text = "F";
                lblEnglishStatus.ForeColor = Color.Red;
                lblEnglish.Text = "--";

            }
            if (Convert.ToInt32(lblHindi.Text) > 50)
            {
                lblHindiStatus.Text = "P";
                lblHindiStatus.ForeColor = Color.Green;
            }
            else
            {
                lblHindiStatus.Text = "F";
                lblHindiStatus.ForeColor = Color.Red;
                lblHindi.Text = "--";
            }
            if (Convert.ToInt32(lblTotal.Text) > 150)
            {
                lblTotalStatus.Text = "P";
                lblTotalStatus.ForeColor = Color.Green;
            }
            else
            {
                lblTotalStatus.Text = "F";
                lblTotalStatus.ForeColor = Color.Green;
            }

            if ((lblMalayalamStatus.Text == "P") && (lblEnglishStatus.Text == "P") && (lblHindiStatus.Text == "P"))
            {
                lblEligible.Text = "You are eligible for higher studies";
                lblEligible.ForeColor = Color.Blue;
            }
            else
            {
                lblEligible.Text = "Failed!";
                lblEligible.ForeColor = Color.Red;
            }
            #endregion
            connect.Close();

        }

        private void lblClose_Click_1(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnNewResult_Click(object sender, EventArgs e)
        {
            RegisterForm register = new RegisterForm();
            register.Show();
            this.Hide();
        }

        
    }
    
}

    