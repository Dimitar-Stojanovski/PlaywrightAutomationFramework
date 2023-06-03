using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EaApplicationTest.Models
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name  { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public ProductType productType { get; set; }

    }

    public enum ProductType
    {
        CPU,
        MONITOR,
        PERIPHERALS,
        EXTERNAL
    }
}
