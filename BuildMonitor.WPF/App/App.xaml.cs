using System.Windows;
using StructureMap;

namespace BuildMonitor.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var container = Bootstrapper.Init();

            var window = container.GetInstance<MainWindow>();
            window.Show();
        }
    }
}
