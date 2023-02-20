using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CaliperApi.Domain.Models;

namespace CaliperApi.Domain.Helpers
{
    public class InvoiceDto
    {
        public int id { get; set; }
        public string invoiceId { get; set; }
        public string cusname { get; set; }
        public List<InvoiceProducts> products { get; set; }
        public int discount { get; set; }
        public int comission { get; set; }
        public int total { get; set; }
    }

    public class ProductDto
    {
        public int id { get; set; }
        public string productname { get; set; }
        public string description { get; set; }
        public string type { get; set; }
        public int price { get; set; }
        public int quantity { get; set; }
        

    }
    public class UserDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public int role { get; set; }
    }

    public class InvoiceProductsDto
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