using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HIN_ventures.Client.Service.IService;
using HIN_ventures.Models;
using Newtonsoft.Json;

namespace HIN_ventures.Client.Service
{
    public class RatingService : IRatingService
    {
        private readonly HttpClient _client;

        public RatingService(HttpClient client)
        {
            _client = client;
        }

        public async Task<RatingDto> SaveRating(RatingDto rating)
        {
            var content = JsonConvert.SerializeObject(rating);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("api/rating/create", bodyContent);
            string res = response.Content.ReadAsStringAsync().Result;
            if (response.IsSuccessStatusCode)
            {
                var contentTemp = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<RatingDto>(contentTemp);
                return result;
            }
            else
            {
                var contentTemp = await response.Content.ReadAsStringAsync();
                var errorModel = JsonConvert.DeserializeObject<ErrorModel>(contentTemp);
                throw new Exception(errorModel.ErrorMessage);
            }
        }

        public async Task<IEnumerable<RatingDto>> GetRatings()
        {
            var response = await _client.GetAsync($"api/rating/GetRatings");
            var content = await response.Content.ReadAsStringAsync();
            var ratings = JsonConvert.DeserializeObject<IEnumerable<RatingDto>>(content);
            return ratings;
        }

        public async Task<RatingDto> GetRating(int ratingId)
        {
            var response = await _client.GetAsync($"api/rating/{ratingId}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var rating = JsonConvert.DeserializeObject<RatingDto>(content);
                return rating;
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                var errorModel = JsonConvert.DeserializeObject<ErrorModel>(content);
                throw new Exception(errorModel.ErrorMessage);
            }
        }
    }
}
