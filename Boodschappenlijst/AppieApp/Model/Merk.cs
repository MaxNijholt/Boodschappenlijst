using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AppieApp.Model {

    public class Merk {

        // Constructor
        public Merk() {
            Producten = new List<Product>();
        }

        // Primary
        [Key]
        public          int                     MerkId      { get; set; }
        [Required]
        public          string                  Naam        { get; set; }

        // Foreign
        public virtual  ICollection<Product>    Producten   { get; set; }

    }

}
