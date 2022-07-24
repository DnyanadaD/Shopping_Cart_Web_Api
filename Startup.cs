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
            services.AddDbContext<ShoppingCartDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SqlConnection")));
            //services.AddControllersWithViews().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore).AddNewtonsoftJson(
            //options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());
            //User
            services.AddTransient<IUser, UserRepo>();
            services.AddTransient<UserDetailsServices, UserDetailsServices>();

            //Product
            services.AddTransient<IProduct, ProductRepo>();
            services.AddTransient<ProductService , ProductService>();

            //Cart
            services.AddTransient<ICart, CartRepo>();
            services.AddTransient<CartService, CartService>();

            //order
            services.AddTransient<IOrder, OrderRepo>();
            services.AddTransient<OrderService, OrderService>();

            //Payment
            services.AddTransient<IPayment, PaymentRepo>();
            services.AddTransient<PaymentService, PaymentService>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ShoppingCart_API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ShoppingCart_API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
