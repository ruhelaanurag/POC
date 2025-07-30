using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IR.ApiTest.Entity.Models
{
    public class ProductEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }
        public DateTime LastUpdated { get; set; }
        public DateTime Created { get; set; }

    }
}
