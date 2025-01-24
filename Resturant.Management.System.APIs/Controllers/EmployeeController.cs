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
    
    public class EmployeeController : APIBaseController
    {
        private readonly IGenericRepository<Employee> _repo;
        private readonly IMapper _mapper;

        public EmployeeController(IGenericRepository<Employee> repo , IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }


        //Get Resturant Employee
        [HttpGet("{ResturantId}")]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Employee>> GetResturantEmployee(int ResturantId)
        {
            var Spec = new EmployeeSpecifications(ResturantId);
            var Employee = await _repo.GetAllWithSpecAsync(Spec);

            if(Employee is null)
            {
                return NotFound(new ApiResponse(404, "no Employee found"));
            }

            return Ok(Employee);
        }

        //create Employee
        [HttpPost("create")]
        public async Task<ActionResult<Employee>> AddEmployee(EmployeeDto employee)
        {
            var Employee = _mapper.Map<EmployeeDto,Employee>(employee);
            await _repo.AddAsync(Employee);

            return Ok(Employee);
        }


        //update Employee
        [HttpPut("update")]
        public async Task<ActionResult<Employee>> UpdateEmployee(Employee employee)
        {
            _repo.Update(employee);
            return Ok(employee);
        }

        //delet employee
        [HttpDelete("delete/{EmployeeEmail}")]
        public async Task DeleteEmpolyee(string EmployeeEmail)
        {
            var Spec = new EmployeeDeleteSpecifications(EmployeeEmail);
            var Employee = await _repo.GetByIdWithSpecAsync(Spec);
            _repo.Delete(Employee);

        }
    }
}
