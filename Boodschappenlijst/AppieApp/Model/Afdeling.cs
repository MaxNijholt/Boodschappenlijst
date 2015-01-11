using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AppieApp.Model {

    public class Afdeling {

        // Constructor
        public Afdeling() {
            Producten = new List<Product>();
        }

        // Primary
        [Key]
        public          int                     AfdelingId  { get; set; }
        [Required]
        public          string                  Naam        { get; set; }

        // Foreign
        public virtual  ICollection<Product>    Producten   { get; set; }

    }

}
