using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resturant.Management.System.APIs.Errors;
using Resturant.Management.System.Core.Entites;
using Resturant.Management.System.Core.Repository;
using Resturant.Management.System.Core.Specifications;

namespace Resturant.Management.System.APIs.Controllers
{
    
    public class CurrentDisheController : APIBaseController
    {
        private readonly IGenericRepository<CurrentDishe> _currentDisheRepo;
        private readonly ICurrentDisheRepository _repository;

        public CurrentDisheController(IGenericRepository<CurrentDishe> currentDisheRepo, ICurrentDisheRepository repository)
        {
            _currentDisheRepo = currentDisheRepo;
            _repository = repository;

        }



        //Get by Resturant Id

        [HttpGet("{ResturantId}")]
        [ProducesResponseType(typeof(CurrentDishe), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<CurrentDishe>>> GetCurrentDishes(int ResturantId)
        {
            var currentDishes = await _repository.GetAllAsync(ResturantId);

            if (currentDishes is null)
            {
                return NotFound(new ApiResponse(404, "no current Dishes found"));
            }
            return Ok(currentDishes);
        }



        //Delete Current Dishe

        [HttpDelete("delete/{CurrentDisheId}")]
        public async Task DeleteCurrentDishe(int CurrentDisheId)
        {
            var Spec = new CurrentDisheDeleteSpecifications(CurrentDisheId);
            var Dishe = await _currentDisheRepo.GetByIdWithSpecAsync(Spec);
            _currentDisheRepo.Delete(Dishe);
        }

        //update Current Dishe

        [HttpPut("update")]
        public async Task updateCurrentDishe(CurrentDishe CurrentDishe)
        {
            
            _currentDisheRepo.Update(CurrentDishe);
        }
    }
}
