using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using CarMechanic.Models;

namespace CarMechanic.RepairForm
{
    /// <summary>
    /// Interaction logic for RepairForm.xaml.
    /// </summary>
    public partial class RepairForm : Window
    {
        /// <summary>
        /// Gets or sets the repair being created or edited.
        /// </summary>
        public Repair Repair { get; set; }

        /// <summary>
        /// Gets or sets the collection of available cars.
        /// </summary>
        public ObservableCollection<Car> Cars { get; set; }

        /// <summary>
        /// Gets or sets the collection of available parts.
        /// </summary>
        public ObservableCollection<Part> Parts { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RepairForm"/> class.
        /// </summary>
        /// <param name="repair">The repair being created or edited.</param>
        /// <param name="cars">The collection of available cars.</param>
        /// <param name="parts">The collection of available parts.</param>
        public RepairForm(Repair repair, ObservableCollection<Car> cars, ObservableCollection<Part> parts)
        {
            InitializeComponent();
            Repair = repair;
            Cars = cars;
            Parts = parts;
            DataContext = this;
        }

        /// <summary>
        /// Handles the Click event of the SaveButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
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
