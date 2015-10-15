using System.ComponentModel.DataAnnotations;

namespace SoluDej.Models
{
    public class PartialClasses
    {
        [MetadataType(typeof(RestaurantMetadata))]
        public partial class Restaurants
        {
        }

        [MetadataType(typeof(EvenementMetadata))]
        public partial class Evenements
        {
        }
    }
}