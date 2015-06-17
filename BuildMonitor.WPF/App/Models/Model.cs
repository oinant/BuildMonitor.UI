using System;
using System.Collections.Generic;

namespace App.Models
{
    public class Project
    {
        public string Name { get; set; }
        public Guid Id { get; set; }
    }

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
}

/*
[{
  "Start": "2015-06-17T10:53:32.6920896+02:00",
  "Time": 84765,
  "Solution": {
    "Name": "Xamarin.Sport"
  },
  "Projects": [
    {
      "Start": "2015-06-17T10:53:33.3676877+02:00",
      "Time": 16,
      "Project": {
        "Name": "Sport.Core.Enumerations.Portable",
        "Id": "23ca8915-038a-4470-ae18-bc7ded7549e3"
      }
    },
 
*/