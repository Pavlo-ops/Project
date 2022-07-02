using System;
using System.Collections.Generic;
using System.Collections;
using Newtonsoft;
using Newtonsoft.Json;

namespace project {

    abstract class AbstractCar {
        private ulong year;
        private string driveType = "Not specified";
        private ulong price;
        private string typeBody = "Not specified";
        private ulong maxLoad;   
        private string fuel = "Not specified";
        private string typeCar = "Not specified";
        private ulong numberPhone = 0;

        public string Brand { get; set; } = "Not specified"; // Доступ до поля назви автомобіля.
        public string Model { get; set; } = "Not specified"; // Доступ до поля моделі автомобіля.
        public string Color { get; set; } = "Not specified"; // Доступ до поля колір автомобіля.
        public string Address { get; set; } = "Not specified"; // Доступ до поля  адреси компанії або власника.
        public  string IdCar { get; set; } = "0"; // Доступ до поля унікального номера  автомобіля.

        // Доступ до поля типу автомобіля.
        public string TypeCar
        {
            get{ return typeCar; }
            set
            {
                if ((value != "Truck" && value != "Car") || value == null)
                {
                    typeCar = "Not specified";
                }else 
                {
                    typeCar = value;
                }
            }
        }

        // Доступ до поля трансмісії автомобіля.
        public string DriveType
        {
            get{ return driveType; }
            set
            {
                if ((value != "Automaton" && value != "Mechanics") || value == null)
                {
                    driveType = "Not specified";
                }else 
                {
                    driveType = value;
                }
            }
        }
         
        // Доступ до поля ціни.
        public ulong Price
        {
            get{ return price; }
            set
            {
                if (value < 0){
                    price = 0;
                }else 
                {
                    price = value;
                }
            }
        }

        // Доступ до поля року випуску автомобіля.
        public ulong Year
        {
            get{ return year; }
            set 
            {
                if (value < 0)
                {
                    year = 0;
                }else 
                {
                    year = value;
                } 
            }
        }

        // Доступ до поля типа кузову.
        public string TypeBody
        {
            get{ return typeBody; }
            set
            {
                if ((value != "Sedan" && value !="Compartment" && value != "Cabriolet" && value != "Station wagon"))
                {
                    typeBody = "Not specified";
                }else 
                {
                    typeBody = value;
                }
            }
        }

        // Доступ до поля максимального навантаження тягача.
        public ulong MaxLoad
        {
            get{ return maxLoad; }
            set
            {
                if (value < 0)
                {
                    maxLoad = 0;
                }else 
                {
                    maxLoad = value;
                }
            }
        }

        // Доступ до поля типу палива.
        public string Fuel
        {
            get { return fuel; }
            set
            {
                if (value != "Diesel" && value != "Gasoline")
                {
                    fuel = "Not specified";
                }else 
                {
                   fuel = value; 
                }
            } 
        }

        // Доступ до поля номер телефону.
        public ulong NumberPhone 
        {
            get{ return numberPhone; }
            set 
            {    
                // Обрахунок кількісті цифр у числі.
                ulong remainder;
                ulong test = value;
                int amountNum = 0;
                while (test > 0)
                {
                    remainder = (test % 10);
                    test = (test - remainder) / 10;
                    amountNum++;  
                }
                if (amountNum > 9 && amountNum < 13)
                {
                    numberPhone = value;
                } else 
                {
                    numberPhone = 0;
                }
            }
        }
        
        // Метод виведення всіх доступних характеристик автомобіля.
        public virtual void CheckInfoCar()
        {
            Console.WriteLine("\nUnique car number: {0}\nBrand: {1}\nModel: {2}\nColor: {3}\nType car (car or truck): {4}\nFuel for car: {5}\nTransmission: {6}\nPrice: {7}$\nGraduation year: {8}\nType body : {9}\nMaximum load: {10} tons\nContacts:\n Address: {11}\n Number phone: {12}", 
            IdCar, 
            Brand, 
            Model, 
            Color, 
            TypeCar, 
            Fuel, 
            DriveType, 
            Price, 
            Year, 
            TypeBody, 
            MaxLoad, 
            Address, 
            NumberPhone);
        }

        public virtual string ConvertObjectToString()
        {
            string objectStr = "\nUnique car number: " + IdCar + "\nBrand: " + Brand + "\nModel: " + Model + "\nColor: " + Color + "\nType car: " + TypeCar + "\nFuel for car: " + Fuel + "\nTransmission: " + DriveType + "\nPrice: " + Price + "\nGraduation year: " + Year + "\nType body: " + TypeBody + "\nMaximum load: " + MaxLoad + "\nContacts:" + "\nAddress: " + Address + "\nNumber phone: +" + NumberPhone;
            return objectStr; 
        } 
    }
}