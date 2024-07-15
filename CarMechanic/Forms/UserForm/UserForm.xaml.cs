using System.Windows;
using CarMechanic.Models;

namespace CarMechanic.UserForm
{
    public partial class UserForm : Window
    {
        public User User { get; set; }

        public UserForm(User user)
        {
            InitializeComponent();
            User = user;
            DataContext = User;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            User.Name = NameTextBox.Text;
            User.Email = EmailTextBox.Text;
            DialogResult = true;
        }
    }
}
