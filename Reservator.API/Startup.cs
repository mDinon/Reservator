using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Reservator.API.CustomFilters;
using Reservator.DAL;
using Reservator.DAL.Repositories;
using Reservator.DAL.Repositories.Interfaces;
using Reservator.Service.Services;
using Reservator.Service.Services.Interfaces;

namespace Reservator.API
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
			services.AddDbContext<ReservatorDbContext>(options =>
				options.UseSqlServer(Configuration.GetConnectionString("ReservatorConnection")));

			services.AddControllers()
				.AddNewtonsoftJson();

			services.AddMvc(config =>
			{
				config.Filters.Add(typeof(ExceptionFilter));
			});

			services.AddTransient<IUnitOfWork, UnitOfWork>();
			services.AddTransient<IObjectOwnerService, ObjectOwnerService>();

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Reservator API", Version = "v1" });
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});

			app.UseSwagger();

			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "Reservator API V1");
			});

			
		}
	}
}
