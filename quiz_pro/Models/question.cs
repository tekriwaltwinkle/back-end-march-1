using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace quiz_pro.Models
{
    public class question
    {
        [Key]
        public int quID { get; set; }
        public string Text { get; set; }
        public string CorrectAnswer { get; set; }
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        public string Answer4 { get; set; }

        [ForeignKey("quiz")]
        public int qID { get; set; }
        public quiz quiz { get; set; }
    }
}
