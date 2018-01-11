using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.Model
{
    public class Sale : INotifyPropertyChanged
    {

        public const decimal Tax = 0.02M;

        private ObservableCollection<SaleItem<Furniture>> furnitureForSale = new ObservableCollection<SaleItem<Furniture>>();

        public ObservableCollection<SaleItem<Furniture>> FurnitureForSale
        {
            get { return furnitureForSale; }
            set { furnitureForSale = value; }
        }

        private ObservableCollection<SaleItem<AdditionalService>> servicesForSale = new ObservableCollection<SaleItem<AdditionalService>>();

        public ObservableCollection<SaleItem<AdditionalService>> ServicesForSale
        {
            get { return servicesForSale; }
            set { servicesForSale = value; }
        }

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }


        private DateTime dateOfSale;

        public DateTime DateOfSale
        {
            get { return dateOfSale; }
            set
            {
                dateOfSale = value;
                OnPropertyChanged("DateOfSale");
            }
        }


        private decimal fullPrice;

        public event PropertyChangedEventHandler PropertyChanged;

        public decimal FullPrice
        {
            get
            {
                decimal x = 0;
                foreach (SaleItem<Furniture> item in furnitureForSale)
                {
                    x += item.ProductForSale.Price;
                }
                foreach (SaleItem<AdditionalService> item in servicesForSale)
                {
                    x += item.ProductForSale.Price;
                }
                return x + (x * Tax);
            }
            set
            {
                fullPrice = value;
                OnPropertyChanged("FullPrice");
            }
        }

        private string buyer;

        public string Buyer
        {
            get { return buyer; }
            set
            {
                buyer = value;
                OnPropertyChanged("Buyer");
            }
        }


        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
