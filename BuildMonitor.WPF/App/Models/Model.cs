using System;
using System.Collections.Generic;
using System.Linq;

namespace BuildMonitor.WPF.Models
{
    public class ProjectBuild
    {
        public Project Project { get; set; }
        public DateTime Start { get; set; }
        public Int64 Time { get; set; }
    }

    public class Solution
    {
        public String Name { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }

    public class Build
    {
        public DateTime Start { get; set; }
        public Int64 Time { get; set; }
        public Solution Solution { get; set; }
        public IEnumerable<Project> Projects { get; set; }

        public DateTime GetDate()
        {
            return new DateTime(Start.Year, Start.Month, Start.Day);
        }
    }

    public abstract class OneDimensionReport
    {
        public IEnumerable<Build> Builds { get; set; }

        public TimeSpan BuildTime { get { return TimeSpan.FromMilliseconds(TotalTime); } }
        public int BuildCount { get { return Builds.Count(); } }

        public TimeSpan AverageTimePerBuild
        {
            get
            {
                long average = TotalTime / BuildCount;
                return TimeSpan.FromMilliseconds(average);
            }
        }

        private Int64 _totalTime;
        private Int64 TotalTime
        {
            get
            {
                if (_totalTime == default(Int64))
                    _totalTime = Builds.Sum(b => b.Time);
                return _totalTime;
            }
        }
    }

    public class DailyReport : OneDimensionReport
    {
        public DateTime Date { get; set; }
    }

    public class SolutionReport : OneDimensionReport
    {
        public string SolutionName { get; set; }
    }
}
