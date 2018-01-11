using MyApplication.DAO;
using MyApplication.Model;
using MyApplication.Util;
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
            AdditionalServiceDAO additionalServiceDAO = new AdditionalServiceDAO();

            if (mode == Mode.ADD)
            {
                AdditionalService additionalService = new AdditionalService()
                {
                    Name = tbName.Text.Trim(),
                    Price = decimal.Parse(tbPrice.Text.Trim())
                };

                MainWindow.additionalServicesList.Add(additionalService);
            }
            else
            {
                additionalService.Name = tbName.Text.Trim();
                additionalService.Price = decimal.Parse(tbPrice.Text.Trim());

                additionalServiceDAO.Update(additionalService);
            }

            Close();
        }

        private void tbPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (InputValidator.ValidateInteger(tbPrice.Text.Trim()) == false)
            {
                tbPrice.BorderBrush = new SolidColorBrush(Colors.Red);
                tbPrice.BorderThickness = new Thickness(2);
            }
            else
            {
                tbPrice.BorderBrush = new SolidColorBrush(Colors.Blue);
                tbPrice.BorderThickness = new Thickness(1);
            }
        }

        private void tbName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (InputValidator.ValidateString(tbName.Text.Trim()) == false)
            {
                tbName.BorderBrush = new SolidColorBrush(Colors.Red);
                tbName.BorderThickness = new Thickness(2);
            }
            else
            {
                tbName.BorderBrush = new SolidColorBrush(Colors.Blue);
                tbName.BorderThickness = new Thickness(1);
            }
        }
    }
}