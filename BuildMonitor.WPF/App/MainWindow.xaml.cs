using System.Windows;
using BuildMonitor.WPF.Services;

namespace BuildMonitor.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IBuildService _buildService;
        public MainWindow(IBuildService buildService)
        {
            _buildService = buildService;
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            this.LoadButton.IsEnabled = false;

            try
            {
                var builds = await _buildService.GetAll();

                this.DataGrid.ItemsSource = builds;
            }
            finally
            {
                this.LoadButton.IsEnabled = true;
            }
        }

        private async void ReportByDay_Click(object sender, RoutedEventArgs e)
        {
            this.LoadButton.IsEnabled = false;

            try
            {
                var reports = await _buildService.GetDailyReports();

                this.DataGrid.ItemsSource = reports;
            }
            finally
            {
                this.LoadButton.IsEnabled = true;
            }
        }

        private async void ReportBySolution_Click(object sender, RoutedEventArgs e)
        {
            this.LoadButton.IsEnabled = false;

            try
            {
                var reports = await _buildService.GetSolutionReports();

                this.DataGrid.ItemsSource = reports;
            }
            finally
            {
                this.LoadButton.IsEnabled = true;
            }
        }
    }
}
