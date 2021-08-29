using AutoCenterKorytoBusinessLogic.BindingModels;
using AutoCenterKorytoBusinessLogic.BusinessLogics;
using AutoCenterKorytoBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Unity;

namespace AutoCenterKorytoView
{

    public partial class WindowPurchase : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        private CarLogic _carLogic;
        private PrePurchaseWorkLogic _prePurchaseWorkLogic;
        private PurchaseLogic _purchaseLogic;

        private HashSet<CarViewModel> _selectedCars;
        private List<CarViewModel> _avalibleCars;

        private HashSet<PrePurchaseWorkViewModel> _selectedWorks;
        private List<PrePurchaseWorkViewModel> _avalibleWorks;

        private double _carsPrice = 0;
        private double _preWorksPrice = 0;

        public PurchaseViewModel Purchase { get; set; }

        public WindowPurchase(CarLogic carLogic, PrePurchaseWorkLogic prePurchaseWorkLogic, PurchaseLogic purchaseLogic)
        {
            InitializeComponent();

            _prePurchaseWorkLogic = prePurchaseWorkLogic;
            _carLogic = carLogic;
            _purchaseLogic = purchaseLogic;

            _avalibleWorks = _prePurchaseWorkLogic.Read(null);
            _avalibleCars = _carLogic.Read(null);
        }
        
        private void ButtonAddPrePurchaseWorks_Click(object sender, RoutedEventArgs e)
        {
            WindowPrePurchaseWorkSelector window = Container.Resolve<WindowPrePurchaseWorkSelector>();
            window.SelectedWorks = _selectedWorks;
            window.AvalibleWorks = _avalibleWorks;
            if(window.ShowDialog() == true)
            {
                _selectedWorks = window.SelectedWorks;
                listBoxWorks.Items.Refresh();
                _preWorksPrice = _selectedWorks.Sum(c => c.Price);
                textBoxPrice.Text = (_preWorksPrice + _carsPrice).ToString();
            }
        }

        private void ButtonAddCars_Click(object sender, RoutedEventArgs e)
        {
            WindowCarSelector window = Container.Resolve<WindowCarSelector>();
            window.SelectedCars = _selectedCars;
            window.AvalibleCars = _avalibleCars;
            if (window.ShowDialog() == true)
            {
                _selectedCars = window.SelectedCars;
                listBoxCars.Items.Refresh();
                _carsPrice = _selectedCars.Sum(c => c.Price);
                textBoxPrice.Text = (_preWorksPrice + _carsPrice).ToString();
            }
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _purchaseLogic.CreateOrUpdate(new PurchaseBindingModel 
                {
                    Price = _carsPrice + _preWorksPrice,
                    Id = Purchase?.Id,
                    ClientId = App.Client.Id,
                    DateCreate = DateTime.Now,
                    PrePurchaseWorks = _selectedWorks.ToDictionary(sw => sw.Id, sw => sw.Name),
                    Cars = _selectedCars.ToDictionary(sc => sc.Id, sc => sc.Model),
                    
                });
                MessageBox.Show("Успех");
                Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (Purchase != null)
            {
                _selectedWorks = _avalibleWorks.Where(aw => Purchase.PrePurchaseWorks.ContainsKey(aw.Id)).ToHashSet();
                _selectedCars = _avalibleCars.Where(aw => Purchase.Cars.ContainsKey(aw.Id)).ToHashSet();
                _carsPrice = _selectedCars.Sum(sc => sc.Price);
                _preWorksPrice = _selectedWorks.Sum(sw => sw.Price);
                textBoxPrice.Text = (_carsPrice + _preWorksPrice).ToString();
            }
            else
            {
                _selectedWorks = new HashSet<PrePurchaseWorkViewModel>();
                _selectedCars = new HashSet<CarViewModel>();
                textBoxPrice.Text = "0";
            }
            listBoxCars.ItemsSource = _selectedCars;
            listBoxWorks.ItemsSource = _selectedWorks;
           
        }
    }
}
