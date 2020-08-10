using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TODOListAP03.Models
{
    public class Todos
    {
        public int Id { get; set; }

        [Range(1, 10000)]
        public int Nummer { get; set; }

        [Required]
        public string Kurzbeschreibung { get; set; }

        
        public int DetailsId { get; set; }

        public bool Done { get; set; }

        public bool Active { get; set; }

    }
}