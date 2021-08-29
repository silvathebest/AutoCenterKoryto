using AutoCenterKorytoBusinessLogic.BusinessLogics;
using AutoCenterKorytoBusinessLogic.Interfaces;
using AutoCenterKorytoBusinessLogic.ViewModels;
using AutoCenterKorytoDatabaseImplement.Implements;
using System.Windows;
using Unity;
using Unity.Lifetime;

namespace AutoCenterKorytoView
{
    public partial class App : Application
    {
        public static ClientViewModel Client { get; set; }
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
            currentContainer.RegisterType<ICarStorage, CarStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IClientStorage, ClientStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IClientWisheStorage, ClientWishesStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IComplectationStorage, ComplectationStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IFeaturesStorage, FeatureStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IPrePurchaseWorkStorage, PrePurchaseWorkStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IPurchaseStorage, PurchaseStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IWorkerStorage, WorkerStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IReportDataProvider, ReportDataProvider>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<CarLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ClientLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ClientWisheLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ComplectationLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<FeaturesLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<PrePurchaseWorkLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<PurchaseLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<WorkerLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ReportLogic>(new HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}
