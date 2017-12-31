using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.Model
{
    class FurnitureSaleItem : INotifyPropertyChanged
    {
        private int furniture;

        public int Furniture
        {
            get { return furniture; }
            set
            {
                furniture = value;
                OnPropertyChanged("Furniture");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
