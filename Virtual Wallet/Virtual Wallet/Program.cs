using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using Virtual_Wallet.Data;
using Virtual_Wallet.Repository.Contracts;

namespace Virtual_Wallet
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
			builder.Services.AddControllers();
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

            // Repository
            //builder.Services.AddScoped<ICardRepository, CardRepository>();
            //builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IWalletRepository, WalletRepository>();
            builder.Services.AddScoped<ICardRepository, CardRepository>();

            // Services
            //builder.Services.AddScoped<ICardServices, CardServices>();
            //builder.Services.AddScoped<ITransactionServices, TransactionServices>();
            //builder.Services.AddScoped<IUserServices, UserServices>();
            builder.Services.AddScoped<IWalletService, WalletService>();
            builder.Services.AddScoped<ICardService, CardService>();

            //Helpers
            //builder.Services.AddScoped<AuthManager>();
            //builder.Services.AddScoped<PostCreatUpdateMapper>();
            //builder.Services.AddScoped<IMapper>();                      

            var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				//app.UseExceptionHandler("/Home/Error");
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