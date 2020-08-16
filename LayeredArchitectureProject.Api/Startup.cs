using LayeredArchitectureProject.Api.Services.Cart;
using LayeredArchitectureProject.Data;
using LayeredArchitectureProject.Data.Infrastructure.Repository;
using LayeredArchitectureProject.Data.Infrastructure.Repository.EntityFramework;
using LayeredArchitectureProject.Data.Infrastructure.UnitOfWork;
using LayeredArchitectureProject.Data.Infrastructure.UnitOfWork.EntityFramework;
using LayeredArchitectureProject.Service.Cart;
using LayeredArchitectureProject.Service.Product;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace LayeredArchitectureProject.Api
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
            services.AddControllers().AddNewtonsoftJson();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "LayeredArchitectureProject API", Version = "v1" });
            });

            services.AddEntityFrameworkSqlite()
                .AddDbContext<ApplicationDbContext>(
                    options => { options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")); });

            services.AddScoped(typeof(IUnitOfWork), typeof(EfUnitOfWorkBase));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepositoryBase<>));

            services.AddScoped(typeof(ICartService), typeof(CartService));
            services.AddScoped(typeof(IProductService), typeof(ProductService));
            services.AddSingleton(typeof(ICartSessionService), typeof(CartSessionService));
            services.AddSingleton(typeof(IHttpContextAccessor), typeof(HttpContextAccessor));

            services.AddSession();
            services.AddDistributedMemoryCache();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "LayeredArchitectureProject API");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSession();

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
