using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CocktailRealApi.Domain.Repositories;
using CocktailRealApi.Domain.Services;
using CocktailRealApi.Persistence.Contexts;
using CocktailRealApi.Persistance.Repositories;
using CocktailRealApi.Services;
using AutoMapper;
using CocktailsRealApi.Domain.Services;
using Supermarket.API.Persistence.Repositories;

namespace CocktailRealApi
{
    public class Startup
    { 
    public IConfiguration Configuration { get; }

 
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

    

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddMvc().AddJsonOptions(
                 options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
             ).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICocktailRepository, CocktailRepository>();
            services.AddScoped<IIngredientRepository, IngredientRepository>();



            services.AddScoped<ICategoryServices, CategoryService>();
            services.AddScoped<ICocktailService, CocktailService>();
            services.AddScoped<IIngredientService, IngredientService>();


            services.AddScoped<IUnitOfWork, UnitOfWork>();



            services.AddAutoMapper();

        }

     
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
