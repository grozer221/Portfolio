using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Authorization.AspNetCore;
using GraphQL.Validation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Portfolio.GraphQL;
using Portfolio.Repositories;
using Portfolio.Services;
using System.Security.Claims;
using System.Text;

namespace Portfolio
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
            services.AddDbContext<AppDatabaseContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SqlServer")));
            services.AddTransient<UsersRepository>();
            services.AddTransient<RolesRepository>();
            services.AddTransient<TechnologiesRepository>();
            services.AddTransient<ProjectsRepository>();
            services.AddTransient<CommentsRepository>();
            services.AddTransient<LikesRepository>();

            services.AddTransient<IdentityService>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateIssuerSigningKey = true,
                    ValidAudience = "audience",
                    ValidIssuer = "issuer",
                    RequireSignedTokens = false,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetSection("SecretKey").Value))
                };
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
            })
            .AddCookie(options =>
            {
                options.LoginPath = new PathString("/admin/account/login");
            });

            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<PortfolioSchema>();
            services
                .AddGraphQL()
                .AddGraphTypes(ServiceLifetime.Transient)
                .AddSystemTextJson()
                .AddWebSockets()
                .AddDataLoader()
                .AddGraphTypes(typeof(PortfolioSchema))
                .AddGraphQLAuthorization(options =>
                {
                    options.AddPolicy("Authenticated", p => p.RequireAuthenticatedUser());
                    //options.AddPolicy("Admin", p => p.RequireClaim(ClaimTypes.Role, "admin"));
                    //options.AddPolicy("User", p => p.RequireClaim(ClaimTypes.Role, "user"));
                })
                .AddErrorInfoProvider(opt => opt.ExposeExceptionStackTrace = true);



            services.AddControllersWithViews();

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //app.UseExceptionHandler("/Home/Error");
                app.UseStatusCodePagesWithRedirects("/admin/error/{0}");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL<PortfolioSchema>();
                endpoints.MapGraphQLPlayground();

                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
