using System.Collections.Generic;
using System.Threading.Tasks;
using BuildMonitor.WPF.Models;

namespace BuildMonitor.WPF.Services
{
    public interface IBuildService
    {
        Task<IEnumerable<Build>> GetAll();
        Task<IEnumerable<DailyReport>> GetDailyReports();
    }
}