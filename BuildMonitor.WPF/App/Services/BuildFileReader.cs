using System;
using System.IO;
using System.Threading.Tasks;

namespace BuildMonitor.WPF.Services
{
    public class BuildFileReader : IBuildFileReader
    {
        public async Task<string> Read()
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