using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Models
{
    public class LogModel
    {
        public LogObject[] content { get; set; }
    }

    public class LogObject
    {
        public int id { get; set; }
        public long time { get; set; }
        public string message { get; set; }
        public string level { get; set; }
        public int itemId { get; set; }
    }

}
