using Application.ViewModels;
using AutoMapper;
using Domain.Entities;
using Infra.Context;
using Infra.Interfaces;
using Infra.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Services.Dto;
using Services.Interfaces;
using Services.Services;

namespace Application
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
            services.AddControllers();

            var autoMapperConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<User, UserDto>().ReverseMap();
                config.CreateMap<UserRepository, UserDto>().ReverseMap();
                config.CreateMap<CreateUserViewModel, UserDto>().ReverseMap();
                config.CreateMap<UpdateUserViewModel, UserDto>().ReverseMap();
            });
            services.AddSingleton(autoMapperConfig.CreateMapper());

            services.AddSingleton(d => Configuration);
            services.AddDbContext<DataContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]), ServiceLifetime.Transient);

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
