using DominosAPI.Authentication;
using DominosAPI.IRepository;
using DominosAPI.Models;
using DominosAPI.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominosAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(Configuration.GetConnectionString("Defaultconnection")));
            services.AddDbContext<DominosDatabaseContext>(option => option.UseSqlServer(Configuration.GetConnectionString("Defaultconnection")));
            services.AddTransient<IAuthenticateRepository, AuthenticateRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IPizzaRepository, PizzaRepository>();
            services.AddTransient<IOfferRepository, OfferRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IPizzaStoreRepository, PizzaStoreRepository>();
            services.AddTransient<IToppingRepository, ToppingRepository>();
            services.AddTransient<IContactUsRepository, ContactUsRepository>();
            services.AddTransient<IAddressRepository, AddressRepository>();
            services.AddTransient<ICartItemRepository, CartItemRepository>();
            services.AddTransient<IPincodeRepository, PincodeRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();

            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));
            services.AddTransient<IMailServiceRepository, MailServiceRepository>();

            services.Configure<IdentityOptions>(opts =>
            {
                opts.User.RequireUniqueEmail = true;
                opts.Password.RequiredLength = 9;
                opts.SignIn.RequireConfirmedEmail = true;
            });


            //Add AutoMapper
            services.AddAutoMapper(typeof(Startup));

            //For Identity
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            //Add Authentication
            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })

            //Add Jwt Bearer
            .AddJwtBearer(option =>
            {
                option.SaveToken = true;
                option.RequireHttpsMetadata = false;
                option.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = Configuration["Jwt:ValidAudience"],
                    ValidIssuer=Configuration["Jwt:ValidIssuer"],
                    IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                };
            });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
