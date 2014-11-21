using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer
{
    public class Bug
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string description { get; set; }

        [Required]
        public DateTime deadLine { get; set; }

        public int statusId { get; set; }
        public int userId { get; set; }
        public int projectId { get; set; }
        public int priorityId { get; set; }

        [ForeignKey("userId")]
        public virtual User users { get; set; }
        [ForeignKey("priorityId")]
        public virtual Priority prioritis { get; set; }
        public virtual ICollection<Message> messages { get; set; }
        [ForeignKey("statusId")]
        public virtual Status status { get; set; }
        [ForeignKey("projectId")]
        public virtual Project project { get; set; }
    }
}
