using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.UI
{
    //Admin rukuje korisnicima, namjestajem i podacima o akcijskim prodajama.
    class AdminWindow
    {

        public void StartInteraction()
        {
            MainMenu();
        }

        private void MainMenu()
        {
            int choice = int.Parse(Console.ReadLine());
            do
            {
                Console.WriteLine("1. Furniture");
                Console.WriteLine("2. Furniture types");
                Console.WriteLine("3. Users");
                Console.WriteLine("4. Action sales");
                Console.WriteLine("5. Additional services");
                Console.WriteLine("0. Exit");
                Console.WriteLine();
            }
            while (choice < 0 || choice > 5);
            switch (choice)
            {
                case 1:
                    //FurnitureMenu();
                    break;
                case 2:
                    //FurnitureTypesMenu();
                    break;
                case 3:
                    //UsersMenu();
                    break;
                case 4:
                    //ActionSalesMenu();
                    break;
                case 5:
                    //AdditionalServicesMenu();
                    break;
                default:
                    Environment.Exit(0);
                    break;
            }
        }

        private void FurnitureMenu()
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
            switch (choice)
            {
                case 1:
                    //ListFurniture();
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
            int choice = int.Parse(Console.ReadLine());
            do
            {
                Console.WriteLine("1. List furniture types");
                Console.WriteLine("2. Add new furniture type");
                Console.WriteLine("3. Edit existing furniture type");
                Console.WriteLine("4. Delete existing furniture type");
                Console.WriteLine("0. Main menu");
                Console.WriteLine();
            }
            while (choice < 0 || choice > 4);
            switch (choice)
            {
                case 1:
                    //ListFurinitureTypes();
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
            int choice = int.Parse(Console.ReadLine());
            do
            {
                Console.WriteLine("1. List users");
                Console.WriteLine("2. Add new user");
                Console.WriteLine("3. Edit existing user");
                Console.WriteLine("4. Delete existing user");
                Console.WriteLine("0. Main menu");
                Console.WriteLine();
            }
            while (choice < 0 || choice > 4);
            switch (choice)
            {
                case 1:
                    //ListUsers();
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
            int choice = int.Parse(Console.ReadLine());
            do
            {
                Console.WriteLine("1. List action sales");
                Console.WriteLine("2. Add new action sales");
                Console.WriteLine("3. Edit existing action sale");
                Console.WriteLine("4. Delete existing action sale");
                Console.WriteLine("0. Main menu");
                Console.WriteLine();
            }
            while (true);
            switch (choice)
            {
                case 1:
                    //ListActionSales();
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
            int choice = int.Parse(Console.ReadLine());
            do
            {
                Console.WriteLine("1. List additional services");
                Console.WriteLine("2. Add new addition service");
                Console.WriteLine("3. Edit existing additional service");
                Console.WriteLine("4. Delete existing additional service");
                Console.WriteLine("0. Main menu");
                Console.WriteLine();
            }
            while (true);
            switch (choice)
            {
                case 1:
                    //ListAdditionalServices();
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
