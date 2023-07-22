using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using Virtual_Wallet.Data;

namespace Virtual_Wallet
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
			builder.Services.AddControllersWithViews();


            builder.Services.AddDbContext<WalletContext>(options =>
            {


                //string connectionString = @"Server=FREAKY\MSSQLSERVER2022;Database=VirtualWalletDataBase;Trusted_Connection=True;Encrypt=False;";
                //string connectionString = @"Server=MILA-V15G2\SQLEXPRESS;Database=VirtualWalletDataBase;Trusted_Connection=True;Encrypt=False;";
                //string connectionString = @"Server=VILIMOV-PC;Database=VirtualWalletDataBase;Trusted_Connection=True;Encrypt=False;";
                string connectionString = @"Server=localhost;Database=VirtualWalletDataBase;Trusted_Connection=True;Encrypt=False;";

                options.UseSqlServer(connectionString);
                options.EnableSensitiveDataLogging();

            });

            builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				app.UseSwagger();
				app.UseSwaggerUI();
			}
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}