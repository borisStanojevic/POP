using MyApplication.DAO;
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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Login(object sender, RoutedEventArgs e)
        {
            string username = tbUsername.Text.Trim();
            string password = pbPassword.Password.ToString().Trim();
            bool isFound = false;

            User user = User.GetByUsername(username);
            if (user != null)
            {
                if (user.Password == password)
                    isFound = true;
            }

            if (!isFound)
            {
                tbMessage.Visibility = Visibility.Visible;
                tbMessage.Text = "User not found";
                tbMessage.FontWeight = FontWeights.Bold;
                tbMessage.Foreground = new SolidColorBrush(Colors.Red);
            }
            else
            {
                tbMessage.Visibility = Visibility.Hidden;
                switch (user.UserType)
                {
                    case TypeOfUser.Admin:
                        new MainWindow().Show();
                        this.Close();
                        break;
                    case TypeOfUser.Salesman:
                        new SalesmanWindow().Show();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
