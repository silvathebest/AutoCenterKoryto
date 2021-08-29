using AutoCenterKorytoBusinessLogic.BindingModels;
using AutoCenterKorytoBusinessLogic.BusinessLogics;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using Unity;

namespace AutoCenterKorytoView
{
    /// <summary>
    /// Логика взаимодействия для WindowRegistration.xaml
    /// </summary>
    public partial class WindowRegistration : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }
        private readonly ClientLogic logic;
        //private readonly Logger logger;
        public WindowRegistration(ClientLogic logic)
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
            try
            {
                logic.CreateOrUpdate(new ClientBindingModel
                {
                    FIO = textBoxName.Text,
                    Login = textBoxLogin.Text,
                    PhoneNumber = textBoxPhoneNumber.Text,
                    Password = textBoxPassword.Text
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
