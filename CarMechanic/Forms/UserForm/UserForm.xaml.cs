using System.Windows;
using CarMechanic.Data;
using CarMechanic.Models;

namespace CarMechanic.UserForm
{
    public partial class UserForm : Window
    {
        private readonly AppDbContext _context;
        public Models.User User { get; private set; }

        public UserForm(Models.User user)
        {
            InitializeComponent();
            _context = new AppDbContext();
            User = user;
            NameTextBox.Text = user.Name;
            EmailTextBox.Text = user.Email;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameTextBox.Text) || string.IsNullOrWhiteSpace(EmailTextBox.Text))
            {
                MessageBox.Show("Name and Email cannot be empty", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            User.Name = NameTextBox.Text;
            User.Email = EmailTextBox.Text;
            DialogResult = true;
        }
    }
}
