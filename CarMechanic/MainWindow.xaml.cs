using System.Linq;
using System.Windows;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;
using CarMechanic.Data;
using CarMechanic.Models;
using CarMechanic.UserForm;
using CarMechanic.CarForm;
using CarMechanic.RepairForm;
using CarMechanic.PartForm;

namespace CarMechanic
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly AppDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            _context = new AppDbContext();
            _context.Database.EnsureCreated();
            _context.Seed();
            LoadData();
        }

        /// <summary>
        /// Loads data from the database into the UI.
        /// </summary>
        private void LoadData()
        {
            UsersListBox.ItemsSource = new ObservableCollection<User>(_context.Users.Include(u => u.Cars).ToList());
            CarsListBox.ItemsSource = new ObservableCollection<Car>(_context.Cars.Include(c => c.User).ToList());
            RepairsListBox.ItemsSource = new ObservableCollection<Repair>(_context.Repairs.Include(r => r.Car).ToList());
            PartsListBox.ItemsSource = new ObservableCollection<Part>(_context.Parts.ToList());
        }

        /// <summary>
        /// Handles the Click event of the AddUser button, showing a form to add a new user.
        /// </summary>
        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            var userForm = new UserForm.UserForm(new User());
            if (userForm.ShowDialog() == true)
            {
                var user = userForm.User;
                _context.Entry(user).State = user.Id == 0 ? EntityState.Added : EntityState.Modified;
                _context.SaveChanges();
                LoadData();
            }
        }

        /// <summary>
        /// Handles the Click event of the EditUser button, showing a form to edit the selected user.
        /// </summary>
        private void EditUser_Click(object sender, RoutedEventArgs e)
        {
            if (UsersListBox.SelectedItem is User selectedUser)
            {
                var userForm = new UserForm.UserForm(selectedUser);
                if (userForm.ShowDialog() == true)
                {
                    var user = userForm.User;
                    _context.Entry(user).State = EntityState.Modified;
                    _context.SaveChanges();
                    LoadData();
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the DeleteUser button, deleting the selected user.
        /// </summary>
        private void DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            if (UsersListBox.SelectedItem is User selectedUser)
            {
                _context.Users.Remove(selectedUser);
                _context.SaveChanges();
                LoadData();
            }
        }

        /// <summary>
        /// Handles the Click event of the AddCar button, showing a form to add a new car.
        /// </summary>
        private void AddCar_Click(object sender, RoutedEventArgs e)
        {
            var carForm = new CarForm.CarForm(new Car(), new ObservableCollection<User>(_context.Users.ToList()));
            if (carForm.ShowDialog() == true)
            {
                var car = carForm.Car;
                if (car.User != null)
                {
                    var existingUser = _context.Users.Find(car.User.Id);
                    if (existingUser != null)
                    {
                        _context.Entry(existingUser).CurrentValues.SetValues(car.User);
                        car.User = existingUser;
                    }
                    else
                    {
                        _context.Users.Attach(car.User);
                    }
                }
                _context.Entry(car).State = car.Id == 0 ? EntityState.Added : EntityState.Modified;
                _context.SaveChanges();
                LoadData();
            }
        }

        /// <summary>
        /// Handles the Click event of the EditCar button, showing a form to edit the selected car.
        /// </summary>
        private void EditCar_Click(object sender, RoutedEventArgs e)
        {
            if (CarsListBox.SelectedItem is Car selectedCar)
            {
                var carForm = new CarForm.CarForm(selectedCar, new ObservableCollection<User>(_context.Users.ToList()));
                if (carForm.ShowDialog() == true)
                {
                    var car = carForm.Car;
                    if (car.User != null)
                    {
                        var existingUser = _context.Users.Find(car.User.Id);
                        if (existingUser != null)
                        {
                            _context.Entry(existingUser).CurrentValues.SetValues(car.User);
                            car.User = existingUser;
                        }
                        else
                        {
                            _context.Users.Attach(car.User);
                        }
                    }
                    _context.Entry(car).State = EntityState.Modified;
                    _context.SaveChanges();
                    LoadData();
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the DeleteCar button, deleting the selected car.
        /// </summary>
        private void DeleteCar_Click(object sender, RoutedEventArgs e)
        {
            if (CarsListBox.SelectedItem is Car selectedCar)
            {
                _context.Cars.Remove(selectedCar);
                _context.SaveChanges();
                LoadData();
            }
        }

        /// <summary>
        /// Handles the Click event of the AddRepair button, showing a form to add a new repair.
        /// </summary>
        private void AddRepair_Click(object sender, RoutedEventArgs e)
        {
            var repairForm = new RepairForm.RepairForm(new Repair(), new ObservableCollection<Car>(_context.Cars.ToList()), new ObservableCollection<Part>(_context.Parts.ToList()));
            if (repairForm.ShowDialog() == true)
            {
                var repair = repairForm.Repair;
                if (repair.Car != null)
                {
                    var existingCar = _context.Cars.Find(repair.Car.Id);
                    if (existingCar != null)
                    {
                        _context.Entry(existingCar).CurrentValues.SetValues(repair.Car);
                        repair.Car = existingCar;
                    }
                    else
                    {
                        _context.Cars.Attach(repair.Car);
                    }
                }
                _context.Entry(repair).State = repair.Id == 0 ? EntityState.Added : EntityState.Modified;
                _context.SaveChanges();
                LoadData();
            }
        }

        /// <summary>
        /// Handles the Click event of the EditRepair button, showing a form to edit the selected repair.
        /// </summary>
        private void EditRepair_Click(object sender, RoutedEventArgs e)
        {
            if (RepairsListBox.SelectedItem is Repair selectedRepair)
            {
                var repairForm = new RepairForm.RepairForm(selectedRepair, new ObservableCollection<Car>(_context.Cars.ToList()), new ObservableCollection<Part>(_context.Parts.ToList()));
                if (repairForm.ShowDialog() == true)
                {
                    var repair = repairForm.Repair;
                    if (repair.Car != null)
                    {
                        var existingCar = _context.Cars.Find(repair.Car.Id);
                        if (existingCar != null)
                        {
                            _context.Entry(existingCar).CurrentValues.SetValues(repair.Car);
                            repair.Car = existingCar;
                        }
                        else
                        {
                            _context.Cars.Attach(repair.Car);
                        }
                    }
                    _context.Entry(repair).State = EntityState.Modified;
                    _context.SaveChanges();
                    LoadData();
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the DeleteRepair button, deleting the selected repair.
        /// </summary>
        private void DeleteRepair_Click(object sender, RoutedEventArgs e)
        {
            if (RepairsListBox.SelectedItem is Repair selectedRepair)
            {
                _context.Repairs.Remove(selectedRepair);
                _context.SaveChanges();
                LoadData();
            }
        }

        /// <summary>
        /// Handles the Click event of the AddPart button, showing a form to add a new part.
        /// </summary>
        private void AddPart_Click(object sender, RoutedEventArgs e)
        {
            var partForm = new PartForm.PartForm(new Part());
            if (partForm.ShowDialog() == true)
            {
                var part = partForm.Part;
                _context.Entry(part).State = part.Id == 0 ? EntityState.Added : EntityState.Modified;
                _context.SaveChanges();
                LoadData();
            }
        }

        /// <summary>
        /// Handles the Click event of the EditPart button, showing a form to edit the selected part.
        /// </summary>
        private void EditPart_Click(object sender, RoutedEventArgs e)
        {
            if (PartsListBox.SelectedItem is Part selectedPart)
            {
                var partForm = new PartForm.PartForm(selectedPart);
                if (partForm.ShowDialog() == true)
                {
                    var part = partForm.Part;
                    _context.Entry(part).State = EntityState.Modified;
                    _context.SaveChanges();
                    LoadData();
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the DeletePart button, deleting the selected part.
        /// </summary>
        private void DeletePart_Click(object sender, RoutedEventArgs e)
        {
            if (PartsListBox.SelectedItem is Part selectedPart)
            {
                _context.Parts.Remove(selectedPart);
                _context.SaveChanges();
                LoadData();
            }
        }

        /// <summary>
        /// Handles the Click event of the UserDetails button, showing the details of the selected user.
        /// </summary>
        private void UserDetails_Click(object sender, RoutedEventArgs e)
        {
            if (UsersListBox.SelectedItem is User selectedUser)
            {
                var userDetails = new UserDetailsWindow(selectedUser);
                userDetails.ShowDialog();
            }
        }

        /// <summary>
        /// Handles the Click event of the CarDetails button, showing the details of the selected car.
        /// </summary>
        private void CarDetails_Click(object sender, RoutedEventArgs e)
        {
            if (CarsListBox.SelectedItem is Car selectedCar)
            {
                var carDetails = new CarDetailsWindow(selectedCar);
                carDetails.ShowDialog();
            }
        }

        /// <summary>
        /// Handles the Click event of the RepairDetails button, showing the details of the selected repair.
        /// </summary>
        private void RepairDetails_Click(object sender, RoutedEventArgs e)
        {
            if (RepairsListBox.SelectedItem is Repair selectedRepair)
            {
                var repairDetails = new RepairDetailsWindow(selectedRepair);
                repairDetails.ShowDialog();
            }
        }

        /// <summary>
        /// Handles the Click event of the PartDetails button, showing the details of the selected part.
        /// </summary>
        private void PartDetails_Click(object sender, RoutedEventArgs e)
        {
            if (PartsListBox.SelectedItem is Part selectedPart)
            {
                var partDetails = new PartDetailsWindow(selectedPart);
                partDetails.ShowDialog();
            }
        }
    }
}
