using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HIN_ventures.DataAccess.Entities;
using HIN_ventures.Models;

namespace HIN_ventures.Client.Service.IService
{
    public interface IRatingService
    {
        public Task<RatingDto> SaveRating(RatingDto rating);

        public Task<IEnumerable<RatingDto>> GetRatings(); 

        public Task<RatingDto> GetRating(int ratingId);

    }
}
