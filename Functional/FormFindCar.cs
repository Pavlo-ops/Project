using System;
using System.Collections.Generic;
using System.Collections;
using Newtonsoft;
using Newtonsoft.Json;
using System.IO;

namespace project {

    class FormFindCar: Program {

        // Функція створення діапазону чисел.
        private ulong[] Range(string value)
        {    
            ulong[] array = new ulong[2];
            while (1 > 0)
            {
                Console.Write("Do you want to choose a range of {0}? Yes[Y] or No[N]:", value);
                string? command = Console.ReadLine();
                if (command == "Y")
                {
                    Console.WriteLine("You need to enter the {0} range of your desired car. WARNING !!! Note that if the value entered is less than or equal or not integer values\nto 0, the year will not be taken into account when searching.", value);
                    Console.Write("Initial:");
                    array[0] = CheckNum(Console.ReadLine());
                    Console.Write("Ending:");
                    array[1] = CheckNum(Console.ReadLine());
                
                }
                if (command == "N" || command == "Y")
                {
                    break;
                }
            }

            if (array[0] == 0 || array[1] == 0)
            {
                array[0] = 0;
                array[1] = 0;
            }else if (array[0] > array[1])
            {
                ulong num;
                num = array[0];
                array[0] = array[1];
                array[1] = num;
            }
            return array;
        }   

        public void Find(ListsCar cars){
            List<string> stringFormObject = new List<string>(); // Список об'єктів у вигляді рядка.
            Form info = new Form();
            string[] infoAboutCar;
            infoAboutCar = info.AddBeginVal(); // Виклик метода, який надає доступ до форми для заповнення основної інформації.

            // Змінні, які будуть містити діапазони заданих значень.
            ulong[] year = Range("year");
            ulong[] price = Range("price");
            ulong[] maxLoad = new ulong[2]{0, 0};
            if (infoAboutCar[4] == "Truck")
            {
                maxLoad = Range("maximum load track");
            }

            // Вибір списку автомобілів за допомогою перегруженого методу.
            if (infoAboutCar[0] == "new")
            {
                stringFormObject = cars.Search(cars.NewCars, infoAboutCar, year, price, maxLoad, stringFormObject);
            }else if (infoAboutCar[0] == "old")
            {
                stringFormObject = cars.Search(cars.OldCars, infoAboutCar, year, price, maxLoad, stringFormObject);
            }

            // Запис знайдених машин у файл.
            if (stringFormObject.Count > 0){
                while (1 > 0){
                    Console.Write("Do you want to save these cars to a .txt file that can be used separately?\nYes[Y] or No[N]:");
                    string? writeOb = Console.ReadLine();
                    if (writeOb == "Y")
                    {
                        for (int i = 0; i < stringFormObject.Count; i++)
                        {
                            File.AppendAllText("test.txt", stringFormObject[i] + Environment.NewLine);
                        }            
                    }
                    if (writeOb == "N" || writeOb == "Y")
                    {
                        break;
                    }
                }
            }else {
                Console.WriteLine("Sorry, it looks like the cars were not found at your request");
            }
        }
    }
}