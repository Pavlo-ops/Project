using System;
using System.Collections.Generic;
using System.Collections;
using Newtonsoft;
using Newtonsoft.Json;

namespace project {

  class Program 
  {
          
      // Функція, яка робить перевірку на значення null.
      public string CheckNull(string? value, string nullValue)
      {
          if (value == null || value == "")
          {
              value = nullValue;
          }
          return value;
      }
    
      // Функція для запобігання вводу літер.
      public ulong CheckNum(string? value)
      {
          ulong num;
          ulong.TryParse(value, out num);
          return num;
      }

      static void Main()
      {
          // Десеріалізація. 
          var file1 = @"D:\Cursova\Project\Data.json";
          ListsCar? cars = JsonConvert.DeserializeObject<ListsCar>(File.ReadAllText(file1));
          if (cars == null)
          {
              cars = new ListsCar();
          }

          // Логіка вибору основної команди і перехід до потрібного класу для роботи з нею.
          Console.WriteLine("Welcome to the car showroom.You can order new and used cars and trucks.You have the functions: Find the car you want[find car],\nAdd to car on the car showroom[add car], the basket favorite cars has the functions: add car to the basket[basket add],\nremove the car[basket rm], view the entire basket[basket check],contact car showroom[contact].");
          bool swt = false; // Перемикач, який в потрібний момент припинить роботу програми.
          Basket favoriteCars = new Basket();
          while (swt == false)
          {
              Console.Write("Command:");
              string? com = Console.ReadLine(); // Поле введення основної команди. 
              if (com == "add car")
              {
                  FormAddCar fun = new FormAddCar();
                  fun.Add(cars);   
              }else if (com == "find car")
              {
                  FormFindCar find = new FormFindCar();
                  find.Find(cars);
              }else if (com == "basket add" || com == "basket rm" || com == "basket check") 
              {
                  FormBasket basket = new FormBasket();
                  basket.Main(cars, com, favoriteCars);
              }else if (com == "contact")
              {
                  Console.WriteLine("Contacts car showroom:\n Email:car743@gmail.com\n Number phone:380956742684");
              }else if (com == "exit")
              {
                  break;
              }  
          }

          // Серіалізація.
          using (StreamWriter file = File.CreateText(@"D:\Cursova\Project\Data.json"))
          {
              JsonSerializer serializer = new JsonSerializer();
              serializer.Serialize(file, cars);
          } 
      }
  }
}

