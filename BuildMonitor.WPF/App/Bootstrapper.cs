using BuildMonitor.WPF.Services;
using StructureMap;

namespace BuildMonitor.WPF
{
    public  class Bootstrapper
    {
        public static Container Init()
        {
            return new Container(_ =>
            {
                _.For<IBuildFileReader>().Use<BuildFileReader>();
                _.For<IBuildRepository>().Use<BuildRepository>();
                _.For<IBuildService>().Use<BuildService>();
                _.For<MainWindow>().Use<MainWindow>();
            }); 
            
        }
    }
}
