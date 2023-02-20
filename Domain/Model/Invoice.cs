using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CaliperApi.Domain.Models
{
public class Invoice
    {
        public int id { get; set; }
        public string invoiceId { get; set; }
        public string cusname { get; set; }
        public List<InvoiceProducts> products { get; set; }
        public int discount { get; set; }
        public int comission { get; set; }
        public int total { get; set; }
    }

    public class InvoiceProducts
    {
        public int id { get; set; }
        public int invoiceId { get; set; }
        public string productname { get; set; }
        public string description { get; set; }
        public string type { get; set; }
        public int price { get; set; }
        public int quantity { get; set; }
        
    }
}
