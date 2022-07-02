using System;
using System.Collections.Generic;
using System.Collections;
using Newtonsoft;
using Newtonsoft.Json;

namespace project
{
    class FormBasket: Program
    {
        public Basket Main(ListsCar cars, string com, Basket favoriteCar)
        {
            if (com != "basket check"){
                Console.WriteLine("Enter the ID of the machine you want to add or remove");
                Console.Write("Unique car number:");
                ulong idNum = CheckNum(Console.ReadLine());
                string id = Convert.ToString(idNum);
                if (com == "basket add")
                {
                    bool newCar = favoriteCar.Add(cars.NewCars, id);
                    bool oldCar = favoriteCar.Add(cars.OldCars, id);
                    if (newCar == false && oldCar == false)
                    {
                        Console.WriteLine("Sorry, the car was not found behind this ID");
                    }else
                    {
                        Console.WriteLine("The car was successfully added to the basket");
                    }
                }else if (com == "basket rm")
                {
                    favoriteCar.Remove(id);
                }
            }else {
               
                if (favoriteCar.NewCars.Count == 0 && favoriteCar.OldCars.Count == 0)
                {
                    Console.WriteLine("Your basket is empty");
                }else
                {
                    // Пошук необхідного автомобіля.
                    favoriteCar.Check();
                }
            }
            return favoriteCar;
        }
    }
}