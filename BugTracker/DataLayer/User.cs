using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer
{
    public class User
    {
        [Key]
        public int id { get; set; }
        
        [Required]
        public string fullName { get; set; }

        [Required]
        [EmailAddress]
        public string email { get; set; }

        [Required]
        [MinLength(6)]
        public string password { get; set; }

        public int roleId { get; set; }

        public virtual ICollection<Bug> bugs { get; set; }
        [ForeignKey("roleId")]
        public virtual Role role { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
