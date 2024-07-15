using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using CarMechanic.Models;

namespace CarMechanic.RepairForm
{
    public partial class RepairForm : Window
    {
        public Repair Repair { get; set; }
        public ObservableCollection<Car> Cars { get; set; }
        public ObservableCollection<Part> Parts { get; set; }

        public RepairForm(Repair repair, ObservableCollection<Car> cars, ObservableCollection<Part> parts)
        {
            InitializeComponent();
            Repair = repair;
            Cars = cars;
            Parts = parts;
            DataContext = this;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Repair.Date = DatePicker.SelectedDate ?? Repair.Date;
            Repair.Description = DescriptionTextBox.Text;
            Repair.Car = (Car)CarComboBox.SelectedItem;
            Repair.Parts = PartsListBox.SelectedItems.Cast<Part>().ToList();
            DialogResult = true;
        }
    }
}
