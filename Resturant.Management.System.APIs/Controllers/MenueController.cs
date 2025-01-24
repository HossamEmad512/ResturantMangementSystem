using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resturant.Management.System.APIs.DTOs;
using Resturant.Management.System.APIs.Errors;
using Resturant.Management.System.Core.Entites;
using Resturant.Management.System.Core.Repository;
using Resturant.Management.System.Core.Specifications;

namespace Resturant.Management.System.APIs.Controllers
{
    
    public class MenueController : APIBaseController
    {
        private readonly IGenericRepository<Menue> _menueRepo;
        private readonly IMapper _mapper;

        public MenueController(IGenericRepository<Menue> menueRepo , IMapper mapper)
        {
            _menueRepo = menueRepo;
            _mapper = mapper;
        }


        //Get menue
        [HttpGet("{ResturantId}")]
        [ProducesResponseType(typeof(Menue), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]

        public async Task<ActionResult<Menue>> GetMenue(int ResturantId)
        {
            var Spec = new MenueSpecifications(ResturantId);
            var Menue = await _menueRepo.GetByIdWithSpecAsync(Spec);
            if(Menue is null)
            {
                return NotFound(new ApiResponse(404 , "no menue found"));
            }
            return Ok(Menue);
        }

        //Add Menue

        [HttpPost("create")]
        [ProducesResponseType(typeof(MenueDto), StatusCodes.Status200OK)]
        public async Task<ActionResult<MenueDto>> CreateMenue(MenueDto menue)
        {
            var Menue = _mapper.Map<MenueDto, Menue>(menue);
            await _menueRepo.AddAsync(Menue);
            return Ok(menue);
        }

        //Update Menue

        [HttpPut("update")]
        [ProducesResponseType(typeof(Menue), StatusCodes.Status200OK)]
        public async Task<ActionResult<Menue>> UpdateMenue(Menue menue)
        {
            _menueRepo.Update(menue);
            return Ok(menue);
        }

        //Delete Menue

        [HttpDelete("delete/{ResturantId}")]
        public async Task DeleteMenue(int ResturantId)
        {
            var Spec = new MenueSpecifications(ResturantId);
            var Menue = await _menueRepo.GetByIdWithSpecAsync(Spec);
            _menueRepo.Delete(Menue);
        }
    }
}
