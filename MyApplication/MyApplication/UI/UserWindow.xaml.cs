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
    /// Interaction logic for UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        private User user;
        public enum Mode
        {
            ADD,
            EDIT
        }
        private Mode mode;

        public UserWindow(User user, Mode mode = Mode.ADD)
        {
            InitializeComponent();
            this.user = user;
            this.mode = mode;
            cbUserType.ItemsSource = (TypeOfUser[])Enum.GetValues(typeof(TypeOfUser));

            if (mode == Mode.EDIT)
            {
                tbName.DataContext = user;
                tbSurname.DataContext = user;
                tbUsername.DataContext = user;
                tbPassword.DataContext = user;
                cbUserType.DataContext = user;
                btnAddEditUser.Content = "Edit";

                tbUsername.IsReadOnly = true;
            }
        }

        private void btnAddEditUser_Click(object sender, RoutedEventArgs e)
        {
            UserDAO userDAO = new UserDAO();

            if (mode == Mode.ADD)
            {
                User user = new User()
                {
                    Name = tbName.Text.Trim(),
                    Surname = tbSurname.Text.Trim(),
                    Username = tbUsername.Text.Trim(),
                    Password = tbPassword.Text.Trim(),
                    UserType = (TypeOfUser)cbUserType.SelectedItem
                };
                MainWindow.usersList.Add(user);
                userDAO.Add(user);
            }
            else
            {
                user.Name = tbName.Text.Trim();
                user.Surname = tbSurname.Text.Trim();
                user.Password = tbPassword.Text.Trim();
                user.UserType = (TypeOfUser)cbUserType.SelectedItem;

                userDAO.Update(user);
            }

            Close();
        }

        private void tbName_TextChanged(object sender, RoutedEventArgs e)
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

        private void tbSurname_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (InputValidator.ValidateString(tbSurname.Text.Trim()) == false)
            {
                tbSurname.BorderBrush = new SolidColorBrush(Colors.Red);
                tbSurname.BorderThickness = new Thickness(2);
            }
            else
            {
                tbSurname.BorderBrush = new SolidColorBrush(Colors.Blue);
                tbSurname.BorderThickness = new Thickness(1);
            }
        }

        private void tbUsername_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (InputValidator.ValidateUsername(tbUsername.Text.Trim()) == false)
            {
                tbUsername.BorderBrush = new SolidColorBrush(Colors.Red);
                tbUsername.BorderThickness = new Thickness(2);
            }
            else
            {
                tbUsername.BorderBrush = new SolidColorBrush(Colors.Blue);
                tbUsername.BorderThickness = new Thickness(1);
            }
        }

        private void tbPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (InputValidator.ValidatePassword(tbPassword.Text.Trim()) == false)
            {
                tbPassword.BorderBrush = new SolidColorBrush(Colors.Red);
                tbPassword.BorderThickness = new Thickness(2);
            }
            else
            {
                tbPassword.BorderBrush = new SolidColorBrush(Colors.Blue);
                tbPassword.BorderThickness = new Thickness(1);
            }
        }
    }
}