using System.Collections.ObjectModel;
using System.Windows;
using CarMechanic.Models;

namespace CarMechanic.CarForm
{
    public partial class CarForm : Window
    {
        public Car Car { get; set; }
        public ObservableCollection<User> Users { get; set; }

        public CarForm(Car car, ObservableCollection<User> users)
        {
            InitializeComponent();
            Car = car;
            Users = users;
            DataContext = this;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Car.Model = ModelTextBox.Text;
            Car.LicensePlate = LicensePlateTextBox.Text;
            Car.User = (User)UserComboBox.SelectedItem;
            DialogResult = true;
        }
    }
}
