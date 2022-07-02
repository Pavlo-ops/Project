using System;
using System.Collections.Generic;
using System.Collections;
using Newtonsoft;
using Newtonsoft.Json;

namespace project {

    class Basket  {
       public List<NewCar> NewCars { get; set; } = new List<NewCar>(); // Список нових автомобілів.
       public List<OldCar> OldCars { get; set; } = new List<OldCar>(); // Список старих автомобілів.

       // Перегрузка методів пошуку автомобіля.    
       private NewCar? SearchCar(List<NewCar> car, string id)
       {
           NewCar? res = null;
           for (int i = 0; i < car.Count; i++)
           {
               if (car[i].IdCar == id)
               {
                   res = car[i];
               }
           }
           return res; 
       }

       private OldCar? SearchCar(List<OldCar> car, string id)
       {
           OldCar? res = null;
           for (int i = 0; i < car.Count; i++)
           {
               if (car[i].IdCar == id)
               {
                   res = car[i];
               }
           }
           return res; 
       }

       // Перегрузка метода додавання авто до кошика.
       public bool Add(List<NewCar> cars, string id)
       {
           bool check = true;
           NewCar? car = SearchCar(cars, id);
           if (car != null)
           {
               this.NewCars.Add(car);
           }else
           {
               check = false;
           }
           return check; 
       }

       public bool Add(List<OldCar> cars, string id)
       {
           bool check = true;
           OldCar? car = SearchCar(cars, id);
           if (car != null)
           {
               this.OldCars.Add(car);
           }else
           {
               check = false;
           }
           return check;
       }

       public void Remove(string id)
       {
           NewCar? car1 = SearchCar(this.NewCars, id);
           OldCar? car2 = SearchCar(this.OldCars, id);
           int index = -1; // Індекс для знаходження  автомобіля у списку.
           if (car1 != null || car2 != null)
           {
               if (car1 != null)
               {
                   index = this.NewCars.IndexOf(car1);
                   NewCars.Remove(this.NewCars[index]); 
               }else if (car2 != null)
               {
                   index = this.OldCars.IndexOf(car2);
                   OldCars.Remove(this.OldCars[index]);
               }
               Console.WriteLine("The car was successfully removed from the basket");
           }else
           {
               Console.WriteLine("Sorry,such ID not exist in basket");
           }
       }
       
       // Метод виведення інформації про всі авто в кошику.
       public void Check()
       {
           for (int i = 0; i < this.NewCars.Count; i++)
           {
               this.NewCars[i].CheckInfoCar();
           }
           for(int j = 0; j < this.OldCars.Count; j++)
           {
               this.OldCars[j].CheckInfoCar();
           } 
       }
    }
}