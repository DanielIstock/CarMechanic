using System.Linq;
using System.Windows;
using CarMechanic.Data;
using CarMechanic.Models;

namespace CarMechanic.CarForm
{
    public partial class CarForm : Window
    {
        private readonly AppDbContext _context;
        public Models.Car Car { get; private set; }

        public CarForm(Models.Car car)
        {
            InitializeComponent();
            _context = new AppDbContext();
            Car = car;
            ModelTextBox.Text = car.Model;
            LicensePlateTextBox.Text = car.LicensePlate;
            UserComboBox.ItemsSource = _context.Users.ToList();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ModelTextBox.Text) || string.IsNullOrWhiteSpace(LicensePlateTextBox.Text) || UserComboBox.SelectedItem == null)
            {
                MessageBox.Show("Model, License Plate and User cannot be empty", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Car.Model = ModelTextBox.Text;
            Car.LicensePlate = LicensePlateTextBox.Text;
            Car.User = UserComboBox.SelectedItem as User;
            DialogResult = true;
        }
    }
}
