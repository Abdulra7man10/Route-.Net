using GymManagmentBLL;
using GymManagmentBLL.Service;
using GymManagmentBLL.Service.Classes;
using GymManagmentBLL.Service.Classes.AttachmentService;
using GymManagmentBLL.Service.Interfaces;
using GymManagmentBLL.Service.Interfaces.AttachmentService;
using GymManagmentBLL.Services.Classes;
using GymManagmentBLL.Services.Interfaces;
using GymManagmentDAL.Data.Context;
using GymManagmentDAL.Data.DataSeeding;
using GymManagmentDAL.Entities;
using GymManagmentDAL.Repostories.Classes;
using GymManagmentDAL.Repostories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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
            //builder.Services.AddScoped(typeof(IGenericRepostory<>), typeof(GenericRepostory<>)); // typeof because of generic class
            //builder.Services.AddScoped<IPlanRepostory, PlanRepository>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<ISessionRepository, SessionRepository>();
            builder.Services.AddAutoMapper(x => x.AddProfile(new MappingProfile()));

            builder.Services.AddScoped<IAnalyticsService, AnalyticsService>();
            builder.Services.AddScoped<IMemberService, MemberService>();
            builder.Services.AddScoped<ITrainerService, TrainerService>();
            builder.Services.AddScoped<IPlanService, PlanService>();
            builder.Services.AddScoped<ISessionService, SessionService>();

            builder.Services.AddScoped<IAttachmentService, AttachmentService>();

            builder.Services.AddScoped<IAccountService, AccountService>();
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(conf =>
            {
                //conf.Password.RequireUppercase = true;
                //conf.Password.RequireLowercase = true;
                //conf.Password.RequiredLength = 6;
                conf.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<GymDBContext>();
            builder.Services.ConfigureApplicationCookie(option => 
            {
                option.LogoutPath = "/Account/Login";
                option.AccessDeniedPath = "/Account/AccessDenied";
            });

            var app = builder.Build();

            #region DataSeeding
            using var scope = app.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<GymDBContext>();

            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            var pendingMigrations = dbContext.Database.GetPendingMigrations();
            if (pendingMigrations?.Any() ?? false)
            {
                dbContext.Database.Migrate();
            }

            GymDbContextSeeding.SeedData(dbContext, app.Environment.ContentRootPath);
            IdentityDbContextSeeding.SeedData(roleManager, userManager);
            #endregion



            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Account}/{action=Login}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
