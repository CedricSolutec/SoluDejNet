using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SoluDej.Models
{
    public partial class EvenementMetadata
    {
        [StringLength(50)]
        [Display(Name = "")]
        public string Nom { get; set; }
        public string Adresse { get; set; }
        public string SiteWeb { get; set; }
        public string Telephone { get; set; }
        public string Commentaire { get; set; }

        public virtual ICollection<Evenements> Evenements { get; set; }


    }

    public partial class RestaurantMetadata
    {
        [StringLength(50)]
        [Display(Name = "Nom du restaurant")]
        [Required]
        public string Nom { get; set; }

        [StringLength(50)]
        public string Adresse { get; set; }

        public virtual ICollection<Evenements> Evenements { get; set; }
    }
}