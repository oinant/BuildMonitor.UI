using BuildMonitor.WPF.Services;
using StructureMap;

namespace BuildMonitor.WPF
{
    public  class Bootstrapper
    {
        public static void Init()
        {
            var container = new Container(_ =>
            {
                _.For<IBuildFileReader>().Use<BuildFileReader>();
                _.For<IBuildRepository>().Use<BuildRepository>();

                _.For<IBuildService>().Use<BuildService>();
            }); 
            
        }
    }
}
