using System.ComponentModel.DataAnnotations;

namespace SoluDej.Models
{
    public class EvenementMetadata
    {
        [Required]
        public int Restaurant { get; set; }
        [Required]
        public System.DateTime Date { get; set; }
    }

    public class RestaurantMetadata
    {
        [StringLength(50)]
        [Display(Name = "Nom du restaurant")]
        [Required]
        public string Nom { get; set; }
        [Required]
        [StringLength(50)]
        public string Adresse { get; set; }
        public string SiteWeb { get; set; }
    }
}