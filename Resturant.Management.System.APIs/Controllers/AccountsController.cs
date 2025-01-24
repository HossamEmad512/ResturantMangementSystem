using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Resturant.Management.System.APIs.DTOs;
using Resturant.Management.System.APIs.Errors;
using Resturant.Management.System.Core.Entites;
using Resturant.Management.System.Core.Entites.Identity;
using Resturant.Management.System.Core.Repository;
using Resturant.Management.System.Core.Specifications;

namespace Resturant.Management.System.APIs.Controllers
{
    
    public class AccountsController : APIBaseController
    {
        private readonly UserManager<OwnerAccount> _userManager;
        private readonly SignInManager<OwnerAccount> _signInManager;
        private readonly IGenericRepository<Employee> _repo;

        public AccountsController(UserManager<OwnerAccount> userManager , SignInManager<OwnerAccount> signInManager , IGenericRepository<Employee> repo)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _repo = repo;
        }


        //Registar
        [HttpPost("Registar")]
        [ProducesResponseType(typeof(OwnerDto) , StatusCodes.Status200OK)]
        public async Task<ActionResult<OwnerDto>> Registar(RegistarDto model)
        {
            var User = new OwnerAccount()
            {
                Email = model.Email,
                DisplayName = model.DisplayName,
                UserName = model.Email.Split('@')[0],
                PhoneNumber = model.PhoneNumber,
            };
            var Result = await _userManager.CreateAsync(User, model.Password);
            if (!Result.Succeeded)
            {
                return BadRequest();
            }
            var ReturnedUser = new OwnerDto()
            {
                DisplayName = model.DisplayName,
                Email = model.Email,
                Role = model.Role,
                Token = "sss"
            };
            return Ok(ReturnedUser);
        }
        //login
        [HttpPost("Login")]
        public async Task<ActionResult<OwnerDto>> Login(LoginDto model)
        {
            if(model.Role == "Owner")
            {
                var User = await _userManager.FindByEmailAsync(model.Email);
                if (User is null)
                {
                    return NotFound(new ApiResponse(404, "User Not Found"));
                }

                var Result = await _signInManager.CheckPasswordSignInAsync(User, model.Password, false);
                if (!Result.Succeeded)
                {
                    return BadRequest();

                }
                var ReturnedUser = new OwnerDto()
                {
                    DisplayName = User.DisplayName,
                    Email = model.Email,
                    Role = model.Role,
                    Token = "sss"
                };
                return Ok(ReturnedUser);
            }
            else
            {
                var spec = new EmployeeSpecifications(model.Email);

                var emp = await _repo.GetByIdWithSpecAsync(spec);
                if (emp != null)
                {
                    if(emp.Password == model.Password) 
                    {
                        var Result = new OwnerDto()
                        {
                            DisplayName = emp.Name,
                            Email = model.Email,
                            Role = model.Role,
                            Token = "sss"
                        };
                        return Ok(Result);
                    }

                }
                else
                {
                    return NotFound(new ApiResponse(404, "no Employee found"));
                }
                return BadRequest();
            }
        }
    }
}
