using System.Linq;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using CarMechanic.Data;
using CarMechanic.Models;
using CarMechanic.UserForm;
using CarMechanic.CarForm;
using CarMechanic.RepairForm;
using CarMechanic.PartForm;

namespace CarMechanic
{
    public partial class MainWindow : Window
    {
        private readonly AppDbContext _context;

        public MainWindow()
        {
            InitializeComponent();
            _context = new AppDbContext();
            _context.Database.EnsureCreated();
            _context.Seed();
            LoadData();
        }

        private void LoadData()
        {
            UsersListBox.ItemsSource = _context.Users.Include(u => u.Cars).ToList();
            CarsListBox.ItemsSource = _context.Cars.Include(c => c.User).ToList();
            RepairsListBox.ItemsSource = _context.Repairs.Include(r => r.Car).ThenInclude(c => c.User).Include(r => r.Parts).ToList();
            PartsListBox.ItemsSource = _context.Parts.ToList();
        }

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

        private void DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            if (UsersListBox.SelectedItem is User selectedUser)
            {
                _context.Users.Remove(selectedUser);
                _context.SaveChanges();
                LoadData();
            }
        }

        private void AddCar_Click(object sender, RoutedEventArgs e)
        {
            var carForm = new CarForm.CarForm(new Car());
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

        private void EditCar_Click(object sender, RoutedEventArgs e)
        {
            if (CarsListBox.SelectedItem is Car selectedCar)
            {
                var carForm = new CarForm.CarForm(selectedCar);
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

        private void DeleteCar_Click(object sender, RoutedEventArgs e)
        {
            if (CarsListBox.SelectedItem is Car selectedCar)
            {
                _context.Cars.Remove(selectedCar);
                _context.SaveChanges();
                LoadData();
            }
        }

        private void AddRepair_Click(object sender, RoutedEventArgs e)
        {
            var repairForm = new RepairForm.RepairForm(new Repair());
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

        private void EditRepair_Click(object sender, RoutedEventArgs e)
        {
            if (RepairsListBox.SelectedItem is Repair selectedRepair)
            {
                var repairForm = new RepairForm.RepairForm(selectedRepair);
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

        private void DeleteRepair_Click(object sender, RoutedEventArgs e)
        {
            if (RepairsListBox.SelectedItem is Repair selectedRepair)
            {
                _context.Repairs.Remove(selectedRepair);
                _context.SaveChanges();
                LoadData();
            }
        }

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

        private void DeletePart_Click(object sender, RoutedEventArgs e)
        {
            if (PartsListBox.SelectedItem is Part selectedPart)
            {
                _context.Parts.Remove(selectedPart);
                _context.SaveChanges();
                LoadData();
            }
        }

        private void UserDetails_Click(object sender, RoutedEventArgs e)
        {
            if (UsersListBox.SelectedItem is User selectedUser)
            {
                var userDetails = new UserDetailsWindow(selectedUser);
                userDetails.ShowDialog();
            }
        }

        private void CarDetails_Click(object sender, RoutedEventArgs e)
        {
            if (CarsListBox.SelectedItem is Car selectedCar)
            {
                var carDetails = new CarDetailsWindow(selectedCar);
                carDetails.ShowDialog();
            }
        }

        private void RepairDetails_Click(object sender, RoutedEventArgs e)
        {
            if (RepairsListBox.SelectedItem is Repair selectedRepair)
            {
                var repairDetails = new RepairDetailsWindow(selectedRepair);
                repairDetails.ShowDialog();
            }
        }

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
