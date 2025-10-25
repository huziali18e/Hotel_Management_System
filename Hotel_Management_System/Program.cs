using Hotel_Management_System.DBC;
using Hotel_Management_System.Models.Booking;
using Hotel_Management_System.Models.Payments;
using Hotel_Management_System.Models.Room;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Management_System
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<HotelDBContext>(option =>

                option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
            ));
            builder.Services.AddDbContext<RoomDBContext>(Action =>

                Action.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
            ));
            builder.Services.AddDbContext<BookingDBContext>(chioces =>

                chioces.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
            ));
            builder.Services.AddDbContext<PaymentDBContext>(picups =>

                picups.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
            ));

            builder.Services.AddAuthentication(
                CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie( option =>
                {
                    option.LoginPath = "/Access/Login";
                    option.ExpireTimeSpan = TimeSpan.FromMinutes(20);
                }
                
                );

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Access}/{action=Login}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
