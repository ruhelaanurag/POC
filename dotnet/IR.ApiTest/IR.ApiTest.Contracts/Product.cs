using System.ComponentModel.DataAnnotations;

namespace IR.ApiTest.Contracts
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Category{ get; set; }
        public DateTime LastUpdated { get; set; }
        public DateTime Created { get; set; }

    }
}
