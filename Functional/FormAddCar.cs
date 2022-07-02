using System;
using System.Collections.Generic;
using System.Collections;
using Newtonsoft;
using Newtonsoft.Json;

namespace project {

    class FormAddCar: Program {

        public ListsCar Add(ListsCar cars)
        {
            Form inf = new Form();
            string[] info = inf.AddBeginVal();
            Random random = new Random();
            string? addres;
            ulong maxL = 0;
            Console.Write("Graduation year:");
            ulong year = CheckNum(Console.ReadLine());
            Console.WriteLine("Price will 0 if you will write not correct value.The price must be in dollars");
            Console.Write("Price:");
            ulong price = CheckNum(Console.ReadLine());
            string idCar = Convert.ToString(random.Next(100000,999999)); // Формування унікального коду машини.
            Console.WriteLine("Now we will form your address");

            // Створення адреси компанії чи власника автомобіля.
            while (1 > 0)
            {
                Console.Write("Country:");
                string? country = CheckNull(Console.ReadLine(), " ");
                Console.Write("City:");
                string? city = CheckNull(Console.ReadLine(), " ");
                Console.Write("Street:");
                string? street = CheckNull(Console.ReadLine(), " ");
                Console.Write("Number house:");
                string? numHouse = CheckNull(Console.ReadLine(), " ");
                Console.WriteLine(country + " " + city + " " + street + " " + numHouse);
                Console.Write("Is this the correct address? Yes[Y] or No[N]:");
                string? res = Console.ReadLine();
                if (res == "Y")
                {
                    addres = country + " " + city + " " + street + " " + numHouse;
                    break;
                }  
            }
            Console.WriteLine("Enter the phone number of the owner or company, taking into account the code of your country. ATTENTION !!! Use only numbers, if you write not correct value, number phone will 0");
            Console.Write("Number phone:");
            ulong number = CheckNum(Console.ReadLine());
            if (info[4] == "Truck")
            {
                Console.Write("Maximum load(tons):");
                maxL = CheckNum(Console.ReadLine());
            }

            // Остаточне формування заявки постачальника, яка буде внесена до бази автомобілів і стане доступною для користувачів.
            if (info[0] == "new")
            {
                NewCar yourCarNew = new NewCar(
                    info[1], 
                    info[2], 
                    year, 
                    info[3], 
                    info[4], 
                    addres, 
                    info[5], 
                    info[6], 
                    info[7], 
                    maxL, 
                    price, 
                    info[8], 
                    number, 
                    idCar);
                cars.Add(yourCarNew);               
            }else 
            {
                // Формування інформації про власника автомобіля.
                Console.Write("Name owner:");
                string? nameOwn = CheckNull(Console.ReadLine(), "Not specified");
                Console.Write("Last name owner:");
                string? lastName = CheckNull(Console.ReadLine(), "Not specified");
                Console.WriteLine("You can only specify mail ending in @gmail.com, otherwise the mail will take on value [Not specified]");
                Console.Write("Email:");
                string? email = CheckNull(Console.ReadLine(), "Not specified");
                Console.Write("Ower comment about car:");
                string? comment = CheckNull(Console.ReadLine(), "Not specified");
                OldCar yourCarOld = new OldCar(
                    info[1], 
                    info[2], 
                    year, 
                    info[3], 
                    info[4], 
                    addres, 
                    info[5], 
                    info[6], 
                    info[7], 
                    maxL, 
                    price, 
                    nameOwn, 
                    lastName, 
                    comment, 
                    number, 
                    idCar, 
                    email);
                cars.Add(yourCarOld);
            }
            Console.WriteLine("The car was successfully added to the  car showroom");
            return cars;      
        }
    }
}