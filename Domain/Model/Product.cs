using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CaliperApi.Domain.Models
{
public class Product
    {
        public int id { get; set; }
        public string productname { get; set; }
        public string description { get; set; }
        public string type { get; set; }
        public int price { get; set; }
        public int quantity { get; set; }
        

    }
}