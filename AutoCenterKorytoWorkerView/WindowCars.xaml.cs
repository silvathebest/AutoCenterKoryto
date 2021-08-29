using AutoCenterKorytoBusinessLogic.BindingModels;
using AutoCenterKorytoBusinessLogic.BusinessLogics;
using AutoCenterKorytoBusinessLogic.ViewModels;
using System;
using System.Windows;
using Unity;

namespace AutoCenterKorytoWorkerView
{
    public partial class WindowCars : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }
        private CarLogic _carLogic;

        public WindowCars(CarLogic carLogic)
        {
            _carLogic = carLogic;
            InitializeComponent();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowCar windowCar = Container.Resolve<WindowCar>();
            windowCar.ShowDialog();
            LoadData();
        }

        private void ButtonUpd_Click(object sender, RoutedEventArgs e)
        {
            if(dataGridCars.SelectedItems.Count == 1)
            {
                WindowCar windowCar = Container.Resolve<WindowCar>();
                windowCar.Car = (CarViewModel)dataGridCars.SelectedItem;
                windowCar.ShowDialog();
                LoadData();
            }
        }

        private void ButtonDel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dataGridCars.SelectedItems.Count == 1)
                {
                    _carLogic.Delete(new CarBindingModel { Id = ((CarViewModel)dataGridCars.SelectedItem).Id, WorkerId = App.Worker.Id });
                    LoadData();
                }
                MessageBox.Show("Успешно удалено", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ButtonRef_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var list = _carLogic.Read(new CarBindingModel { WorkerId = App.Worker.Id });
                if (list != null)
                {
                    dataGridCars.ItemsSource = list;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK,
                MessageBoxImage.Error);
            }
        }
    }
}
