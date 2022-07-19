using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace Ptest1.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration _configuration;
        public string Message { get; set; }

        public ListModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void OnGet()
        {
            // Message = "Hello World!";
            Message = _configuration["Message"];
        }
    }
}