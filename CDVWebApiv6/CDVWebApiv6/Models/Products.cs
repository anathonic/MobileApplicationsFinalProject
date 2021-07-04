using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CDVWebApiv6.Models
{
    public class Products
    {
        public int id { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
    }
}