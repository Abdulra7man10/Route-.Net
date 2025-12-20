using GymManagmentDAL.Data.Context;
using Microsoft.EntityFrameworkCore;
using GymManagmentDAL.Repostories.Classes;
using GymManagmentDAL.Repostories.Interfaces;
using GymManagmentDAL.Entities;

namespace GymManagmentPL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<GymDBContext>(option => {
                //option.UseSqlServer(builder.Configuration.GetSection("ConnectionStrings")["DefaultConnection"]); // 1
                //option.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]); // 2
                option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")); // 3 (easiest way)
            });
            builder.Services.AddScoped(typeof(IGenericRepostory<>), typeof(GenericRepostory<>)); // typeof because of generic class
            builder.Services.AddScoped<IPlanRepostory, PlanRepository>();

            var app = builder.Build();



            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
