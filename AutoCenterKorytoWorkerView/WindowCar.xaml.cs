using AutoCenterKorytoBusinessLogic.BindingModels;
using AutoCenterKorytoBusinessLogic.BusinessLogics;
using AutoCenterKorytoBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;


namespace AutoCenterKorytoWorkerView
{
    public partial class WindowCar : Window
    {
        private CarLogic _carLogic;
        private ComplectationLogic _complectationLogic;
        private HashSet<ComplectationViewModel> _selectedComplectations;
        private List<ComplectationViewModel> _avalibleComplectations;

        public CarViewModel Car { get; set; }

        public WindowCar(CarLogic carLogic, ComplectationLogic complectationLogic)
        {
            InitializeComponent();

            _carLogic = carLogic;
            _complectationLogic = complectationLogic;
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowCarComplectation windowCarComplectation = new WindowCarComplectation();
            windowCarComplectation.AvalibleComplectations = _avalibleComplectations;
            if(windowCarComplectation.ShowDialog() == true)
            {
                _selectedComplectations.Add(windowCarComplectation.SelectedComplectation);
                dataGridComplectations.Items.Refresh();
            }
        }


        private void ButtonUpd_Click(object sender, RoutedEventArgs e)
        {
            if(dataGridComplectations.SelectedItems.Count == 1)
            {
                WindowCarComplectation windowCarComplectation = new WindowCarComplectation();
                windowCarComplectation.AvalibleComplectations = _avalibleComplectations;

                var selected = _selectedComplectations.FirstOrDefault(ac => ac.Id == ((ComplectationViewModel)dataGridComplectations.SelectedItem).Id);
                windowCarComplectation.SelectedComplectation = selected;
                if (windowCarComplectation.ShowDialog() == true)
                {
                    _selectedComplectations.Remove(selected);
                    _selectedComplectations.Add(windowCarComplectation.SelectedComplectation);
                    dataGridComplectations.Items.Refresh();
                }
            }
        }

        private void ButtonDel_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridComplectations.SelectedItems.Count == 1)
            {
                _selectedComplectations.Remove((ComplectationViewModel)dataGridComplectations.SelectedItem);
                dataGridComplectations.Items.Refresh();
            }
        }

        private void ButtonRef_Click(object sender, RoutedEventArgs e)
        {
            dataGridComplectations.Items.Refresh();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _carLogic.CreateOrUpdate(new CarBindingModel
                {
                    ColorName = textBoxColorName.Text,
                    YearCreation = Convert.ToInt32(textBoxYearCreate.Text),
                    Price = Convert.ToDouble(textBoxPrice.Text),
                    Model = textBoxName.Text,
                    Id = Car?.Id,
                    WorkerId = App.Worker.Id,
                    ComplectationsIds = _selectedComplectations.Select(sc => sc.Id).ToList()
                });
                MessageBox.Show("Успех");
                Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                _avalibleComplectations = _complectationLogic.Read(null);
                if (Car == null)
                {
                    _selectedComplectations = new HashSet<ComplectationViewModel>();
                }
                else
                {
                    Car = _carLogic.Read(new CarBindingModel { Id = Car.Id })[0];
                    _selectedComplectations = _avalibleComplectations.Where(ac => Car.Complectations.ContainsKey(ac.Id)).ToHashSet();
                    textBoxName.Text = Car.Model;
                    textBoxPrice.Text = Car.Price.ToString();
                    textBoxYearCreate.Text = Car.YearCreation.ToString();
                    textBoxColorName.Text = Car.ColorName;
                }
                dataGridComplectations.ItemsSource = _selectedComplectations;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
