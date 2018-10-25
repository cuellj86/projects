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
    public partial class CarListForm : Form
    {
        private List<Car> cars = new List<Car>();
        public CarListForm()
        {
            InitializeComponent();
            lstCars.Items.AddRange(cars.ToArray());
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CarForm addCar = new CarForm(this);
            addCar.Visible = true;
        }
        public void AddCar(Car car)
        {
            cars.Add(car);
            RefreshCars();
        }
        public void RefreshCars()
        {
            lstCars.Items.Clear();
            lstCars.Items.AddRange(cars.ToArray());
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Car selectedCar = (Car)lstCars.SelectedItem;
            cars.Remove(selectedCar);
            RefreshCars();
        }

        private void lstCars_SelectedIndexChanged(object sender, EventArgs e)
        {
            Car selectedCar = (Car)lstCars.SelectedItem;
            textBox1.Text = selectedCar.Make;
            textBox2.Text = selectedCar.Model;
            textBox3.Text = selectedCar.Year.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lstCars.SelectedItem != null)
            {
                Car selectedCar = (Car)lstCars.SelectedItem;
                textBox1.Text = selectedCar.Make;
                textBox2.Text = selectedCar.Model;
                textBox3.Text = selectedCar.Year.ToString();
                RefreshCars();
            }
        }
    }
}
