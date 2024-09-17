using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFileManagment
{
    internal class Sorting
    {
        public List<Car> InsertingSort(List<Car> cars)
        {
            // cars.Reverse();

            for(int i = 0; i < cars.Count; i++) 
            {
                Car currentCar = cars[i];

                int j = i - 1;

                while (j >= 0 && CompareCars(cars[j], currentCar) > 0) {
                    cars[j + 1] = cars[j];
                    j--;
                }

                cars[j + 1] = currentCar;
            }

            return cars;
        }

        private int CompareCars(Car carA, Car carB)
        {
            // Compare by price
            int priceComparison = carA.Price.CompareTo(carB.Price);
            if(priceComparison != 0) return priceComparison;

            // Compare by engine capacity
            int engineCapacityComparison = carA.EngineCapacity.CompareTo(carB.EngineCapacity);
            if (engineCapacityComparison != 0) return engineCapacityComparison;

            // Compare by model
            int modelComparison = carA.Model.CompareTo(carB.Model);
            return modelComparison;
        }
    }
}
