using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        public InMemoryRestaurantData()
        {
            // instantiate the private restaurant list in the consructor
            _restaurants = new List<Restaurant>
            {
                new Restaurant {Id = 1, Name = "Scott's Pizza Place"},
                new Restaurant {Id = 2, Name = "Tersiguels"},
                new Restaurant {Id = 3, Name = "King's Contrivance"}
            };
        }

        // class that implements IRestaurantData interface must implement GetAll() as part of its contract
        public IEnumerable<Restaurant> GetAll()
        {
            // can return a List with LINQ functions attached
            return _restaurants.OrderBy(r => r.Name);
        }

        // Scott's convention is to see private fields declared at the bottom of the class definition
        List<Restaurant> _restaurants;
    }
}
