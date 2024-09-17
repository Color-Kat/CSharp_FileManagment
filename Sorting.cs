using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFileManagment
{
    internal class Sorting
    {
        public List<Car> Sort(List<Car> cars)
        {
            cars.Reverse();

            return cars;
        }
    }
}
