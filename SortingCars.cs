using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyFileManagment
{
    internal class SortingCars : Sorting<Car>
    {
        /**
         * Сравнивает машину А и машину Б по полю fieldName
         */
        protected override int CompareItems(Car carA, Car carB, string fieldName)
        {
            // Получаем тип структуры Car
            Type carType = typeof(Car);

            // Получаем свойство по имени
            FieldInfo field = carType.GetField(fieldName);


            if (field == null)
            {
                throw new ArgumentException($"Поле с именем '{fieldName}' не найдено.");
            }

            // Получаем значение свойства для carA и carB
            var valueA = field.GetValue(carA);
            var valueB = field.GetValue(carB);

            // Предполагается, что свойство реализует IComparable
            return ((IComparable)valueA).CompareTo(valueB);

            // Compare by price
            // int priceComparison = carA.Price.CompareTo(carB.Price);
            // if (priceComparison != 0) return priceComparison;

            // Compare by engine capacity
            // int engineCapacityComparison = carA.EngineCapacity.CompareTo(carB.EngineCapacity);
            // if (engineCapacityComparison != 0) return engineCapacityComparison;

            // Compare by model
            // int modelComparison = carA.Model.CompareTo(carB.Model);
            // return modelComparison;
        }

        protected override string GenerateSearchKeyFromRecord(Car car)
        {
            string key = car.Price.ToString() + ";" + car.EngineCapacity.ToString() + ";" + car.Model.ToString();
            return key;
        }
    }
}
