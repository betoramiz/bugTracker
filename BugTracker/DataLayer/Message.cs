using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataLayer
{
    public class Message
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string messageText { get; set; }
        
        [Required]
        public DateTime commentedDate { get; set; }

        public virtual User user { get; set; }
        public virtual Bug bug  { get; set; }
    }
}
