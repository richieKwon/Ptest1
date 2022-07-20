using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food.Core;
using Food.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace Ptest1.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration _configuration;
        private readonly IRestaurantData _restaurantData;
        public string Message { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public ListModel(IConfiguration configuration, IRestaurantData restaurantData)
        {
            _configuration = configuration;
            _restaurantData = restaurantData;
        }
        public void OnGet()   
        {  
            // Message = "Hello World!";
            Message = _configuration["Message"];
            Restaurants = _restaurantData.GetRestaurantByName(SearchTerm);
        }
    } 
}