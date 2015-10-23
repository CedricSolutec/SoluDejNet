using System.ComponentModel.DataAnnotations;

namespace SoluDej.Models
{
    [MetadataType(typeof(EvenementMetadata))]
    public partial class Evenements
    {
    }

    [MetadataType(typeof(RestaurantMetadata))]
    public partial class Restaurants
    {
    }

    [MetadataType(typeof(UtilisateurMetadata))]
    public partial class Utilisateurs
    {
    }
}