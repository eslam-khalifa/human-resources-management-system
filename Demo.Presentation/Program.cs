using Demo.BusinessLogic;
using Demo.BusinessLogic.Profiles;
using Demo.BusinessLogic.Services.AttachementService;
using Demo.BusinessLogic.Services.Classes;
using Demo.BusinessLogic.Services.Interfaces;
using Demo.DataAccess.Data.Contexts;
using Demo.DataAccess.Data.Repositories.Implementation;
using Demo.DataAccess.Data.Repositories.Interfaces;
using Demo.DataAccess.Data.UnitOfWork.Classes;
using Demo.DataAccess.Data.UnitOfWork.Interfaces;
using Demo.DataAccess.Entities.IdentityEntities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Add services to the container.

            builder.Services.AddControllersWithViews(options =>
            {
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            }
            );
            builder.Services.AddDbContext<Demo.DataAccess.Data.Contexts.ApplicationDbContext>(
                options =>
                {
                    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
                    options.UseLazyLoadingProxies();
                }
             );
            builder.Services.AddScoped<IDepartmentService, DepartmentService>();
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddAutoMapper(typeof(Demo.BusinessLogic.ProjectReference).Assembly,
                                           typeof(Demo.Presentation.ProjectReference).Assembly);
            builder.Services.AddScoped<IAttachementService, AttachementService>();
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                            .AddEntityFrameworkStores<ApplicationDbContext>()
                            .AddDefaultTokenProviders();
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                            .AddCookie(options =>
                            {
                                options.LoginPath = "Account/Login";
                                options.AccessDeniedPath = "Home/Error";
                            });

            #endregion

            var app = builder.Build();

            #region Configure the HTTP request pipeline.

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Account}/{action=Login}/{id?}");

            #endregion

            app.Run();
        }
    }
}
