using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resturant.Management.System.APIs.DTOs;
using Resturant.Management.System.APIs.Errors;
using Resturant.Management.System.Core.Entites;
using Resturant.Management.System.Core.Repository;

namespace Resturant.Management.System.APIs.Controllers
{
    
    public class SalesController : APIBaseController
    {
        private readonly IGenericRepository<Sales> _repo;
        private readonly ISalesRepository _salesRepo;
        private readonly IMapper _mapper;

        public SalesController(IGenericRepository<Sales> repo , ISalesRepository salesRepo , IMapper mapper)
        {
            _repo = repo;
            _salesRepo = salesRepo;
            _mapper = mapper;
        }

        //Get sales by Resturant Id

        [HttpGet("{ResturantId}")]
        [ProducesResponseType(typeof(SalesDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SalesDto>> GetSales(int ResturantId)
        {
            var Sales = await _salesRepo.GetSaleByResturantId(ResturantId);
            var Result = _mapper.Map<Sales , SalesDto>(Sales);
            Result.TotalCost= Sales.GetTotalCost();
            Result.TotalProfit = Sales.GetTotalProfit();
            Result.TotalPrice = Sales.GetTotalPrice();

            if (Result is null)
            {
                return NotFound(new ApiResponse(404, "no Sales found"));
            }
            return Ok(Result);
        }


        //create or update sales

        [HttpPost]
        public async Task<ActionResult<SalesDto>> CreateOrUpdateSales(SalesOrders Order )
        {
            var Sales = await _salesRepo.GetSaleByResturantId(Order.ResturantId);
            if(Sales is null)
            {
                Sales = new Sales()
                {
                    ResturantId = Order.ResturantId,

                };
                Sales.Orders.Add(Order);

                await _repo.AddAsync(Sales);
            }
            else
            {
                Sales.Orders.Add(Order);
                 _repo.Update(Sales);
            }
            var Result = _mapper.Map<Sales, SalesDto>(Sales);
            Result.TotalCost = Sales.GetTotalCost();
            Result.TotalProfit = Sales.GetTotalProfit();
            Result.TotalPrice = Sales.GetTotalPrice();
            return Ok(Result);
        }




    }
}
