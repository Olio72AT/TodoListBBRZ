using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TODOListAP03.ViewModels
{
    public class ResourcenTodosDetailsViewModel
    {
        [DisplayName("RESId")]

        public int Id { get; set; }

        [DisplayName("RES Nachname")]
        public string Name { get; set; }


        // Introducing 1:n .... create a LIST of existing Todos (Id's)
        // Remember, when we delete the todos, we do not really delete them (ACTIVE flag) 
        public TodosDetailsViewModel TodosVM { get; set; }

        public bool Active { get; set; }

    }
}