using System.Windows;
using CarMechanic.Models;

namespace CarMechanic.RepairForm
{
    public partial class RepairForm : Window
    {
        public Repair Repair { get; private set; }

        public RepairForm(Repair repair)
        {
            InitializeComponent();
            Repair = repair;
            DataContext = Repair;
            PartsListBox.ItemsSource = Repair.Parts;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Repair.Description = DescriptionTextBox.Text;
            Repair.Date = RepairDatePicker.SelectedDate ?? DateTime.Now;
            DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
