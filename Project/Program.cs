﻿using POP_SF8_2016.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Store s1 = new Store()
            {
                Id = 1,
                Name = "Formaaaaaaaaa FTNale",
                Address = "Trg Dositeja obradovica 6",
                Account = "840-00076899-83",
                Email = "kontakt@uns.ac.ftn.ac.rs",
                TaxingId = 12223124,
                Phone = "021/445-342",
                Website = "www.nekisalon.com",
                Deleted = false

            };
            // Inicijalizujem xml pisac i odredjujem koji tip objekata ce upisivati
            System.Xml.Serialization.XmlSerializer xmlWriter = new System.Xml.Serialization.XmlSerializer(typeof(Store));

            //Pravim fajl i linkujem file stream na taj fajl
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "//C#//POP-SF8-2016//Project/DATA//myfile.xml";

            System.IO.FileStream fileVar = System.IO.File.Create(path);

            //Serijalizujem objekat s1 u fajl
            xmlWriter.Serialize(fileVar, s1);
            fileVar.Close();




            Console.WriteLine($"Welcome to our furniture store {s1.Name}");
        }

        private static void PrintMainMenu()
        {
            int choice = int.Parse(Console.ReadLine());
            do
            {
                Console.WriteLine("1. Furniture");
                Console.WriteLine("2. Furniture type");
                Console.WriteLine("3. ...");
                Console.WriteLine("0. Exit");
                Console.ReadLine();
            }
            while (choice < 0 || choice > 3);
                switch(choice){
                    case 1:
                        PrintFurnitureMenu();
                        break;
                    case 2:
                        PrintFurnitureTypeMenu();
                        break;
                    default:
                        break;
                }
            }
        

        private static void PrintFurnitureTypeMenu()
        {
            throw new NotImplementedException();
        }

        private static void PrintFurnitureMenu()
        {
            int choice = int.Parse(Console.ReadLine());
            do
            {
                Console.WriteLine("1. List furniture");
                Console.WriteLine("2. Add new furniture");
                Console.WriteLine("3. Edit existing furniture");
                Console.WriteLine("4. Delete existing furniture");
                Console.WriteLine("0. Main menu");
                Console.WriteLine();
            }
            while (choice < 0 || choice > 4);
            switch (choice) {
                case 1:
                    ListFurniture();
                    break;
                case 2:
                    AddFurniture();
                    break;
                case 3:
                    EditFurniture();
                    break;
                case 4:
                    DeleteFurniture();
                    break;
                default:
                    PrintMainMenu();
                    break;
            }
        }

        private static void DeleteFurniture()
        {
            throw new NotImplementedException();
        }

        private static void EditFurniture()
        {
            throw new NotImplementedException();
        }

        private static void AddFurniture()
        {
            throw new NotImplementedException();
        }

        private static void ListFurniture()
        {
            throw new NotImplementedException();
        }
    }
}