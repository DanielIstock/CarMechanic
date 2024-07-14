using CarMechanic.Models;
using System.Windows;

namespace CarMechanic.PartForm
{
    public partial class PartDetailsWindow : Window
    {
        public Part Part { get; }

        public PartDetailsWindow(Part part)
        {
            InitializeComponent();
            Part = part;
            DataContext = this;
        }
    }
}
