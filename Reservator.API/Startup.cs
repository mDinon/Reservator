using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Reservator.API.CustomFilters;
using Reservator.DAL;
using Reservator.DAL.Repositories;
using Reservator.DAL.Repositories.Interfaces;
using Reservator.Service;
using Reservator.Service.Services;
using Reservator.Service.Services.Interfaces;
using System.Text;

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

			services.AddCors();
			services.AddControllers(config =>
			{
				config.Filters.Add(typeof(ExceptionFilter));
			}).AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
			//services.AddMvc(config =>
			//{
			//	config.Filters.Add(typeof(ExceptionFilter));
			//});

			services.Configure<JwtSettings>(Configuration.GetSection("JwtSettings"));

			JwtSettings jwtSettings = Configuration.GetSection("JwtSettings").Get<JwtSettings>();
			byte[] key = Encoding.ASCII.GetBytes(jwtSettings.Secret);
			services.AddAuthentication(x =>
			{
				x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
			.AddJwtBearer(x =>
			{
				x.RequireHttpsMetadata = false;
				x.SaveToken = true;
				x.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(key),
					ValidateIssuer = false,
					ValidateAudience = false,
					ValidateLifetime = true,
					RequireExpirationTime = true,
					RequireSignedTokens = true,
				};
			});


			services.AddTransient<IUnitOfWork, UnitOfWork>();
			services.AddTransient<IObjectOwnerService, ObjectOwnerService>();
			services.AddTransient<IReservationService, ReservationService>();
			services.AddTransient<IReservationObjectService, ReservationObjectService>();
			services.AddScoped<IUserService, UserService>();


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

			app.UseStaticFiles();

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();
			app.UseCors(x => x
				.AllowAnyOrigin()
				.AllowAnyMethod()
				.AllowAnyHeader());

			//app.UseMvc();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});

			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "Reservator API V1");
				//c.RoutePrefix = string.Empty;
				c.DefaultModelsExpandDepth(-1);
			});

			app.Run(async context =>
			{
				context.Response.Redirect("/swagger/");
			});
		}
	}
}
