using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRepairGUI
{
    class CarDA
    {
        public static List<Car> GetAllCars()
        {
            List<Car> cars = new List<Car>();
            cars.Add(new Car("Ford", "Escape", 2014));
            cars.Add(new Car("Toyota", "Prius", 2008));
            cars.Add(new Car("Tesla", "Model S", 2014));
            return cars;
        }

    }
}
