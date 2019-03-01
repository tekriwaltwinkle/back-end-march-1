using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace quiz_pro.Models
{
    public class admin
    {
        [Key]
        public int aID { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}
