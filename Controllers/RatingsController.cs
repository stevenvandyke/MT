using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using WebApi.Models;

namespace WebApi.Controllers
{
    public class RatingsController : ApiController
    {
        // POST api/values
        public void Post(Rating rating)
        {
            using (var entitites = new RestaurantDbEntities())
            {
                var existingRestaurant = entitites.Restaurants.FirstOrDefault(r => r.Id == rating.RestaurantId);

                if (existingRestaurant != null)
                {
                    var previousAverageRating = existingRestaurant.AverageRating;

                    existingRestaurant.NumberOfRatings += 1;
                    existingRestaurant.TotalRatings += rating.Value;
                    existingRestaurant.AverageRating = existingRestaurant.TotalRatings / (decimal)existingRestaurant.NumberOfRatings;
                    entitites.SaveChanges();

                    if (previousAverageRating >= 2 && existingRestaurant.AverageRating < 2)
                    {
                        // Trigger an event notification when the average rating transitions below 2
                    }
                }
            }
        }
    }
}
