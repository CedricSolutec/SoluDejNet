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

    public partial class EntrepriseMetadata
    {
        [StringLength(50)]
        [Display(Name = "Nom de l'entreprise")]
        [Required]
        public string nom { get; set; }

        [Display(Name = "Arrondissement")]
        [Required]
        public int arrondissement { get; set; }

        [Display(Name = "Ville")]
        [Required]
        public int ville { get; set; }

    }

    public partial class UtilisateurMetadata
    {
        [Required]
        [Display(Name = "Nom")]
        public string nom { get; set; }

        [Required]
        [Display(Name = "Prénom")]
        public string prenom { get; set; }

        [Required]
        [Display(Name = "Mail principal")]
        public string mailSolutec { get; set; }

        [Display(Name = "Mail de notification")]
        public string mailNotification { get; set; }

        [Display(Name = "Mot de passe")]
        public string motDePasse { get; set; }

        [Display(Name = "Date de naissance")]
        public System.DateTime dateDeNaissance { get; set; }

        [Display(Name = "Entreprise")]
        public int idEntreprise { get; set; }
    }
}