namespace Report.Models
{
    public class LaunchModel
    {
        public Content[] content { get; set; }
    }

    public class Content
    {
        public string owner { get; set; }
        public string description { get; set; }
        public int id { get; set; }
        public string uuid { get; set; }
        public string name { get; set; }
        public int number { get; set; }
        public long startTime { get; set; }
        public long endTime { get; set; }
        public long lastModified { get; set; }
        public string status { get; set; }
        public Statistics statistics { get; set; }
        public Attribute[] attributes { get; set; }
        public string mode { get; set; }
        public object[] analysing { get; set; }
        public float approximateDuration { get; set; }
        public bool hasRetries { get; set; }
        public bool rerun { get; set; }
    }

    public class Statistics
    {
        public Executions executions { get; set; }
        public Defects defects { get; set; }
    }

    public class Executions
    {
        public int total { get; set; }
        public int failed { get; set; }
        public int passed { get; set; }
    }

    public class Defects
    {
        public To_Investigate to_investigate { get; set; }
    }

    public class To_Investigate
    {
        public int total { get; set; }
        public int ti001 { get; set; }
    }

    public class Attribute
    {
        public string key { get; set; }
        public string value { get; set; }
    }

}
