using Demo.BLL;
using Demo.DAL.Data.Contexts;
using Demo.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
namespace WebApplication2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            #region configure service: add service to the id container
            builder.Services.AddControllersWithViews();
            //builder.Services.AddScoped<ApplicationDbContext>();
            builder.Services.AddDbContext<ApplicationDbContext>(Options =>
               {
                   var constring = builder.Configuration.GetConnectionString("DefaultConnection");

                   Options.UseSqlServer(constring);
               });


            builder.Services.AddScoped<IDepartmentRepository,DepartmentRepository>();
            builder.Services.AddScoped<IDepartmentService, DepartmentService>();
            #endregion
            var app = builder.Build();

            // Configure the HTTP request pipeline.
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
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }

}
