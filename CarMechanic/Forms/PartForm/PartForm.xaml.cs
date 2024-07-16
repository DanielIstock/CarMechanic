using System.Windows;
using CarMechanic.Models;

namespace CarMechanic.PartForm
{
    /// <summary>
    /// Interaction logic for PartForm.xaml.
    /// </summary>
    public partial class PartForm : Window
    {
        /// <summary>
        /// Gets or sets the part being edited or created.
        /// </summary>
        public Part Part { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PartForm"/> class.
        /// </summary>
        /// <param name="part">The part being edited or created.</param>
        public PartForm(Part part)
        {
            InitializeComponent();
            Part = part;
            DataContext = Part;
        }

        /// <summary>
        /// Handles the Click event of the SaveButton control.
        /// Saves the changes made to the part and closes the form.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Part.Name = NameTextBox.Text;
            Part.Price = decimal.Parse(PriceTextBox.Text);
            DialogResult = true;
        }
    }
}
