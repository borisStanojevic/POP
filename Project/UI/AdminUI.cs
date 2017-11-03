using Project.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.UI
{
    //Admin rukuje korisnicima, namjestajem i podacima o akcijskim prodajama.
    class AdminUI
    {
        private static void PrintMainMenu()
        {
            Console.WriteLine("=====================");
            Console.WriteLine("1. Furniture");
            Console.WriteLine("2. Furniture types");
            Console.WriteLine("3. Users");
            Console.WriteLine("4. Action sales");
            Console.WriteLine("5. Additional services");
            Console.WriteLine("0. Exit");
            Console.WriteLine("=====================\n");
        }

        public void Run()
        {
            MainMenu();
        }

        private void MainMenu()
        {
            PrintMainMenu();
            int choice = int.Parse(Console.ReadLine());

            while (choice < 0 || choice > 5)
                choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    FurnitureMenu();
                    break;
                case 2:
                    FurnitureTypesMenu();
                    break;
                case 3:
                    UsersMenu();
                    break;
                case 4:
                    ActionSalesMenu();
                    break;
                case 5:
                    AdditionalServicesMenu();
                    break;
                default:
                    Environment.Exit(0);
                    break;
            }
        }

        private void FurnitureMenu()
        {
            Console.WriteLine("============================");
            Console.WriteLine("1. List furniture");
            Console.WriteLine("2. Add new furniture");
            Console.WriteLine("3. Edit existing furniture");
            Console.WriteLine("4. Delete existing furniture");
            Console.WriteLine("0. Main menu");
            Console.WriteLine("============================\n");

            int choice = int.Parse(Console.ReadLine());

            while (choice < 0 || choice > 4)
                choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    DataHandler.ListFurniture();
                    break;
                case 2:
                    //AddFurniture();
                    break;
                case 3:
                    //EditFurniture();
                    break;
                case 4:
                    //DeleteFurniture();
                    break;
                default:
                    MainMenu();
                    break;
            }
        }

        private void FurnitureTypesMenu()
        {
            Console.WriteLine("=================================");
            Console.WriteLine("1. List furniture types");
            Console.WriteLine("2. Add new furniture type");
            Console.WriteLine("3. Edit existing furniture type");
            Console.WriteLine("4. Delete existing furniture type");
            Console.WriteLine("0. Main menu");
            Console.WriteLine("=================================\n");

            int choice = int.Parse(Console.ReadLine());

            while (choice < 0 || choice > 4)
                choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    DataHandler.ListFurnitureTypes();
                    break;
                case 2:
                    //AddFurnitureType();
                    break;
                case 3:
                    //EditFurnitureType();
                    break;
                case 4:
                    //DeleteFurnitureType();
                    break;
                default:
                    MainMenu();
                    break;
            }

        }

        private void UsersMenu()
        {
            Console.WriteLine("=======================");
            Console.WriteLine("1. List users");
            Console.WriteLine("2. Add new user");
            Console.WriteLine("3. Edit existing user");
            Console.WriteLine("4. Delete existing user");
            Console.WriteLine("0. Main menu");
            Console.WriteLine("=======================\n");

            int choice = int.Parse(Console.ReadLine());

            while (choice < 0 || choice > 4)
                choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    DataHandler.ListUsers();
                    break;
                case 2:
                    //AddUser();
                    break;
                case 3:
                    //EditUser();
                    break;
                case 4:
                    //DeleteUser();
                    break;
                default:
                    MainMenu();
                    break;
            }
        }

        private void ActionSalesMenu()
        {
            Console.WriteLine("==============================");
            Console.WriteLine("1. List action sales");
            Console.WriteLine("2. Add new action sales");
            Console.WriteLine("3. Edit existing action sale");
            Console.WriteLine("4. Delete existing action sale");
            Console.WriteLine("0. Main menu");
            Console.WriteLine("==============================\n");

            int choice = int.Parse(Console.ReadLine());

            while (choice < 0 || choice > 4)
                choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    DataHandler.ListActionSales();
                    break;
                case 2:
                    //AddActionSale();
                    break;
                case 3:
                    //EditActionSale();
                    break;
                case 4:
                    //DeleteActionSale();
                    break;
                default:
                    MainMenu();
                    break;
            }
        }

        private void AdditionalServicesMenu()
        {
            Console.WriteLine("=====================================");
            Console.WriteLine("1. List additional services");
            Console.WriteLine("2. Add new addition service");
            Console.WriteLine("3. Edit existing additional service");
            Console.WriteLine("4. Delete existing additional service");
            Console.WriteLine("0. Main menu");
            Console.WriteLine("=====================================\n");

            int choice = int.Parse(Console.ReadLine());

            while (choice < 0 || choice > 4)
                choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    DataHandler.ListAdditionalServices();
                    break;
                case 2:
                    //AddAdditionalService();
                    break;
                case 3:
                    //EditAdditionalService();
                    break;
                case 4:
                    //DeleteAdditionalService();
                    break;
                default:
                    MainMenu();
                    break;
            }
        }
    }
}
