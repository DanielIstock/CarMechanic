using System.Windows;
using CarMechanic.Models;

namespace CarMechanic.PartForm
{
    public partial class PartForm : Window
    {
        public Part Part { get; private set; }

        public PartForm(Part part)
        {
            InitializeComponent();
            Part = part;
            DataContext = Part;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Part.Name = NameTextBox.Text;
            Part.Price = decimal.Parse(PriceTextBox.Text);
            DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
