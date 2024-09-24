using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MyFileManagment
{
    internal class HashSearch
    {
        private const int Base = 2;
        private const int Mod = 101;

        /**
         * For every char in the string set the int32 number.
         * And return hashCode % mod.
         */
        public int ComputeHash(Car car)
        {
            // String with car data
            string carData = $"{car.Model};{car.Price};{car.BodyType};{car.EngineCapacity};{car.HasABS}";

            long multiplier = 1;
            long hashCode = 0;

            for(int i = 0; i < carData.Length; i++)
            {
                hashCode += Convert.ToInt32(carData[i]) * multiplier;
                multiplier *= Base;
            }

            return (int)(hashCode % Mod);
        }

        public unsafe List<string> CreateHashFile(List<Car> cars, string hashFilename)
        {
            int hashValue;
            string carData;
            byte[] carBuffer = new byte[100];

            List<string> hashResults = new List<string>();

            using (FileStream hashFile = File.OpenWrite(hashFilename))
            {
                foreach (Car car in cars)
                {
                    // Create string with car data
                    carData =
                         $"{car.Model.PadRight(20)};" +         // Модель автомобиля, 20 байт
                         $"{car.Price.ToString().PadRight(10)};" + // Цена, 10 байт
                         $"{car.BodyType.PadRight(15)};" +      // Тип кузова, 15 байт
                         $"{car.EngineCapacity.ToString().PadRight(10)};" + // Объем двигателя, 10 байт
                         $"{(car.HasABS ? "да" : "нет").PadRight(5)}"; // ABS, 5 байт

                    byte[] carDataBytes = Encoding.UTF8.GetBytes(carData);
                    Array.Copy(carDataBytes, carBuffer, carDataBytes.Length);

                    // Compute hash for this car
                    hashValue = ComputeHash(car);

                    MessageBox.Show(hashValue + " - " + carData);

                    // Write data in hash file
                    hashFile.Seek(hashValue * carBuffer.Length, SeekOrigin.Begin);
                    hashFile.Write(carBuffer, 0, carBuffer.Length);

                    string hashResult = hashValue.ToString("D2") + " - " + carData;
                    hashResults.Add(hashResult);
                }
            }

            return hashResults;
        }

        public Car SeachInHashFile(string hashFilename, Car searchCar)
        {
            int hashValue;
            byte[] carBuffer = new byte[100];

            using (FileStream hashFile = File.OpenRead(hashFilename))
            {
                // Compute hash for searching car
                hashValue = ComputeHash(searchCar);

                // Go to position in file where starts searching car
                hashFile.Seek(hashValue * carBuffer.Length, SeekOrigin.Begin);

                // Read car data from file
                hashFile.Read(carBuffer, 0, carBuffer.Length);

                // Create string from bytes
                string carLine = Encoding.UTF8.GetString(carBuffer).Trim('\0');

                Car car = FileViewer.ConvertLineToCar(carLine);

                return car;
            }
        }
    }
}
