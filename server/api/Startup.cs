using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IO;

using Swashbuckle.AspNetCore.Swagger;

using api.Features.Shared;
using api.Features.Shared.User;
using api.Features.Shared.Hash;
using api.Features.Shared.Task;
using api.Features.Shared.Token;
using api.Features.Auth.Service;
using api.Features.Task.Service;
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
			services
				.AddCors(options => options.AddPolicy("cors", builder =>
				{
					builder
					.AllowAnyOrigin()
					.AllowAnyMethod()
					.AllowAnyHeader();
				}));

			services
				.Configure<DBContext>(options =>
				{
					options.ConnectionString = Configuration["ConnectionString"];
					options.DBName = Configuration["DBName"];
				})
				.Configure<TokenSettings>(options =>
				{
					options.TokenSecret = Configuration["TokenSecret"];
				});

			var tokenSettings = services
				.BuildServiceProvider()
				.GetService<IOptions<TokenSettings>>()
				.Value;

			services
				.AddAuthentication(options =>
				{
					options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
				})
				.AddJwtBearer(options =>
				{
					options.TokenValidationParameters = new TokenValidationParameters()
					{
						IssuerSigningKey = tokenSettings.IssuerSigningKey,
						ValidateIssuerSigningKey = true,

						ValidAudience = tokenSettings.Audience,
						ValidateAudience = true,

						ValidIssuer = tokenSettings.Issuer,
						ValidateIssuer = true,

						ClockSkew = TimeSpan.FromMinutes(0),
						ValidateLifetime = true
					};
				});

			services
				.AddMvc()
				.AddFeatureFolders();

			services.AddSwaggerGen(options =>
			{
				options.SwaggerDoc("v1", new Info
				{
					Version = "v1",
					Title = "TDAMSH API",
					Description = "Some description",
				});

				options.AddSecurityDefinition("Bearer", new ApiKeyScheme()
				{
					Description = "JWT Authorization header using the Bearer scheme. E.G.: Bearer {token}",
					Name = "Authorization",
					In = "header",
					Type = "apiKey"
				});

				var xmlPath = Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "api.xml");
				options.IncludeXmlComments(xmlPath);
			});

			services
				.AddTransient<IUserRepository, UserRepository>()
				.AddTransient<IHashService, HashService>()
				.AddTransient<ITokenService, TokenService>()
				.AddTransient<IAuthService, AuthService>()
				.AddTransient<IAccountService, AccountService>()
				.AddTransient<ITaskRepository, TaskRepository>()
				.AddTransient<ITaskService, TaskService>();
		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app
				.UseSwagger()
				.UseSwaggerUI(options =>
				{
					options.SwaggerEndpoint("/swagger/v1/swagger.json", "TDAMSH API");
				});

			app.UseCors("cors");
			app.UseAuthentication();
			app.UseMvc();
		}
	}
}
