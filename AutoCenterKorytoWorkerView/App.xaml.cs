using AutoCenterKorytoBusinessLogic.Interfaces;
using AutoCenterKorytoBusinessLogic.ViewModels;
using AutoCenterKorytoDatabaseImplement.Implements;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Unity;
using Unity.Lifetime;

namespace AutoCenterKorytoWorkerView
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static WorkerViewModel Client { get; set; }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var container = BuildUnityContainer();
            var authWindow = container.Resolve<WindowLogin>();
            authWindow.ShowDialog();
        }
        private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<IWorkerStorage, WorkerStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<WorkerStorage>(new HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}
