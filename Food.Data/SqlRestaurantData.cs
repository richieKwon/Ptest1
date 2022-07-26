using System.Collections.Generic;
using System.Linq;
using Food.Core;
using Microsoft.EntityFrameworkCore;

namespace Food.Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly FoodDbContext _foodDbContext;

        public SqlRestaurantData(FoodDbContext foodDbContext)
        {
            _foodDbContext = foodDbContext;
        }
        public IEnumerable<Restaurant> GetRestaurantByName(string name)
        {
            var query = from r in _foodDbContext.Restaurants
                where r.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                orderby r.Name
                select r;  
            return query;
        }

        public Restaurant GetById(int id)
        {
            return _foodDbContext.Restaurants.Find(id);
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var entity = _foodDbContext.Restaurants.Attach(updatedRestaurant);
            entity.State = EntityState.Modified;
            return updatedRestaurant;
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            _foodDbContext.Add(newRestaurant);
            return newRestaurant;
        }

        public Restaurant Delete(int id)
        {
            var restaurant = GetById(id);
            if (restaurant != null)
            {
                _foodDbContext.Restaurants.Remove(restaurant);
            }

            return restaurant;
        }

        public int GetCountOfRestaurants()
        {
            return _foodDbContext.Restaurants.Count();
        }

        public int Commit()
        {
            return _foodDbContext.SaveChanges();
        }
    }
}