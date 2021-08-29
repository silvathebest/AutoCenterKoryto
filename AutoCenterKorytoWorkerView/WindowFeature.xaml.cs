using AutoCenterKorytoBusinessLogic.BindingModels;
using AutoCenterKorytoBusinessLogic.BusinessLogics;
using AutoCenterKorytoBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace AutoCenterKorytoWorkerView
{
    public partial class WindowFeature : Window
    {
        public FeaturesViewModel Feature { get; set; }
        private CarLogic _carLogic;
        private FeaturesLogic _featuresLogic;
        private List<CarViewModel> _avalibleCars;

        public WindowFeature(CarLogic carLogic, FeaturesLogic featuresLogic)
        {
            InitializeComponent();
            _carLogic = carLogic;
            _featuresLogic = featuresLogic;
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _featuresLogic.CreateOrUpdate(new FeaturesBindingModel
                {
                    CarId = ((CarViewModel)comboBoxCars.SelectedItem).Id,
                    Description = textBoxName.Text,
                    Type = Convert.ToInt32(textBoxType.Text),
                    WorkerId = App.Worker.Id,
                    Id = Feature?.Id
                });
                MessageBox.Show("Успех");
                Close();
            }
            catch (Exception ex)
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
            try
            {
                _avalibleCars = _carLogic.Read(null);             
                comboBoxCars.ItemsSource = _avalibleCars;

                if (Feature != null)
                {
                    textBoxName.Text = Feature.Description;
                    textBoxType.Text = Feature.Type.ToString();
                    comboBoxCars.SelectedItem = _avalibleCars?.FirstOrDefault(ac => ac.Id == Feature.CarId);
                }
                else
                {
                    comboBoxCars.SelectedItem = _avalibleCars?[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }       
    }
}
