using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Product.Application.Interface;
using Product.Application.Services;
using Product.Core.Repositories;
using Product.Core.Repositories.Base;
using Product.Infrastructure.Data;
using Product.Infrastructure.Repositories;
using Product.Infrastructure.Repositories.Base;
using System.Text;

namespace Product
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
            

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IMarketRepository, MarketRepository>();
            services.AddTransient<IPriceRepository, PriceRepository>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IMarketService, MarketService>();
            services.AddTransient<IPriceService, PriceService>();
            services.AddDbContext<ProductContext>(options =>
           options.UseSqlite(
               Configuration.GetConnectionString("DefaultConnection")
               ));


            services.AddCors(options =>
            {
                options.AddPolicy("EnableCORS", builder =>
                {
                    builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("JWT", new OpenApiSecurityScheme { Name="Authorization",In = ParameterLocation.Header, Type = SecuritySchemeType.ApiKey, Description= "Type into the textbox: Bearer {your JWT token}." });
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Product", Version = "v1" });
            });

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                
            }).AddJwtBearer(options=> 
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "https://localhost:44392",
                    ValidAudience= "https://localhost:44392",
                    IssuerSigningKey= new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"))

                };
            }); 
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Product v1"));
            }

            app.UseRouting();

            app.UseCors("EnableCORS");

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
