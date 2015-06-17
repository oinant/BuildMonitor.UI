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
            var builds = await GetDailyReports();

            //var report = builds.Select(b => new {day = new DateTime(b.Date.Year, b.Date.Month, b.Date.Day), build = b})
            //    .GroupBy(b => b.day,
            //        b => b,
            //        (key, g) => new DailyReport() {Date = key,Builds = new Build{ Solution = g.}});

            throw  new NotImplementedException();

        }
    }
}