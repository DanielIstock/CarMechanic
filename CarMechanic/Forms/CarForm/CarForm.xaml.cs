using System.Collections.ObjectModel;
using System.Windows;
using CarMechanic.Models;

namespace CarMechanic.CarForm
{
    /// <summary>
    /// Interaction logic for CarForm.xaml.
    /// </summary>
    public partial class CarForm : Window
    {
        /// <summary>
        /// Gets or sets the car being edited.
        /// </summary>
        public Car Car { get; set; }

        /// <summary>
        /// Gets or sets the collection of users for selection.
        /// </summary>
        public ObservableCollection<User> Users { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CarForm"/> class.
        /// </summary>
        /// <param name="car">The car to be edited.</param>
        /// <param name="users">The collection of users for selection.</param>
        public CarForm(Car car, ObservableCollection<User> users)
        {
            InitializeComponent();
            Car = car;
            Users = users;
            DataContext = this;
        }

        /// <summary>
        /// Handles the Save button click event.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Car.Model = ModelTextBox.Text;
            Car.LicensePlate = LicensePlateTextBox.Text;
            Car.User = (User)UserComboBox.SelectedItem;
            DialogResult = true;
        }
    }
}
