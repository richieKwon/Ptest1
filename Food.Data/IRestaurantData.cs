using System.Collections.Generic;
using System.Linq;
using Food.Core;

namespace Food.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantByName(string name);
        Restaurant GetById(int id);
        Restaurant Update(Restaurant updatedRestaurant);
        int Commit();

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
                new Restaurant { Id = 3, Name = "ZeroDog", Location = "Soho", Cuisine = CuisineType.Mexican }
            };
        }

        public IEnumerable<Restaurant> GetRestaurantByName(string name = null) 
        {
            return from item in restaurants
                where string.IsNullOrEmpty(name) || item.Name.StartsWith(name)
                orderby item.Name
                select item;
        }

        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);
            if (restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
            }
            return restaurant;
        }

        public int Commit()
        {
            return 0;
        }
    }


}