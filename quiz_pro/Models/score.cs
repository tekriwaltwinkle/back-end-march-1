using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace quiz_pro.Models
{
    public class score
    {
        [Key]
        public int scoreId { get; set; }
        public string username { get; set; }
        public string title { get; set; }
        public int marks { get; set; }
        public DateTime date { get; set; }

        [ForeignKey("user")]
        public int uID { get; set; }
        public user user { get; set; }

        [ForeignKey("quiz")]
        public int qID { get; set; }
        public quiz quiz { get; set; }


    }
}
