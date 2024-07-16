using System.Windows;
using CarMechanic.Models;

namespace CarMechanic.UserForm
{
    /// <summary>
    /// Interaction logic for UserDetailsWindow.xaml.
    /// </summary>
    public partial class UserDetailsWindow : Window
    {
        /// <summary>
        /// Gets the user whose details are being displayed.
        /// </summary>
        public User User { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserDetailsWindow"/> class.
        /// </summary>
        /// <param name="user">The user whose details are to be displayed.</param>
        public UserDetailsWindow(User user)
        {
            InitializeComponent();
            User = user;
            DataContext = this;
        }
    }
}
