using System;
using System.Collections.Generic;
using System.Collections;
using Newtonsoft;
using Newtonsoft.Json;

namespace project {

    class NewCar: AbstractCar {
        public  string Guarantee { get; set; } = "Not specified"; // Доступ до поля гарантії на автомобіля.

        public NewCar(
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
            string guarantCar, 
            ulong number, 
            string id)
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
            Guarantee = guarantCar;
            NumberPhone = number;
            IdCar = id;
        }

        // Виведення інформації разом із основною інформацією у класі AbstractCar.  
        public override void CheckInfoCar()
        {
            base.CheckInfoCar();
            Console.WriteLine("Guarantee: {0}", Guarantee);
        }

        public override string ConvertObjectToString()
        {
            string objectStr = base.ConvertObjectToString();
            objectStr = objectStr + "\nGuarantee: " + Guarantee;
            return objectStr; 
        }
    }
}