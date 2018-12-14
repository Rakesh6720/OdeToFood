using OdeToFood.Models;

namespace OdeToFood.ViewModels
{
    public class RestaurantEditModel
    {
        // All I need on this ViewModel are properties that match the fields on my form
        public string Name { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}
