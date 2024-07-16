using CarMechanic.Models;
using System.Windows;

namespace CarMechanic.RepairForm
{
    /// <summary>
    /// Interaction logic for RepairDetailsWindow.xaml.
    /// </summary>
    public partial class RepairDetailsWindow : Window
    {
        /// <summary>
        /// Gets the repair whose details are being displayed.
        /// </summary>
        public Repair Repair { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RepairDetailsWindow"/> class.
        /// </summary>
        /// <param name="repair">The repair whose details are being displayed.</param>
        public RepairDetailsWindow(Repair repair)
        {
            InitializeComponent();
            Repair = repair;
            DataContext = this;
        }
    }
}
