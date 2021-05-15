using AutoCenterKorytoBusinessLogic.BindingModels;
using AutoCenterKorytoBusinessLogic.BusinessLogics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Unity;

namespace AutoCenterKorytoWorkerView
{
    /// <summary>
    /// Логика взаимодействия для WindowRegistation.xaml
    /// </summary>
    public partial class WindowRegistration : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }
        private readonly WorkerLogic logic;
        //private readonly Logger logger;
        public WindowRegistration(WorkerLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
            //  logger = LogManager.GetCurrentClassLogger();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните \"Имя\"", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxLogin.Text))
            {
                MessageBox.Show("Заполните поле \"логин\"", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!Regex.IsMatch(textBoxLogin.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
            {
                MessageBox.Show("Почта введена некорректно", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPassword.Text))
            {
                MessageBox.Show("Заполните поле \"пароль\"", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxCompany.Text))
            {
                MessageBox.Show("Заполните поле \"компания\"", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                logic.CreateOrUpdate(new WorkerBindingModel
                {
                    FIO = textBoxName.Text,
                    Login = textBoxLogin.Text,
                    Password = textBoxPassword.Text,
                    Company = textBoxCompany.Text
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                this.DialogResult = true;
                Close();
            }
            catch (Exception ex)
            {
                //logger.Error("Ошибка сохранения данных : " + ex.Message);
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
