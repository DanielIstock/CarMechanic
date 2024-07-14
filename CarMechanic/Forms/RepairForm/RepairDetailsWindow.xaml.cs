using CarMechanic.Models;
using System.Windows;

namespace CarMechanic.RepairForm
{
    public partial class RepairDetailsWindow : Window
    {
        public Repair Repair { get; }

        public RepairDetailsWindow(Repair repair)
        {
            InitializeComponent();
            Repair = repair;
            DataContext = this;
        }
    }
}
