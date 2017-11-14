using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using api.Features.Shared;

namespace api
{
	public class Startup
	{
		public Startup(IHostingEnvironment env)
		{
			var builder = new ConfigurationBuilder();

			if (env.IsDevelopment())
			{
				builder.AddUserSecrets<Startup>();
			}

			Configuration = builder.Build();
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddCors(options => options.AddPolicy("cors", builder =>
			{
				builder
				.AllowAnyOrigin()
				.AllowAnyMethod()
				.AllowAnyHeader();
			}));

			services.AddMvc()
				.AddFeatureFolders();

			services.Configure<DBContext>(options =>
			{
				options.ConnectionString = Configuration["ConnectionString"];
				options.DBName = Configuration["DBName"];
			});			
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseCors("cors");			
			app.UseMvc();			
		}
	}
}
