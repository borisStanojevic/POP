using MyApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MyApplication.UI
{
    /// <summary>
    /// Interaction logic for AdditionalServiceWindow.xaml
    /// </summary>
    public partial class AdditionalServiceWindow : Window
    {
        private AdditionalService additionalService;
        public enum Mode
        {
            ADD,
            EDIT
        }
        private Mode mode;

        public AdditionalServiceWindow(AdditionalService additionalService, Mode mode = Mode.ADD)
        {
            InitializeComponent();
            this.additionalService = additionalService;
            this.mode = mode;

            if (mode == Mode.EDIT)
            {
                tbName.DataContext = additionalService;
                tbPrice.DataContext = additionalService;
                btnAddEditAdditionalService.Content = "Edit";
            }
        }

        private void btnAddEditAdditionalService_Click(object sender, RoutedEventArgs e)
        {
            if (this.mode == Mode.ADD)
            {
                int lastElementIndex = MainWindow.additionalServicesList.Count - 1;
                int lastElementId = MainWindow.additionalServicesList.ElementAt(lastElementIndex).Id;

                MainWindow.additionalServicesList.Add(new AdditionalService
                {
                    Id = lastElementId + 1,
                    Name = tbName.Text.Trim(),
                    Price = double.Parse(tbPrice.Text.Trim()),
                    Deleted = false
                });
            }
            this.Close();
        }
    }
}