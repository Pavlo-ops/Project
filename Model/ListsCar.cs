using System;
using System.Collections.Generic;
using System.Collections;
using Newtonsoft;
using Newtonsoft.Json;

namespace project {
    class ListsCar {
        public List<NewCar> NewCars { get; set; } = new List<NewCar>(); // Список нових автомобілів.
        public List<OldCar> OldCars { get; set; } = new List<OldCar>(); // Список старих автомобілів.

        // Перегружені методи додавання об'єкта до списку.
        public void Add(NewCar car)
        {
            NewCars.Add(car);
        }

        public void Add(OldCar car) 
        {
            OldCars.Add(car);
        }

        // Метод видалення об'єкта із списку.
        public void Delete(string idCar)
        {
            bool switchCar = false;
            for (int i = 0; i < NewCars.Count; i++)
            {
                if (NewCars[i].IdCar == idCar)
                {
                    NewCars.Remove(NewCars[i]);
                    switchCar = true;
                    break;
                }
            }
            if (switchCar == false)
            {
                for (int j = 0; j < OldCars.Count; j++)
                {
                    if (OldCars[j].IdCar == idCar)
                    {
                        OldCars.Remove(OldCars[j]);
                        switchCar = true;
                        break;    
                    }
                }
                if (switchCar == false)
                {
                    Console.WriteLine("Sorry, ID was not found or incorrect value");
                }
            }
        }

        //  Пошук  за списком нових  автомобілів.
        public List<string> Search(List<NewCar> newCar, string[] infoAboutCar, ulong[] year, ulong[] price, ulong[] maxL, List<string> stringFormObject)
        {
            for (int i = 0; i < newCar.Count; i++)
            {
                if (newCar[i].TypeCar == infoAboutCar[4])
                {
                    if (infoAboutCar[1] == newCar[i].Brand || infoAboutCar[1] == "Not specified")
                    {
                        if (infoAboutCar[2] == newCar[i].Model || infoAboutCar[2] == "Not specified")
                        {
                            if (infoAboutCar[3] == newCar[i].Color || infoAboutCar[3] == "Not specified")
                            {
                                if (infoAboutCar[5] == newCar[i].Fuel || infoAboutCar[5] == "Not specified")
                                {
                                    if (infoAboutCar[6] == newCar[i].DriveType || infoAboutCar[6] == "Not specified")
                                    {
                                        if (infoAboutCar[7] == newCar[i].TypeBody || infoAboutCar[7] == "Not specified")
                                        {
                                            if (infoAboutCar[8] == newCar[i].Guarantee || infoAboutCar[8] == "Not specified")
                                            {
                                                if ((year[0] < newCar[i].Year && year[1] > newCar[i].Year) || newCar[i].Year == 0 || year[1] == 0)
                                                {
                                                    if ((price[0] < newCar[i].Price && price[1] > newCar[i].Price) || newCar[i].Price == 0 || price[1] == 0)
                                                    {
                                                        if ((maxL[0] < newCar[i].MaxLoad && maxL[1] > newCar[i].MaxLoad) || newCar[i].MaxLoad == 0 || maxL[1] == 0)
                                                        {
                                                            newCar[i].CheckInfoCar();
                                                            stringFormObject.Add(newCar[i].ConvertObjectToString());
                                                        } 
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return stringFormObject; 
        }
         
        //  Пошук  за списком старих  автомобілів.
        public List<string> Search(List<OldCar> oldCar, string[] infoAboutCar, ulong[] year, ulong[] price, ulong[] maxL, List<string> stringFormObject)
        {
            for (int i = 0; i < oldCar.Count; i++)
            {
                if (oldCar[i].TypeCar == infoAboutCar[4])
                {
                    if (infoAboutCar[1] == oldCar[i].Brand || infoAboutCar[1] == "Not specified")
                    {
                        if (infoAboutCar[2] == oldCar[i].Model || infoAboutCar[2] == "Not specified")
                        {
                            if (infoAboutCar[3] == oldCar[i].Color || infoAboutCar[3] == "Not specified")
                            {
                                if (infoAboutCar[5] == oldCar[i].Fuel || infoAboutCar[5] == "Not specified")
                                {
                                    if (infoAboutCar[6] == oldCar[i].DriveType || infoAboutCar[6] == "Not specified")
                                    {
                                        if (infoAboutCar[7] == oldCar[i].TypeBody || infoAboutCar[7] == "Not specified")
                                        {   
                                            if ((year[0] < oldCar[i].Year && year[1] > oldCar[i].Year) || oldCar[i].Year == 0 || year[1] == 0)
                                            {
                                                if ((price[0] < oldCar[i].Price && price[1] > oldCar[i].Price) || oldCar[i].Price == 0 || price[1] == 0)
                                                {
                                                    if ((maxL[0] < oldCar[i].MaxLoad && maxL[1] > oldCar[i].MaxLoad) || oldCar[i].MaxLoad == 0 || maxL[1] == 0)
                                                    {
                                                        oldCar[i].CheckInfoCar();
                                                        stringFormObject.Add(oldCar[i].ConvertObjectToString());
                                                    }                                                  
                                                }
                                            }                                         
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return stringFormObject; 
        }
    }
}