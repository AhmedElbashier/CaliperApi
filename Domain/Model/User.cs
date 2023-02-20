using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CaliperApi.Domain.Models
{
public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public int role { get; set; }
        

    }
}