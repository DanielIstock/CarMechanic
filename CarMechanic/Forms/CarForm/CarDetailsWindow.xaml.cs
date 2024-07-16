using CarMechanic.Models;
using System.Windows;

namespace CarMechanic.CarForm
{
    /// <summary>
    /// Interaction logic for CarDetailsWindow.xaml.
    /// </summary>
    public partial class CarDetailsWindow : Window
    {
        /// <summary>
        /// Gets the car being displayed.
        /// </summary>
        public Car Car { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CarDetailsWindow"/> class.
        /// </summary>
        /// <param name="car">The car to be displayed.</param>
        public CarDetailsWindow(Car car)
        {
            InitializeComponent();
            Car = car;
            DataContext = this;
        }
    }
}
