using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFileManagment
{
    internal class SortingCars : Sorting<Car>
    {
        protected override int CompareItems(Car carA, Car carB)
        {
            // Compare by price
            int priceComparison = carA.Price.CompareTo(carB.Price);
            if (priceComparison != 0) return priceComparison;

            // Compare by engine capacity
            int engineCapacityComparison = carA.EngineCapacity.CompareTo(carB.EngineCapacity);
            if (engineCapacityComparison != 0) return engineCapacityComparison;

            // Compare by model
            int modelComparison = carA.Model.CompareTo(carB.Model);
            return modelComparison;
        }

        protected override string GenerateSearchKeyFromRecord(Car car)
        {
            string key = car.Price.ToString() + ";" + car.EngineCapacity.ToString() + ";" + car.Model.ToString();
            return key;
        }
    }
}
