using System.Threading.Tasks;

namespace BuildMonitor.WPF.Services
{
    public interface IBuildFileReader
    {
        Task<string> Read();
    }
}