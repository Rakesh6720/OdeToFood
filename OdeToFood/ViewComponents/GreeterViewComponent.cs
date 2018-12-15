using Microsoft.AspNetCore.Mvc;
using OdeToFood.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.ViewComponents
{
    public class GreeterViewComponent : ViewComponent
    {
        private IGreeter _greeter;

        public GreeterViewComponent(IGreeter greeter)
        {
            _greeter = greeter;
        }
        // A ViewComponent returns a ViewComponentResult instead of a Controller's IActionResult
        public IViewComponentResult Invoke()
        {
            var model = _greeter.GetMessageOfTheDay();
            // When returning a model of 'string' to a View, specify Name of model as 1st parameter
            // Otherwise, View will look for a .cshtml View file with name of 'string' value
            // 'Default' is the default Name of a ViewComponent view result
            return View("Default", model);
        }
    }
}
