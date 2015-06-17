using System.Collections.Generic;
using System.Threading.Tasks;
using BuildMonitor.WPF.Models;

namespace BuildMonitor.WPF.Services
{
    public interface IBuildRepository
    {
        Task<IEnumerable<Build>> GetAll();
    }
}