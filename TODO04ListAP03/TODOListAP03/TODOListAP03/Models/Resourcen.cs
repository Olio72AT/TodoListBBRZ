using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TODOListAP03.Models
{
    public class Resourcen
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        [DisplayName("Nachname")]
        public string Name { get; set; }


        // Introducing 1:n .... create a LIST of existing Todos (Id's)
        // Remember, when we delete the todos, we do not really delete them (ACTIVE flag) 
        public List<int> TodosId { get; set; }

        public bool Active { get; set; }

    }
}