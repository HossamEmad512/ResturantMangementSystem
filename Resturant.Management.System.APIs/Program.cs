using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resturant.Management.System.APIs.Errors;
using Resturant.Management.System.APIs.Helpers;
using Resturant.Management.System.APIs.MiddleWares;
using Resturant.Management.System.Core.Entites;
using Resturant.Management.System.Core.Entites.Identity;
using Resturant.Management.System.Core.Repository;
using Resturant.Management.System.Repository;
using Resturant.Management.System.Repository.Data;
using Resturant.Management.System.Repository.Identity;

namespace Resturant.Management.System.APIs
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            #region configure services
            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //allow dependancy injection

            builder.Services.AddScoped<IGenericRepository<Resturants>, GenericRepository<Resturants>>();
            builder.Services.AddScoped<IGenericRepository<Order>, GenericRepository<Order>>();
            builder.Services.AddScoped<IGenericRepository<Sales>, GenericRepository<Sales>>();
            builder.Services.AddScoped<IGenericRepository<Employee>, GenericRepository<Employee>>();

            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddScoped<ISalesRepository, SalesRepository>();

            builder.Services.AddScoped<IGenericRepository<Menue>, GenericRepository<Menue>>();
            builder.Services.AddAutoMapper(typeof(MappingProfiles));
            //allow dependancy injection for dbcontext
            builder.Services.AddDbContext<ResturantManagementContext>(Options =>
            {
                Options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            //Identity DbContext
            builder.Services.AddDbContext<OwnerAccountIdentityDbContext>(Options =>
            {
                Options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection"));

            });
            builder.Services.AddIdentity<OwnerAccount, IdentityRole>()
                             .AddEntityFrameworkStores<OwnerAccountIdentityDbContext>();
            builder.Services.AddAuthentication(); //UserManager / signinManager / RoleManager

            //for policy
            builder.Services.AddCors(Options =>
            {
                Options.AddPolicy("MyPolicy", options =>
                {
                    options.AllowAnyHeader();
                    options.AllowAnyMethod();
                    options.AllowAnyOrigin();
                });
            });

            //configure ValidationError
            builder.Services.Configure<ApiBehaviorOptions>(Options =>
            {
                Options.InvalidModelStateResponseFactory = (actionContext) =>
                {
                    var errors = actionContext.ModelState.Where(P => P.Value.Errors.Count() > 0)
                                                         .SelectMany(P => P.Value.Errors)
                                                         .Select(E => E.ErrorMessage)
                                                         .ToList();
                    var ValidationErrorResponse = new ApiValidationErrorResponse()
                    {
                        Errors = errors
                    };
                    return new BadRequestObjectResult(ValidationErrorResponse);
                };
            });
            #endregion

            var app = builder.Build();

            #region Update dataBase

            //ResturantManagementContext dbContext = new ResturantManagementContext();
            //await dbContext.Database.MigrateAsync();
            using var Scope = app.Services.CreateScope();
            var Services = Scope.ServiceProvider;
            var LoggerFactory = Services.GetRequiredService<ILoggerFactory>();
            try
            {
                var dbContext = Services.GetRequiredService<ResturantManagementContext>();
                await dbContext.Database.MigrateAsync(); //update

               var IdentityDbContext = Services.GetRequiredService<OwnerAccountIdentityDbContext>();
                await IdentityDbContext.Database.MigrateAsync(); //update

            }catch (Exception ex)
            {
                var Logger = LoggerFactory.CreateLogger<Program>();
                Logger.LogError(ex, "An error occured during appling the migrations");
            }

                #endregion


            #region HTTP request pipeline

            // Configure the HTTP request pipeline.
             app.UseMiddleware<ExceptionMiddleWare>();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseStatusCodePagesWithReExecute("/errors/{0}");

            app.UseStaticFiles();
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
        #endregion
    }
    }
