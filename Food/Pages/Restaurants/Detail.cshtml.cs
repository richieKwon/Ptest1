using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Food.Core;
using Food.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ptest1.Pages.Restaurants
{
    public class DetailModel : PageModel
    {
        private readonly IRestaurantData _restaurantData;

        [TempData]
        public string Message { get; set; }
        public Restaurant Restaurant { get; set; }

        public DetailModel(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }
        public IActionResult OnGet(int restaurantId)
        {
            // Restaurant = new Restaurant();
            // Restaurant.Id = restaurantId;
            Restaurant = _restaurantData.GetById(restaurantId);
            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }
    }
}