﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TODOListAP03.Models
{
    public class Authorization
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [DataType(DataType.Password)]
        [StringLength(30, ErrorMessage = "Only 30 character are allowed")]
        [Required]
        public string Password { get; set; }
        
        public roleType Role { get; set; }

        [Required]
        public string SessionId { get; set; }

    }

    public enum roleType
    {
        admin = 1,
        user = 2
    }
}