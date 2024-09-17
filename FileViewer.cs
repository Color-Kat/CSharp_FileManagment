using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static MyFileManagment.FileViewer;

namespace MyFileManagment
{
    struct Car
    {
        public string Model;
        public int Price;
        public string BodyType;
        public double EngineCapacity;
        public bool HasABS;
    }

    // https://chatgpt.com/c/66dfe0ea-2a94-8004-9ab1-abc615304950
    // https://chatgpt.com/c/66e926e8-5ed8-8004-9ae0-1c54e681c085
    internal class FileViewer
    {
        /**
         * Convert string line with separators to Car structure
         */
        private Car ConvertLineToCar(string line)
        {
            Car car = new Car();

            // Separate string by ";"
            string[] carDataParts = line.Split(';');

            // Not enough data
            if(carDataParts.Length != 5) {
                throw new FormatException("Неверный формат данных: указаны не все поля: " + carDataParts.Length + "/5");
            }
            
            // Fill car structure
            car.Model = carDataParts[0].Trim();
            car.Price = int.Parse(carDataParts[1]);
            car.BodyType = carDataParts[2].Trim();
            car.EngineCapacity = double.Parse(carDataParts[3]);
            car.HasABS = carDataParts[4].Trim() == "да" ? true : false;
            
            return car;
        }

        public unsafe List<Car> Load (string filename)
        {
            List<Car> cars = new List<Car>();
            StreamReader streamReader = new StreamReader(filename);

            // Read file by lines
            string line;
            int rowIndex = 0;
            while ((line = streamReader.ReadLine()) != null)
            {
                try
                {
                    // Convert string line to Car structure
                    Car car = ConvertLineToCar(line);
                    cars.Add(car);

                    rowIndex++;
                }
                catch (FormatException ex)
                {
                    MessageBox.Show($"Ошибка при обработке строки: {line}. {ex.Message}");
                }
            }

            streamReader.Close();

            return cars;
        }

        public void Show(List<Car> cars, DataGridView carsGrid)
        {
            int rowsLimit = 50;
            int rowsCount = cars.Count > rowsLimit ? rowsLimit : cars.Count;
            carsGrid.Rows.Clear();

            for (int i = 0; i < rowsCount; i++)
            {
                Car car = cars[i];

                // Add data to data grid view
                carsGrid.Rows.Add();
                carsGrid.Rows[i].Cells[0].Value = car.Model;  // 
                carsGrid.Rows[i].Cells[1].Value = car.Price.ToString();  // 
                carsGrid.Rows[i].Cells[2].Value = car.BodyType;  // 
                carsGrid.Rows[i].Cells[3].Value = car.EngineCapacity.ToString();  // 
                carsGrid.Rows[i].Cells[4].Value = car.HasABS.ToString();  // 
            }
        }

        public unsafe void LoadAndSaveFile(string filename, string newFilename = "cars.dat")
        {
            StreamReader streamReader = new StreamReader(filename);

            // Determine filename for new file
            // string newFilename = Path.GetFileNameWithoutExtension(filename) + ".dat";

            StreamWriter writer = new StreamWriter(newFilename);

            // Read file by lines (and set rows limit)
            string line;
            while ((line = streamReader.ReadLine()) != null)
            {
                try
                {
                    string[] carDataParts = line.Split(';');
                    string carLineInNewFormat = string.Join(';', carDataParts); // Can cahnge separator

                    // Write data to file
                    writer.WriteLine(carLineInNewFormat);
                   
                }
                catch (FormatException ex)
                {
                    MessageBox.Show($"Ошибка при обработке строки: {line}. {ex.Message}");
                }
            }

            writer.Close();
        }
    }
}
