using System;
using System.IO;
using System.Text;
using EKRLib;

namespace App
{
    /// <summary>
    /// Основной класс консольного приложения.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Основной метод консольного приложения.
        /// </summary>
        /// <param name="args"> Аргументы запуска. </param>
        static void Main(string[] args)
        {
            Console.WriteLine("Hi! This is the program named \"Transport\".\n");
            Console.WriteLine("Press \"ESC\" to exit the program.");
            Console.WriteLine("Press any other key to get started.");
            if (Console.ReadKey().Key == ConsoleKey.Escape)
                return;

            // Повторное решение.
            do
            {
                Console.Clear();
                // Генерируем массив транспорта и отдельно записываем информацию о машинах и моторных лодках.
                var (carsInfo, motorBoatInfo) = GenerateVehicles();
                // Выводим информацию в консоль.
                WriteInfo(carsInfo, motorBoatInfo);
            } while (AskForRestart());
        }

        /// <summary>
        /// Метод создаёт массив транспортных средств, "заводит их", распределяет на машины и моторные лодки
        /// и отдельно взовращает информацию о них.
        /// </summary>
        /// <returns> Кортеж из двух строков элементов: информации о машинах и о моторных лодках. </returns>
        static (string, string) GenerateVehicles()
        {
            var rnd = new Random();
            var vehicles = new Transport[rnd.Next(6, 10)];
            // Информация о машинах/моторных лодках.
            var carInfo = new StringBuilder();
            var motorBoatInfo = new StringBuilder();
            // Цикл работает, пока массив не будет полностью заполнен.
            for (var i = 0; i < vehicles.Length; i++)
            {
                var parameters = Transport.GenerateParameters();
                try
                {
                    // Генерируем автомобиль или моторную лодку.
                    if (rnd.Next(0, 2) == 0)
                        vehicles[i] = new Car(parameters.Item1, parameters.Item2);
                    else
                        vehicles[i] = new MotorBoat(parameters.Item1, parameters.Item2);
                }
                // Если возникает исключение, выводим соответствующее сообщение и уменьшаем i,
                // чтобы повторить генерацию i-го элемента массива.
                catch (TransportException e)
                {
                    Console.WriteLine(e.Message);
                    i--;
                    continue;
                }
                // "Заводим" транспортное средство.
                Console.WriteLine(vehicles[i].StartEngine());
                // Получаем информацию о транспортном средстве и записываем её в соответствующий StringBuilder.
                var info = vehicles[i].ToString();
                if (info.StartsWith("Car"))
                    carInfo.Append($"{info}\n");
                else
                    motorBoatInfo.Append($"{info}\n");
            }
            return (carInfo.ToString(), motorBoatInfo.ToString());
        }

        /// <summary>
        /// Записывает информацию об автомобилях/моторных лодках в соответствующие файлы.
        /// </summary>
        /// <param name="carInfo"> Информация об автомобилях. </param>
        /// <param name="motorBoatInfo"> Информация о моторных лодках. </param>
        static void WriteInfo(string carInfo, string motorBoatInfo)
        {
            try
            {
                var separator = Path.DirectorySeparatorChar;
                File.WriteAllText($"..{separator}..{separator}..{separator}..{separator}Cars.txt",
                    carInfo, Encoding.Unicode);
                File.WriteAllText($"..{separator}..{separator}..{separator}..{separator}MotorBoats.txt", 
                    motorBoatInfo, Encoding.Unicode);
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("UnauthorizedAccessException handled: you have no access to the file.");
            }
            catch (IOException)
            {
                Console.WriteLine("IOException handled: you aren't allowed to overwrite the file atm.");
            }
        }

        /// <summary>
        /// Узнаёт у пользователя, желает ли он повторить работу программы.
        /// </summary>
        /// <returns> Возвращает true, если пользователь хочет перезапустить программу. </returns>
        static bool AskForRestart()
        {
            Console.Write("\n* * * * * *\n\n" +
                              "Press \"ESC\" to exit the program.\n" +
                              "Press any other key to restart it.\n");
            var pressedKey = Console.ReadKey().Key;
            return pressedKey is not ConsoleKey.Escape;
        }
    }
}