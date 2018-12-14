using OdeToFood.Models;
using System.Collections.Generic;

namespace OdeToFood.ViewModels
{
    // This ViewModel will ENCAPSULATE everything the Home/Index View needs
    public class HomeIndexViewModel
    {
        public IEnumerable<Restaurant> Restaurants { get; set; }
        public string CurrentMessage { get; set; }
    }
}
