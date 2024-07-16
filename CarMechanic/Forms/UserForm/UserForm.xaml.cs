using System.Windows;
using CarMechanic.Models;

namespace CarMechanic.UserForm
{
    /// <summary>
    /// Interaction logic for UserForm.xaml.
    /// </summary>
    public partial class UserForm : Window
    {
        /// <summary>
        /// Gets or sets the user being edited or created.
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserForm"/> class.
        /// </summary>
        /// <param name="user">The user to be edited or created.</param>
        public UserForm(User user)
        {
            InitializeComponent();
            User = user;
            DataContext = User;
        }

        /// <summary>
        /// Handles the click event of the save button.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            User.Name = NameTextBox.Text;
            User.Email = EmailTextBox.Text;
            DialogResult = true;
        }
    }
}
