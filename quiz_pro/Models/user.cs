using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace quiz_pro.Models
{
    public class user
    { 
        [Key]
        public int uID { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string phonenumber { get; set; }
    }
}
