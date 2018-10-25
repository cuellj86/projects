using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExceptionAssignment
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnYear_Click(object sender, EventArgs e)
        {
            try
            {
                int year = int.Parse(txtYear.Text);
                lblYear.Text = "The year entered is: " + year;
            }
            catch (FormatException)
            {
                lblYear.Text = "Caught an exception!";
                lblYear.Text = "Incorrect format - should be an integer: " + txtYear.Text;
            }
            finally
            {
                lblDivision.Text = lblDivision.Text + " X";
            }
        }

        private void btnDivision_Click(object sender, EventArgs e)
        {
            try
            {
                decimal division = decimal.Parse(txtDivision.Text);
                decimal answer = (decimal)10.0/division;
                lblDivision.Text = answer.ToString();
            }
            catch(Exception)
            {
                lblDivision.Text = "Wroang Dangus";
            }
        }
    }
}
