using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using App.Models;
using Newtonsoft.Json;

namespace App.Services
{
    public class BuildRepository
    {
        public async Task<IEnumerable<Build>> GetAll()
        {
            var bulk = await new BuildFileReader().Read();

            var builds = JsonConvert.DeserializeObject<IEnumerable<Build>>(bulk);
            return builds;
        }
    }

    public class BuildFileReader
    {
        public async Task<String> Read()
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) +
                       "/AppData/Roaming/Build Monitor/buildtimes.json";

            using (var reader = File.OpenText(path))
            {
                return reader.ReadToEnd();
            }
        }
    }
}