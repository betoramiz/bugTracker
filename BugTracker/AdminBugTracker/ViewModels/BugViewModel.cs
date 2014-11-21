using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataLayer;
using System.ComponentModel.DataAnnotations;

namespace AdminBugTracker.ViewModels
{
    public class BugViewModel
    {
        public int idBug { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string description { get; set; }
        [Required]
        public int useId { get; set; }
        [Required]
        public int projectId { get; set; }
        [Required]
        public int statusId { get; set; }
        [Required]
        public int priorityId { get; set; }
        [Required]
        public DateTime deadLine { get; set; }

        public List<User> userList { get; set; }
        public List<Project> projectList { get; set; }
        public List<Status> statusList { get; set; }
        public List<Priority> priorityList { get; set; }
    }
}