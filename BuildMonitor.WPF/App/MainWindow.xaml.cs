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
            this.DataGrid.Visibility = Visibility.Hidden;
            this.ReportGrid.Visibility = Visibility.Hidden;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            this.LoadButton.IsEnabled = false;

            try
            {
                var builds = await _buildService.GetAll();
                this.DataGrid.ItemsSource = builds;
                this.DataGrid.Visibility = Visibility.Visible;
                this.ReportGrid.Visibility = Visibility.Hidden;
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
                this.ReportGrid.ItemsSource = reports;
                this.DataGrid.Visibility = Visibility.Hidden;
                this.ReportGrid.Visibility = Visibility.Visible;
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
                this.ReportGrid.ItemsSource = reports;
                
                this.DataGrid.Visibility = Visibility.Hidden;
                this.ReportGrid.Visibility = Visibility.Visible;
            }
            finally
            {
                this.LoadButton.IsEnabled = true;
            }
        }
    }
}
