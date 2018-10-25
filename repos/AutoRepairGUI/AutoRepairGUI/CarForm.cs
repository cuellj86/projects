using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoRepairGUI
{
    public partial class CarForm : Form
    {
        CarListForm parent;
        public CarForm(CarListForm parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        private void CarForm_Load(object sender, EventArgs e)
        {
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //lblOutput.Text = txtMake.Text + " " + txtModel.Text + " " + txtYear.Text;
            int year = 0;
            int.TryParse(txtYear.Text, out year);
            Car car = new Car(txtMake.Text, txtModel.Text, year);
            if (parent == null)
            {
                return;
            }
            else
            {
                parent.AddCar(car);
            }
            lblOutput.Text = car.ToString();
        }

    }
}
