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
        Restaurant Add(Restaurant newRestaurant);
        Restaurant Delete(int id);
        int GetCountOfRestaurants();
        
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

        public Restaurant Add(Restaurant newRestaurant)
        {
            restaurants.Add(newRestaurant);
            newRestaurant.Id = restaurants.Max(r => r.Id) + 1;
            return newRestaurant;
        }

        public Restaurant Delete(int id)
        {
            var restaurant = restaurants.FirstOrDefault(r => r.Id == id);
            if (restaurant != null)
            {
                restaurants.Remove(restaurant);
            }
            return restaurant;
        }

        public int GetCountOfRestaurants()
        {
            return restaurants.Count();
        }

        public int Commit()
        {
            return 0;
        }
    }


} 