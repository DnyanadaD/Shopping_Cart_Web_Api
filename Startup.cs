using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using ShoppingCart_API.Data;
using ShoppingCart_API.Models;
using ShoppingCart_API.Repository;
using ShoppingCart_API.Services;
using Swashbuckle;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ShoppingCart_API
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
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = "https://localhost:44389",
                        ClockSkew = TimeSpan.Zero,
                        ValidAudiences = new List<string>
                        {
                            "https://localhost:44389",
                            "https://localhost:4200"
                        },
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("PNM4t3NEYbOd1SGe"))
                    };
                });

            services.AddDbContext<ShoppingCartDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SqlConnection")));


            #region AddTransients
            //User
            services.AddTransient<IUser, UserRepo>();
            services.AddTransient<UserDetailsServices, UserDetailsServices>();

            //Product
            services.AddTransient<IProduct, ProductRepo>();
            services.AddTransient<ProductService, ProductService>();

            //Cart
            services.AddTransient<ICart, CartRepo>();
            services.AddTransient<CartService, CartService>();

            //order
            services.AddTransient<IOrder, OrderRepo>();
            services.AddTransient<OrderService, OrderService>();

            //Payment
            services.AddTransient<IPayment, PaymentRepo>();
            services.AddTransient<PaymentService, PaymentService>();

            //Address
            services.AddTransient<IAddress, AddressRepo>();
            services.AddTransient<AddressService, AddressService>();

            //Feedback
            services.AddTransient<IFeedback, FeedbackDetails>();
            services.AddTransient<FeedbackService, FeedbackService>();
            #endregion

            services.AddCors();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ShoppingCart_API", Version = "v1" });
            });
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(builder => builder.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader().AllowCredentials());
            //if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ShoppingCart_API v1"));
            }

            app.UseHttpsRedirection();

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