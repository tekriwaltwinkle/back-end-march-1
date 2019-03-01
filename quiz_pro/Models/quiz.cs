using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace quiz_pro.Models
{
    public class quiz
    {
        [Key]
        public int qID { get; set; }
        public string Title { get; set; }
        [ForeignKey("admin")]
        public int aID { get; set; }
    }
}
