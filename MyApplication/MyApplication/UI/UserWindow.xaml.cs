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
                cbUserType.SelectedItem = user.UserType;
                btnAddEditUser.Content = "Edit";
            }
        }

        private void btnAddEditUser_Click(object sender, RoutedEventArgs e)
        {
            if (this.mode == Mode.ADD)
            {
                int lastElementIndex = MainWindow.usersList.Count - 1;
                int lastElementId = MainWindow.usersList.ElementAt(lastElementIndex).Id;

                MainWindow.usersList.Add(new User()
                {
                    Id = lastElementId + 1,
                    Name = tbName.Text,
                    Surname = tbSurname.Text,
                    Username = tbUsername.Text,
                    Password = tbPassword.Text,
                    UserType = (TypeOfUser)cbUserType.SelectedItem,
                    Deleted = false
                });
                this.Close();
            }
        }
    }
}