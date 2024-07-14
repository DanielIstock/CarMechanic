using CarMechanic.Models;
using System.Windows;

namespace CarMechanic.CarForm
{
    public partial class CarDetailsWindow : Window
    {
        public Car Car { get; }

        public CarDetailsWindow(Car car)
        {
            InitializeComponent();
            Car = car;
            DataContext = this;
        }
    }
}
