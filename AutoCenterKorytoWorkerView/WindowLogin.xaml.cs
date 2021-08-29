using AutoCenterKorytoBusinessLogic.BindingModels;
using AutoCenterKorytoBusinessLogic.BusinessLogics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Логика взаимодействия для WindowLogin.xaml
    /// </summary>
    public partial class WindowLogin : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }
        private readonly WorkerLogic logic;
        //private readonly Logger logger;
        public WindowLogin(WorkerLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
            // logger = LogManager.GetCurrentClassLogger();
        }

        private void buttonRegistration_Click(object sender, RoutedEventArgs e)
        {
            var form = Container.Resolve<WindowRegistration>();
            form.ShowDialog();
            //WindowRegistration WRegistration = new WindowRegistration (logic) { Owner = this };
            //WRegistration.ShowDialog();
        }

        private void buttonLogin_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxLogin.Text))
            {
                MessageBox.Show("Введите почту", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(passwordBox.Password))
            {
                MessageBox.Show("Введите пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                var users = logic.Read(new WorkerBindingModel
                {
                    Login = textBoxLogin.Text,
                    Password = passwordBox.Password
                });
                if (users != null && users.Count > 0)
                {
                    var MainWindow = Container.Resolve<MainWindow>();
                    MainWindow.Show();
                    App.Worker = users[0];
                    Close();
                }
                else
                {
                    MessageBox.Show("Неверно введен пароль или логин", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                //logger.Error("Ошибка загрузки данных : " + ex.Message);
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
