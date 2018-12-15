using OdeToFood.Models;
using System.ComponentModel.DataAnnotations;

namespace OdeToFood.ViewModels
{
    // The reason I create this EditModel is so that I can control the INPUT I expect from a user when they submit a form to CREATE a restaurant
    public class RestaurantEditModel
    {
        // All I need on this ViewModel are properties that match the fields on my form
        [Required, MaxLength(80)]
        public string Name { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}
