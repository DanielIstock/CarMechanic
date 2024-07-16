using CarMechanic.Models;
using System.Windows;

namespace CarMechanic.PartForm
{
    /// <summary>
    /// Interaction logic for PartDetailsWindow.xaml.
    /// </summary>
    public partial class PartDetailsWindow : Window
    {
        /// <summary>
        /// Gets the part being displayed.
        /// </summary>
        public Part Part { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PartDetailsWindow"/> class.
        /// </summary>
        /// <param name="part">The part to be displayed.</param>
        public PartDetailsWindow(Part part)
        {
            InitializeComponent();
            Part = part;
            DataContext = this;
        }
    }
}
