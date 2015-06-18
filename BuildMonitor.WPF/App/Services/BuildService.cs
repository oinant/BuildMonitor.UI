using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuildMonitor.WPF.Models;

namespace BuildMonitor.WPF.Services
{
    public class BuildService : IBuildService
    {
        private readonly IBuildRepository _buildRepository;

        public BuildService(IBuildRepository buildRepository)
        {
            _buildRepository = buildRepository;
        }

        public async Task<IEnumerable<Build>> GetAll()
        {
            return await _buildRepository.GetAll();
        }

        public async Task<IEnumerable<DailyReport>> GetDailyReports()
        {
            var builds = await GetAll();

            var report = builds
                            .Select(b => new {day = b.GetDate(), build = b})
                            .GroupBy(b => b.day,
                                    b => b.build,
                                    (key, g) => new DailyReport() {Date = key,Builds = g});

            return report;

        }

        public async Task<IEnumerable<SolutionReport>> GetSolutionReports()
        {
            var builds = await GetAll();

            var report = builds
                            .Select(b => new { name = b.Solution.Name, build = b })
                            .GroupBy(b => b.name,
                                    b => b.build,
                                    (key, g) => new SolutionReport() { SolutionName = key, Builds = g });
            return report;

        }
    }
}