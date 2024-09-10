using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MyFileManagment
{
    internal class FileViewer
    {
        public unsafe struct Car
        {
            public string Model;
            public string BodyType;
            public double EngineCapacity;
            public int Price;
            public bool HasABS;
        }

        private Car ConvertBytesToCar(byte[] carDataBytes)
        {
            Car car = new Car();

            car.Model = "Lada";
            car.BodyType = "Седан";
            car.EngineCapacity = 1.6;
            car.Price = 20000;
            car.HasABS = false;

            return car;
        }

        public unsafe void Load (string filename, DataGridView carsGrid)
        {
            FileStream fileStream = File.OpenRead(filename);

            int numberOfCars = (int)(fileStream.Length / sizeof(Car));

            // Set row counts for data grid view
            carsGrid.RowCount = numberOfCars;

            byte[] carDataBytes = new byte[sizeof(Car)];

            for (int i = 0; i < numberOfCars; i++)
            {
                fileStream.Read(carDataBytes, 0, carDataBytes.Length);

                Car car = ConvertBytesToCar(carDataBytes);

                // Add data to data grid view
                carsGrid.Rows[i].Cells[0].Value = car.Model;  // 
                carsGrid.Rows[i].Cells[1].Value = car.Price.ToString();  // 
                carsGrid.Rows[i].Cells[2].Value = car.BodyType;  // 
                carsGrid.Rows[i].Cells[3].Value = car.EngineCapacity.ToString();  // 
                carsGrid.Rows[i].Cells[4].Value = car.HasABS.ToString();  // 
            }

            
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
