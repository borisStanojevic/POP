using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.UI
{
    //Prodavac rukuje prodajama namjestaja
    class SalesmanUI
    {
        public void Run()
        {
            MainMenu();
        }

        private void MainMenu()
        {
            Console.WriteLine("=======================");
            Console.WriteLine("1. List sales");
            Console.WriteLine("2. Add new sale");
            Console.WriteLine("3. Edit existing sale");
            Console.WriteLine("4. Delete existing sale");
            Console.WriteLine("0. Exit");
            Console.WriteLine("=======================\n");

            int choice = int.Parse(Console.ReadLine());

            while (choice < 0 || choice > 4)
                choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    //ListSales();
                    break;
                case 2:
                    //AddSale();
                    break;
                case 3:
                    //EditSale();
                    break;
                case 4:
                    //DeleteSale();
                    break;
                default:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}