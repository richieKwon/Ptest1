using System.Collections.Generic;
using System.Linq;
using Food.Core;

namespace Food.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        private List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant{Id = 1, Name = "YeraBBQ", Location = "CoventGarden", Cuisine = CuisineType.Mexican},
                new Restaurant{Id = 2, Name = "JensKitchen", Location = "Wimbledon", Cuisine = CuisineType.Italian},
                new Restaurant{Id = 3, Name = "ZeroDog", Location = "Soho", Cuisine = CuisineType.Mexican}
            };
        }
        public IEnumerable<Restaurant> GetAll()
        {
            return from item in restaurants
                orderby item.Name  
                select item;
        }
    }


}