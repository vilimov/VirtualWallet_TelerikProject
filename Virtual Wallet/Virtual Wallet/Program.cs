using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using Virtual_Wallet.VirtualWallet.API.Helpers.Mappers;
using Virtual_Wallet.VirtualWallet.Application.Services;
using Virtual_Wallet.VirtualWallet.Persistence.Data;
using Virtual_Wallet.VirtualWallet.Persistence.Repository;
using Virtual_Wallet.VirtualWallet.Persistence.Repository.Contracts;
using VirtualWallet.Application.AdditionalHelpers;
using VirtualWallet.Application.Services;
using VirtualWallet.Application.Services.Contracts;

namespace Virtual_Wallet
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

            // Register AutoMapper
            builder.Services.AddAutoMapper(typeof(MappingProfile));

			// Login
			builder.Services.AddSession(options =>
			{
				options.IdleTimeout = TimeSpan.FromMinutes(15);
				options.Cookie.HttpOnly = true;
				options.Cookie.IsEssential = true;
			});
			builder.Services.AddHttpContextAccessor();

			// Add services to the container.
			builder.Services.AddControllers();
			builder.Services.AddControllersWithViews();


            builder.Services.AddDbContext<WalletContext>(options =>
            {


                //string connectionString = @"Server=FREAKY\MSSQLSERVER2022;Database=VirtualWalletDataBase;Trusted_Connection=True;Encrypt=False;";
               string connectionString = @"Server=MILA-V15G2\SQLEXPRESS;Database=VirtualWalletDataBase;Trusted_Connection=True;Encrypt=False;";
                //string connectionString = @"Server=VILIMOV-PC;Database=VirtualWalletDataBase;Trusted_Connection=True;Encrypt=False;";
                //string connectionString = @"Server=localhost;Database=VirtualWalletDataBase;Trusted_Connection=True;Encrypt=False;";

                options.UseSqlServer(connectionString);
                options.EnableSensitiveDataLogging();

            });

            builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

            // Repository
            //builder.Services.AddScoped<ICardRepository, CardRepository>();
            builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IWalletRepository, WalletRepository>();
            builder.Services.AddScoped<ICardRepository, CardRepository>();

            // Services
            //builder.Services.AddScoped<ICardServices, CardServices>();
            builder.Services.AddScoped<ITransactionService, TransactionService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IAdminService, AdminService>();
            builder.Services.AddScoped<IWalletService, WalletService>();
            builder.Services.AddScoped<ICardService, CardService>();
            builder.Services.AddScoped<IEmailService, EmailService>();

            //Helpers
            builder.Services.AddScoped<AuthManager>();
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

            app.UseSession();

			app.UseRouting();

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