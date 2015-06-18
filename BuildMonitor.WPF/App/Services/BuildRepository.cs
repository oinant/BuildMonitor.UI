using System.Collections.Generic;
using System.Threading.Tasks;
using BuildMonitor.WPF.Models;
using Newtonsoft.Json;

namespace BuildMonitor.WPF.Services
{
    public class BuildRepository : IBuildRepository
    {
        private readonly IBuildFileReader _buildFileReader;

        public BuildRepository(IBuildFileReader buildFileReader)
        {
            _buildFileReader = buildFileReader;
        }

        public async Task<IEnumerable<Build>> GetAll()
        {
            var bulk = await _buildFileReader.Read();

            var builds = JsonConvert.DeserializeObject<IEnumerable<Build>>(bulk);
            return builds;
        }
    }
}