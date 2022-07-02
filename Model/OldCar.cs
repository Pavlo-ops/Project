using System;
using System.Collections.Generic;
using System.Collections;
using Newtonsoft;
using Newtonsoft.Json;

namespace project {

    class OldCar: AbstractCar {
        private string email = "Not specified";

        public OldCar(
            string brandCar,  
            string model, 
            ulong yearCar, 
            string colorCar, 
            string typeCar, 
            string address, 
            string fuelCar, 
            string typeDrive, 
            string typeBodyCar, 
            ulong maxLoadCar, 
            ulong priceCar, 
            string nameOwner, 
            string lastNameOwner, 
            string comOwner, 
            ulong number, 
            string id, 
            string email)
        {
            Brand = brandCar;
            Model = model;
            Year = yearCar;
            Color = colorCar;
            TypeCar = typeCar;
            Address = address;
            Fuel = fuelCar;
            DriveType = typeDrive;
            TypeBody = typeBodyCar;
            MaxLoad = maxLoadCar;
            Price = priceCar;
            Name = nameOwner;
            LastName = lastNameOwner;
            CommentOwner = comOwner;
            NumberPhone = number;
            IdCar = id;
            Email = email; 
        }

       public string Name { get; set; } = "Not specified"; // Доступ до поля ім'я власника.
       public string LastName { get; set; } = "Not specified"; // Доступ до поля прізвища власника.
       public string CommentOwner { get; set; } = "Not specified"; // Доступ до поля коментар власника.

       // Доступ до поля email власника.    
       public string Email 
       {
           get{ return email; }
           set
           {
               bool res = value.EndsWith("@gmail.com");
               if (res == false || value == null)
               {
                   email = "Not specified";
               }else 
               {
                   email = value;
               }
           }
       }

       // Виведення інформації разом із основною інформацією у класі AbstractCar.      
       public override void CheckInfoCar()
        {
            base.CheckInfoCar();
            Console.WriteLine("Info about owner:\n Name: {0}\n Last name: {1}\n Email: {2}\n Ower comment: {3}\n", 
            Name, 
            LastName, 
            Email, 
            CommentOwner);
        }

        public override string ConvertObjectToString()
        {
            string objectStr = base.ConvertObjectToString();
            objectStr = objectStr + "\nInfo about owner: \n" + "Name:" + Name + "\nLast name: " + LastName + "\nEmail: " + Email + "\nOwer comment: " + CommentOwner;
            return objectStr;
        }
    }
}