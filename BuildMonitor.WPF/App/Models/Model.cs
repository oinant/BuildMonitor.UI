using System;
using System.Collections.Generic;

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
    }

    public class DailyReport
    {
        public DateTime Date { get; set; }
        public IEnumerable<Build> Builds { get; set; } 
    }
}
