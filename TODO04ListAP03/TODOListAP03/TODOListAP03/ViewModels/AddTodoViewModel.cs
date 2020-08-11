using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TODOListAP03.Models;

namespace TODOListAP03.ViewModels
{
    public class AddTodoViewModel
    {
        public int ResourceId { get; set; }
        public string  ResourceName { get; set; }


        [Required]
        public IEnumerable <Todos> TodoItem { get; set; }
    }
}