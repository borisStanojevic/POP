using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.Model
{
    [Serializable]
    public class Sale : INotifyPropertyChanged
    {

        public const double Tax = 0.02;

        private ObservableCollection<Furniture> furnitureForSale = new ObservableCollection<Furniture>();

        public ObservableCollection<Furniture> FurnitureForSale
        {
            get { return furnitureForSale; }
            set { furnitureForSale = value; }
        }

        private ObservableCollection<AdditionalService> servicesForSale = new ObservableCollection<AdditionalService>();

        public ObservableCollection<AdditionalService> ServicesForSale
        {
            get { return servicesForSale = new ObservableCollection<AdditionalService>(); }
            set { servicesForSale = value; }
        }

        private int billId;

        public int BillId
        {
            get { return billId; }
            set
            {
                billId = value;
                OnPropertyChanged("Id");
            }
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


        private double fullPrice;

        public event PropertyChangedEventHandler PropertyChanged;

        public double FullPrice
        {
            get
            {
                double x = 0;
                foreach (Furniture item in furnitureForSale)
                {
                    x += item.Price;
                }
                foreach (AdditionalService item in servicesForSale)
                {
                    x += item.Price;
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
