using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HIN_ventures.Models;

namespace HIN_ventures.Business.Repositories.IRepositories
{
    public interface IRatingRepository
    {
        public Task<RatingDto> Create(RatingDto rating);
        public Task<RatingDto> GetRating(int ratingId);
        public Task<IEnumerable<RatingDto>> GetAllRatings();
        public Task<bool> UpdateRating(int ratingId);
    }
}
