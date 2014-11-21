﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataLayer
{
    public class Status
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }

        public string description { get; set; }
    }
}
