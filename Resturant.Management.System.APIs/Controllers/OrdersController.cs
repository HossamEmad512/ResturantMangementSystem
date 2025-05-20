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
   
    public class OrdersController : APIBaseController
    {
        private readonly IGenericRepository<Order> _orderRepo;
        private readonly IGenericRepository<CurrentDishe> _currentDisheRepo;

        private readonly IMapper _mapper;
        private readonly IOrderRepository _repository;

        public OrdersController(IGenericRepository<Order> orderRepo, IMapper mapper , IOrderRepository repository, IGenericRepository<CurrentDishe> currentDisheRepo)
        {
            _orderRepo = orderRepo;
            _mapper = mapper;
            _repository = repository;
            _currentDisheRepo = currentDisheRepo;
        }




        //Get order by Resturant Id

        [HttpGet("{ResturantId}")]
        [ProducesResponseType(typeof(Order), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders(int ResturantId)
        {
            var Orders = await _repository.GetAllAsync(ResturantId);
           
            if (Orders is null)
            {
                return NotFound(new ApiResponse(404, "no order found"));
            }
            return Ok(Orders);
        }


        //create Order

        [HttpPost("create")]
        [ProducesResponseType(typeof(Order), StatusCodes.Status200OK)]
        public async Task<ActionResult<Order>> CreateOrder(OrderDto order)
        {

            var Order = _mapper.Map<OrderDto, Order>(order);
            var CurrentDishe = new CurrentDishe()
            {
                ResturantId=Order.ResturantId,
                OrderItems=Order.OrderItems,
                TableNumber=Order.TableNumber,
                PhoneNumber=Order.PhoneNumber,
                Status="In Progress"
            };
            await _currentDisheRepo.AddAsync(CurrentDishe); 
            if(Order.TableNumber == 0)
            {
                await _orderRepo.AddAsync(Order);
                return Ok(Order);

            }
            var Orders = await _repository.GetAllAsync(Order.ResturantId);
            if (Orders is null)
            {

                await _orderRepo.AddAsync(Order);
                return Ok(Order);

            }
            else
            {
                foreach(var item in Orders)
                {
                    if(item.TableNumber== Order.TableNumber)
                    {
                        foreach(var orderItem in Order.OrderItems)
                        {
                            item.OrderItems.Add(orderItem);
                        }
                        _orderRepo.Update(item);
                        return Ok(Order);
                    }
                }
                await _orderRepo.AddAsync(Order);
                return Ok(Order);
            }
            
        }

        //Update Order

        [HttpPut("update")]
        [ProducesResponseType(typeof(Order), StatusCodes.Status200OK)]
        public async Task<ActionResult<Order>> UpdateOrder(Order Order)
        {
            _orderRepo.Update(Order);
            return Ok(Order);
        }

        //Delete Order

        [HttpDelete("delete/{OrderId}")]
        public async Task DeleteOrder(int OrderId)
        {
            var Spec = new OrderDeleteSpecifications(OrderId);
            var Order= await _orderRepo.GetByIdWithSpecAsync(Spec);
            _orderRepo.Delete(Order);
        }
    }
}
