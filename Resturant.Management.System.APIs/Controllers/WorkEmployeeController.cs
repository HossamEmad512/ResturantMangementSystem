using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resturant.Management.System.APIs.DTOs;
using Resturant.Management.System.APIs.Errors;
using Resturant.Management.System.Core.Entites;
using Resturant.Management.System.Core.Repository;
using Resturant.Management.System.Core.Specifications;

namespace Resturant.Management.System.APIs.Controllers
{
    
    public class WorkEmployeeController : APIBaseController
    {
        private readonly IGenericRepository<WorkEmployee> _repo;
        public WorkEmployeeController(IGenericRepository<WorkEmployee> repo)
        {
            _repo = repo;
        }

        //Get Employee By ResturantId

        [HttpGet("{ResturantId}")]
        [ProducesResponseType(typeof(WorkEmployee), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WorkEmployee>> GetResturantEmployee(int ResturantId)
        {
            var Spec = new WorkEmployeeSpecifications(ResturantId);
            var Employee = await _repo.GetAllWithSpecAsync(Spec);

            if (Employee is null)
            {
                return NotFound(new ApiResponse(404, "no Employee found"));
            }

            return Ok(Employee);
        }

        //create Employee
        [HttpPost("create")]
        public async Task<ActionResult<WorkEmployee>> AddEmployee(WorkEmployeeDto employee)
        {
            var Employee = new WorkEmployee()
            {
                Name = employee.Name,
                Salary  = employee.Salary,
                Phone = employee.Phone,
                ResturantId = employee.ResturantId,
            };
            await _repo.AddAsync(Employee);

            return Ok(Employee);
        }


        //update Employee
        [HttpPut("update")]
        public async Task<ActionResult<WorkEmployee>> UpdateEmployee(WorkEmployee employee)
        {
            _repo.Update(employee);
            return Ok(employee);
        }

        //delet employee
        [HttpDelete("delete/{EmployeeId}")]
        public async Task DeleteEmpolyee(int EmployeeId)
        {
            
            var Employee = await _repo.GetById(EmployeeId);
            _repo.Delete(Employee);

        }

    }
}
