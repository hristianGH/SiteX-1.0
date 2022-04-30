using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

using SiteX.Data;
using SiteX.Data.Common;
using SiteX.Data.Common.Repositories;
using SiteX.Data.Models;
using SiteX.Data.Repositories;
using SiteX.Data.Seeding;
using SiteX.Services.Data.ArticleService;
using SiteX.Services.Data.ArticleService.Interface;
using SiteX.Services.Data.BlogService;
using SiteX.Services.Data.BlogService.Interface;
using SiteX.Services.Data.ShopService;
using SiteX.Services.Data.ShopService.Interface;
using SiteX.Services.Data.TeamService;
using SiteX.Services.Data.TeamService.Interfaces;
using SiteX.WebAPI.Settings;
using System.Text;

namespace SiteX.WebAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(
               options => options.UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection")));

            //services.AddIdentityCore<ApplicationUser, IdentityRole>(IdentityOptionsProvider.GetIdentityOptions)
            // .AddEntityFrameworkStores<ApplicationDbContext>()
            // .AddDefaultTokenProviders();

            services.AddIdentityCore<ApplicationUser>(IdentityOptionsProvider.GetIdentityOptions)
                .AddRoles<ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders(); ;


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SiteX.WebAPI", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Type = SecuritySchemeType.ApiKey,
                    Name = "Authorization",
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n" +
                    " Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                     {
                       new OpenApiSecurityScheme {
                         Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                }
                       },
                    new string[] {}
                   }
                     });
            });

            services.AddControllers();

            var jwtSettingsSection = Configuration.GetSection("JwtSettings");
            services.Configure<JwtSettings>(jwtSettingsSection);

            var jwtSettings = jwtSettingsSection.Get<JwtSettings>();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })

            // Adding Jwt Bearer  
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.Secret)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
            });


            // Data repositories
            services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<IDbQueryRunner, DbQueryRunner>();

            // Application services
            //services.AddTransient<IEmailSender, NullMessageSender>();
            //services.AddTransient<ISettingsService, SettingsService>();

            // ShopServices
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IGenderService, GenderService>();
            services.AddTransient<ILocationService, LocationService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ISizeService, SizeService>();
            services.AddTransient<IColorService, ColorService>();
            services.AddTransient<IProductCategoryService, ProductCategoryService>();
            services.AddTransient<IProductColorService, ProductColorService>();
            services.AddTransient<IProductImageService, ProductImageService>();
            services.AddTransient<IProductLocationService, ProductLocationService>();
            services.AddTransient<IProductSizeService, ProductSizeService>();
            services.AddTransient<IProductListService, ProductListService>();
            services.AddTransient<IReceitService, ReceitService>();


            // BlogServices
            services.AddTransient<IGenreService, GenreService>();
            services.AddTransient<IPostGenreService, PostGenreSevice>();
            services.AddTransient<IPostService, PostService>();
            services.AddTransient<IPostImageService, PostImageService>();
            services.AddTransient<IPostListService, PostListService>();
            services.AddTransient<ICommentService, CommentService>();


            // TeamServices
            services.AddTransient<ITeamService, TeamService>();

            // Article 
            services.AddTransient<IArticleService, ArticleService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                dbContext.Database.Migrate();
                new ApplicationDbContextSeeder(userManager).SeedAsync(dbContext, serviceScope.ServiceProvider).GetAwaiter().GetResult();
            }
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SiteX.WebAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
