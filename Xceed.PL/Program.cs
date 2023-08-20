using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Xceed.BLL.Interfaces;
using Xceed.BLL.Repositories;
using Xceed.DAL.Contexts;
using Xceed.DAL.Entities;
using Xceed.PL.Mapper;

namespace Xceed.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<XceedDbContext>(op =>
            {
                op.UseSqlServer(builder.Configuration.GetConnectionString("Cs"));
            });

            builder.Services.AddScoped<IEmployeeRep, EmployeeRep>();
            builder.Services.AddScoped<IAccountRep, AccountRep>();
            builder.Services.AddScoped<ILanguageRep, LanguageRep>();
            builder.Services.AddScoped<ILanguageLevelRep, LanguageLevelRep>();
            builder.Services.AddScoped<ILineOfBusinessRep, LineOfBusinessRep>();
            builder.Services.AddScoped<IEmployeeLanguageLevelsRep, EmployeeLanguageLevelsRep>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            builder.Services.AddAutoMapper(M => M.AddProfile(new MappingProfiles()));


            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
                {
                    options.LoginPath = new PathString("/Account/Login");
                    options.AccessDeniedPath = new PathString("/Home/Error");
                });

            builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                // Default Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 0;
            }).AddEntityFrameworkStores<XceedDbContext>()
            .AddTokenProvider<DataProtectorTokenProvider<AppUser>>(TokenOptions.DefaultProvider);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}