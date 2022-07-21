using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ptest1.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantData _restaurantData;

        public EditModel(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }
        
        public void OnGet()
        {

        }
    }
}