using System;
using System.Linq;
using System.Windows;
using CarMechanic.Models;
using CarMechanic.Data;

namespace CarMechanic.RepairForm
{
    public partial class RepairForm : Window
    {
        public Repair Repair { get; private set; }

        private readonly AppDbContext _context;

        public RepairForm(Repair repair)
        {
            InitializeComponent();
            _context = new AppDbContext();
            Repair = repair;
            DataContext = Repair;

            CarComboBox.ItemsSource = _context.Cars.ToList();
            PartsListBox.ItemsSource = _context.Parts.ToList();

            CarComboBox.SelectedItem = Repair.Car;

            foreach (var part in Repair.Parts)
            {
                PartsListBox.SelectedItems.Add(part);
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (CarComboBox.SelectedItem is Car selectedCar)
            {
                Repair.Car = selectedCar;
            }

            Repair.Parts.Clear();
            foreach (var part in PartsListBox.SelectedItems)
            {
                Repair.Parts.Add((Part)part);
            }

            DialogResult = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
