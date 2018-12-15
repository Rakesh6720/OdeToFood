using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Services;

namespace OdeToFood.Pages
{
    public class GreetingModel : PageModel
    {
        private IGreeter _greeter;

        public string currentGreeting { get; set; }

        public GreetingModel(IGreeter Greeter)
        {
            _greeter = Greeter;
        }
        public void OnGet()
        {
            // Here I can put together all the information I will need for the page to satisfy on request
            // This is similar to a Controller Action
            currentGreeting = _greeter.GetMessageOfTheDay();
        }
    }
}