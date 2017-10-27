using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.UI
{
    //Prodavac rukuje prodajama namjestaja
    class SalesmanWindow
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
                Console.WriteLine("1. List sales");
                Console.WriteLine("2. Add new sale");
                Console.WriteLine("3. Edit existing sale");
                Console.WriteLine("4. Delete existing sale");
                Console.WriteLine("0. Exit");
            }
            while (true);
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