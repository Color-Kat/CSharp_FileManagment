using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MyFileManagment
{
    // https://chatgpt.com/c/66dfe0ea-2a94-8004-9ab1-abc615304950
    internal class FileViewer
    {
        public unsafe struct Car
        {
            public string Model;
            public int Price;
            public string BodyType;
            public double EngineCapacity;
            public bool HasABS;
        }

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

        public unsafe void Load (string filename, DataGridView carsGrid)
        {
            StreamReader streamReader = new StreamReader(filename);

            int rowIndex = 0;
            int rowsLimit = 50;
            carsGrid.Rows.Clear();

            // Read file by lines (and set rows limit)
            string line;
            while ((line = streamReader.ReadLine()) != null && rowIndex < rowsLimit)
            {
                try
                {
                    // Convert string line to Car structure
                    Car car = ConvertLineToCar(line);

                    // Add data to data grid view
                    carsGrid.Rows.Add();
                    carsGrid.Rows[rowIndex].Cells[0].Value = car.Model;  // 
                    carsGrid.Rows[rowIndex].Cells[1].Value = car.Price.ToString();  // 
                    carsGrid.Rows[rowIndex].Cells[2].Value = car.BodyType;  // 
                    carsGrid.Rows[rowIndex].Cells[3].Value = car.EngineCapacity.ToString();  // 
                    carsGrid.Rows[rowIndex].Cells[4].Value = car.HasABS.ToString();  // 

                    rowIndex++;
                }
                catch (FormatException ex)
                {
                    MessageBox.Show($"Ошибка при обработке строки: {line}. {ex.Message}");
                }
            }


            // Set row counts for data grid view
            // carsGrid.RowCount = numberOfCars;           
        }

        /*public unsafe void Convert(string _fn, DataGridView _dgErr)
        {
            // Создаем массив объектов типа TbCars размером в 3 элемента
            TbCars[] bCarsMassive = new TbCars[3];

            int i, j, Res; // Объявляем счетчики и переменную для результата
            string tmp; // Временная строка для хранения пути файла
            TbCars* bCars = stackalloc TbCars[1]; // Выделяем память для одного объекта TbCars на стеке
            byte[] bbCars = new byte[sizeof(TbCars)]; // Создаем массив байтов для преобразования объекта TbCars
            string bCarsTXT; // Строка для хранения текущей строки файла
            string[] rCar; // Массив для хранения разделенных данных из строки
            char m; // Переменная для будущего использования (в коде не используется)

            // Открываем файл для чтения, используя переданный путь файла _fn
            System.IO.StreamReader fCatsTXT = new System.IO.StreamReader(_fn);
            tmp = "";

            // Определяем имя файла для записи, меняем расширение с исходного на ".dat"
            for (i = 0; i <= _fn.IndexOf("."); i++)
                tmp = tmp + _fn[i];
            tmp = tmp + "dat";

            // Открываем поток для записи в файл с новым именем
            FileStream fCars = File.OpenWrite(tmp);

            j = 0; // Инициализируем счетчик для строк с ошибками

            // Читаем строки из текстового файла до конца
            while ((bCarsTXT = fCatsTXT.ReadLine()) != null)
            {
                Res = 0; // Инициализируем переменную результата, 0 означает успешную обработку

                // Разделяем строку по символу "/"
                rCar = bCarsTXT.Split(new Char[] { '/' });

                // Проверяем, что в строке ровно 3 части
                if (rCar.Length == 3)
                {
                    // Очищаем поле Mark в объекте bCars, заполняя его пробелами (ASCII код 32)
                    for (i = 0; i < 30; i++)
                        bCars->Mark[i] = 32;

                    // Копируем строку в массив Mark, преобразуя символы в байты
                    for (i = 0; i < rCar[0].Length; i++)
                        bCars->Mark[i] = System.Convert.ToByte(rCar[0][i]);

                    // Пытаемся преобразовать второй элемент строки в double и записать в поле V
                    if (Double.TryParse(rCar[1], out bCars->V))
                    {
                        // Пытаемся преобразовать третий элемент строки в int и записать в поле S
                        if (Int32.TryParse(rCar[2], out bCars->S))
                            Res = 0; // Если оба преобразования успешны, результат 0
                        else
                            Res = 2; // Ошибка: не удалось преобразовать третий элемент в int
                    }
                    else
                        Res = 1; // Ошибка: не удалось преобразовать второй элемент в double
                }
                else
                    Res = 3; // Ошибка: в строке не три элемента

                // Если есть ошибка (Res не равен 0)
                if (Res != 0)
                {
                    _dgErr.Visible = true; // Показываем DataGridView для отображения ошибок
                    _dgErr.RowCount = _dgErr.RowCount + 1; // Увеличиваем количество строк в DataGridView
                    _dgErr.Rows[j].Cells[0].Value = Res.ToString() + " - " + bCarsTXT; // Записываем ошибку и строку в таблицу
                    j = j + 1; // Увеличиваем счетчик ошибок
                }
                else
                {
                    // Копируем данные из структуры bCars в массив байтов bbCars
                    Marshal.Copy((IntPtr)bCars, bbCars, 0, bbCars.Length);
                    // Записываем массив байтов в файл
                    fCars.Write(bbCars, 0, bbCars.Length);
                }
            }

            // Закрываем файл
            fCars.Close();
        }*/
    }
}
