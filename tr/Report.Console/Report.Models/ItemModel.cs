using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Models
{
    public class ItemModel
    {
        public ItemContent[] content { get; set; }
    }
        public class ItemContent
    {
        public int id { get; set; }
        public string uuid { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public object[] parameters { get; set; }
        public object[] attributes { get; set; }
        public string type { get; set; }
        public long startTime { get; set; }
        public long endTime { get; set; }
        public string status { get; set; }
        public Statistics statistics { get; set; }
        public Pathnames pathNames { get; set; }
        public bool hasChildren { get; set; }
        public bool hasStats { get; set; }
        public int launchId { get; set; }
        public string uniqueId { get; set; }
        public int testCaseHash { get; set; }
        public object[] patternTemplates { get; set; }
        public string path { get; set; }
    }

    //public class Statistics
    //{
    //    public Executions executions { get; set; }
    //    public Defects defects { get; set; }
    //}

    //public class Executions
    //{
    //    public int total { get; set; }
    //    public int passed { get; set; }
    //    public int skipped { get; set; }
    //}

    //public class Defects
    //{
    //    public No_Defect no_defect { get; set; }
    //}

    public class No_Defect
    {
        public int total { get; set; }
        public int nd001 { get; set; }
    }

    public class Pathnames
    {
        public Launchpathname launchPathName { get; set; }
    }

    public class Launchpathname
    {
        public string name { get; set; }
        public int number { get; set; }
    }

}
