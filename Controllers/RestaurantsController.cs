using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

using WebApi.Models;

namespace WebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class RestaurantsController : ApiController
    {
        // GET: api/Restaurants
        public IEnumerable<Restaurant> Get()
        {
            using (var entitites = new RestaurantDbEntities())
            {
                return entitites.Restaurants.ToList();
            }
        }

        // GET: api/Restaurants/5
        public Restaurant Get(int restaurantId)
        {
            using (var entitites = new RestaurantDbEntities())
            {
                return entitites.Restaurants.FirstOrDefault(r => r.Id == restaurantId);
            }
        }

        // POST: api/Restaurants
        public void Post(Restaurant restaurant)
        {
            using (var entitites = new RestaurantDbEntities())
            {
                entitites.Restaurants.Add(restaurant);
                entitites.SaveChanges();
            }
        }

        // PUT: api/Restaurants/5
        public void Put(int restaurantId, Restaurant restaurant)
        {
            using (var entitites = new RestaurantDbEntities())
            {
                var existingRestaurant = entitites.Restaurants.FirstOrDefault(r => r.Id == restaurantId);

                if (existingRestaurant != null)
                {
                    existingRestaurant.Name = restaurant.Name;
                    existingRestaurant.Address = restaurant.Address;
                    existingRestaurant.Description = restaurant.Description;
                    existingRestaurant.Hours = restaurant.Hours;
                    existingRestaurant.NumberOfRatings = restaurant.NumberOfRatings;
                    existingRestaurant.TotalRatings = restaurant.TotalRatings;
                    existingRestaurant.AverageRating = restaurant.AverageRating;
                    entitites.SaveChanges();
                }
            }
        }

        // DELETE: api/Restaurants/5
        public void Delete(int restaurantId)
        {
            using (var entitites = new RestaurantDbEntities())
            {
                var existingRestaurant = entitites.Restaurants.FirstOrDefault(r => r.Id == restaurantId);

                if (existingRestaurant != null)
                {
                    entitites.Restaurants.Remove(existingRestaurant);
                    entitites.SaveChanges();
                }
            }
        }
    }
}
