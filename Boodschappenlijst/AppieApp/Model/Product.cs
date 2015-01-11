using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AppieApp.Model {

    public class Product {
        
        // Constructor
        public Product() {
            Merken      = new List<Merk>();
            Kortingen   = new List<Korting>();
        }

        // Primary
        [Key]
        public          int                     ProductId   { get; set; }
        public          string                  Naam        { get; set; }
        public          decimal                 Prijs       { get; set; }

        // Foreign
        public virtual  Afdeling                Afdeling    { get; set; }
        public virtual  ICollection<Merk>       Merken      { get; set; }
        public virtual  ICollection<Korting>    Kortingen   { get; set; }

    }

}
