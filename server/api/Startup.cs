using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using api.Features.Shared;
using api.Features.Shared.User;
using api.Features.Shared.Hash;
using api.Features.Auth.Service;
using api.Features.Account.Service;

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

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddCors(options => options.AddPolicy("cors", builder =>
			{
				builder
				.AllowAnyOrigin()
				.AllowAnyMethod()
				.AllowAnyHeader();
			}));

			services.Configure<DBContext>(options =>
			{
				options.ConnectionString = Configuration["ConnectionString"];
				options.DBName = Configuration["DBName"];
			});

			services.AddMvc()
				.AddFeatureFolders();

			services.AddTransient<IUserRepository, UserRepository>();
			services.AddTransient<IHashService, HashService>();
			services.AddTransient<IAuthService, AuthService>();
			services.AddTransient<IAccountService, AccountService>();
		}

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
