using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resturant.Management.System.APIs.DTOs;
using Resturant.Management.System.APIs.Errors;
using Resturant.Management.System.Core.Entites;
using Resturant.Management.System.Core.Repository;
using Resturant.Management.System.Core.Specifications;

namespace Resturant.Management.System.APIs.Controllers
{
    
    public class RecommendationsController : APIBaseController
    {

        private readonly IGenericRepository<Recommendation> _recommendationRepo;

        public RecommendationsController(IGenericRepository<Recommendation> RecommendationRepo)
        {
            _recommendationRepo = RecommendationRepo;
        }
        [HttpGet("{resturantId}")]
        [ProducesResponseType(typeof(IEnumerable<Recommendation>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult< IEnumerable<Recommendation>>> GetResturantRecommendation(int resturantId)
        {
            var spec = new RecommendationSpecification(resturantId);
            var Recommendations = await _recommendationRepo.GetAllWithSpecAsync(spec);
            if(Recommendations is null)
            {
                return NotFound(new ApiResponse(404, "No Recommendations Found"));
            }
            return Ok(Recommendations);

        }
        [HttpPost("create")]
        public async Task CreateReccomendation(RecommendationDto recommendation)
        {
            var Recommendation = new Recommendation()
            {
                Name = recommendation.Name,
                PrepMethod = recommendation.PrepMethod,
                Price = recommendation.Price,
                Category = recommendation.Category,
                Cost = recommendation.Cost,
                Rating = recommendation.Rating,
                Country = recommendation.Country,
                ResturantId= recommendation.ResturantId,
            };
            await _recommendationRepo.AddAsync(Recommendation);
        }

        [HttpDelete("delete/{id}")]

        public async Task DeleteResturant(int id)
        {
            var Recommendation = await _recommendationRepo.GetById(id);
            _recommendationRepo.Delete(Recommendation);

        }
    }
}
