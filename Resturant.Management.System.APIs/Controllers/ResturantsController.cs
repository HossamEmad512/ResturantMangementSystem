using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resturant.Management.System.APIs.DTOs;
using Resturant.Management.System.APIs.Errors;
using Resturant.Management.System.Core.Entites;
using Resturant.Management.System.Core.Repository;
using Resturant.Management.System.Core.Specifications;

namespace Resturant.Management.System.APIs.Controllers
{
    
    public class ResturantsController : APIBaseController
    {
        private readonly IGenericRepository<Resturants> _resturantRepo;

        public ResturantsController(IGenericRepository<Resturants> ResturantRepo)
        {
            _resturantRepo = ResturantRepo;
        }


        [HttpGet("{email}")]
        [ProducesResponseType(typeof(IEnumerable<Resturants>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse) , StatusCodes.Status404NotFound)]

        public async Task<ActionResult<IEnumerable<Resturants>>> GetResturantsByOwnerEmail(string email)
        {
            var Spec = new ResturantOwnerEmailSpecifications(email);
            var Resturants = await _resturantRepo.GetAllWithSpecAsync(Spec);
            if(Resturants.Count() <= 0)
            {
                return NotFound(new ApiResponse(404, "No Resturan for this owner"));
            }
            return Ok(Resturants);

        }

        [HttpPost("create")]
        [ProducesResponseType(typeof(Resturants), StatusCodes.Status200OK)]

        public async Task<ActionResult<Resturants>> CreateResturant(ResturantDto resturant)
        {
            var Resturant = new Resturants()
            {
                ResturantName = resturant.ResturantName,
                OwnerEmail = resturant.OwnerEmail,
            };
            await _resturantRepo.AddAsync(Resturant);

            return Ok(Resturant);
        }
        [HttpPut("update")]
        [ProducesResponseType(typeof(Resturants), StatusCodes.Status200OK)]

        public async Task<ActionResult<Resturants>> UpdateResturant(Resturants resturant)
        {
            var Resturant = new Resturants()
            {
                ResturantName = resturant.ResturantName,
                OwnerEmail = resturant.OwnerEmail,
                Id = (int) resturant.Id,
            };
            _resturantRepo.Update(Resturant);

            return Ok(Resturant);
        }


        [HttpDelete("delete")]

        public async Task DeleteResturant(Resturants resturant)
        {
            var Resturant = new Resturants()
            {
                ResturantName = resturant.ResturantName,
                OwnerEmail = resturant.OwnerEmail,
                Id = (int)resturant.Id,
            };
            _resturantRepo.Delete(Resturant);

            
        }
    }
}
