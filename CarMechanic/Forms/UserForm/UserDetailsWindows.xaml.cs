using System.Windows;
using CarMechanic.Models;

namespace CarMechanic.UserForm
{
    public partial class UserDetailsWindow : Window
    {
        public User User { get; }

        public UserDetailsWindow(User user)
        {
            InitializeComponent();
            User = user;
            DataContext = this;
        }
    }
}
