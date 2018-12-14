using Microsoft.AspNetCore.Mvc;

namespace OdeToFood.Controllers
{
    [Route("[controller]/[action]")]
    public class AboutController
    {

        //[Route("")]
        public string Phone()
        {
            return "1+555+555+5555";
        }

        // the following Route Attribute indicates the method below REQUIRES the attribute string in the URL        
        public string Address()
        {
            return "USA";
        }

    }
}
