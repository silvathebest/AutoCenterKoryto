using AutoCenterKorytoBusinessLogic.BindingModels;
using AutoCenterKorytoBusinessLogic.BusinessLogics;
using AutoCenterKorytoBusinessLogic.ViewModels;
using System;
using System.Windows;
using Unity;

namespace AutoCenterKorytoWorkerView
{
    public partial class WindowFeatures : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        private FeaturesLogic _featuresLogic;

        public WindowFeatures(FeaturesLogic featuresLogic)
        {
            InitializeComponent();
            _featuresLogic = featuresLogic;
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowFeature windowFeature = Container.Resolve<WindowFeature>();
            windowFeature.ShowDialog();
            LoadData();
        }

        private void ButtonUpd_Click(object sender, RoutedEventArgs e)
        {
            if(dataGridFeatures.SelectedItems.Count == 1)
            {
                WindowFeature windowFeature = Container.Resolve<WindowFeature>();
                windowFeature.Feature = (FeaturesViewModel)dataGridFeatures.SelectedItem;
                windowFeature.ShowDialog();
                LoadData();
            }
        }

        private void ButtonDel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dataGridFeatures.SelectedItems.Count == 1)
                {
                    _featuresLogic.Delete(new FeaturesBindingModel { Id = ((FeaturesViewModel)dataGridFeatures.SelectedItem).Id, WorkerId = App.Worker.Id });
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
                var list = _featuresLogic.Read(new FeaturesBindingModel { WorkerId = App.Worker.Id });
                if (list != null)
                {
                    dataGridFeatures.ItemsSource = list;
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
