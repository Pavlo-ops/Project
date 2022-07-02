using System;
using System.Collections.Generic;
using System.Collections;
using Newtonsoft;
using Newtonsoft.Json;

namespace project {

    class Form: Program {

        public string[] AddBeginVal() {
            string[] datum;
            string? typeBody = "Not specified";
            string? typeCar = "Not specified";
            string? guarant = "Not specified";
            Console.Write("Fill out the form to add or find the car to the dealership.\nSpecify new machine[new] or old[old]:");
            string? specifyCar = Console.ReadLine();
            
            // Формування об'єкта за вимогами користувача. 
            if ((specifyCar != "new" && specifyCar != "old") || specifyCar == null)
            {
                while (1 > 0)
                {
                    Console.Write("Sorry, this feature is required, please enter a valid command:");
                    specifyCar = Console.ReadLine();
                    if (specifyCar == "new" || specifyCar == "old")
                    {
                        break;
                    }
                }
            }

            // Визначення тип автомобіля грузового чи легкового. 
            Console.Write("Choose type car Truck[T] or Car[C]:");
            string? tCar = Console.ReadLine();
            if ((tCar == null) || (tCar != "T" && tCar != "C"))
            {
                while (1 > 0)
                {
                    Console.WriteLine("Sorry, this is a mandatory requirement to choose the correct option, [T] or [C]:");
                    tCar = Console.ReadLine();
                    if (tCar == "T" || tCar == "C")
                    {
                        break;
                    }
                }
            }

            // Запити для користувача, щоб сформувати коректний список характеристик автомобіля.  
            Console.WriteLine("The following parameters are optional, if the fields are not filled, the default value (Not specified) will be used.");
            Console.Write("Brand:");
            string? brand = CheckNull(Console.ReadLine(), "Not specified");
            Console.Write("Model:");
            string? model = CheckNull(Console.ReadLine(), "Not specified");
            Console.Write("Color:");
            string? color = CheckNull(Console.ReadLine(), "Not specified");
            Console.Write("Fuel [Diesel] or [Gasoline]:");
            string? fuel = CheckNull(Console.ReadLine(), "Not specified");
            Console.Write("Transmission [Automaton] or [Mechanics]:");
            string? transmis = CheckNull(Console.ReadLine(), "Not specified");

            // Формування певних характеристик, які можуть бути властиві лише певному типу автомобілів.
            if (tCar == "T")
            {
                typeCar = "Truck";
            }else if (tCar == "C")
            {
                Console.Write("Type body, Sedan[Sedan] Compartment[Compartment] Cabriolet[Cabriolet] Station wagon[Station wagon]:");
                typeBody = CheckNull(Console.ReadLine(), "Not specified");
                typeCar = "Car";
            }

            if (specifyCar == "new")
            {
                Console.Write("Guarantee, yes[Y] or no[N]:");
                guarant = CheckNull(Console.ReadLine(), "Not specified");
                if (guarant == "Y")
                {
                    guarant = "Yes";
                }else if (guarant == "N")
                {
                    guarant = "No";
                }             
            }
            datum = new string[9] {specifyCar, brand, model, color, typeCar, fuel, transmis, typeBody, guarant};
            return datum;
        }
    }
}        