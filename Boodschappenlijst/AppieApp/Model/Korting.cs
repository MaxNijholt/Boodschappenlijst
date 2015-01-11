using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AppieApp.Model {

    public class Korting {

        // Constructor
        public Korting() {
            Producten = new List<Product>();
        }

        // Primary
        [Key]
        public          int                     KortingId   { get; set; }
        [Required]
        public          string                  Naam        { get; set; }
        [Required]
        public          decimal                 Percentage  { get; set; }
        [Required]
        public          DateTime                BeginDatum  { get; set; }
        [Required]
        public          DateTime                EindDatum   { get; set; }

        // Foreign
        public virtual  ICollection<Product>    Producten   { get; set; }

    }

}
