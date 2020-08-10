using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace TODOListAP03.ViewModels
{
    public class TodosDetailsViewModel
    {
        [DisplayName("Todos ID")]
        public int Id { get; set; }

        public int Nummer { get; set; }

        public string Kurzbeschreibung { get; set; }

        [DisplayName("Details ID")]
        public int DetailsId { get; set; }

        public string Beschreibung { get; set; }

        public bool Done { get; set; }

    }
}