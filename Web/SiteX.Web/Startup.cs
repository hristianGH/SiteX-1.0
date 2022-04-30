namespace SiteX.Web
{
    using System.Reflection;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using SiteX.Data;
    using SiteX.Data.Common;
    using SiteX.Data.Common.Repositories;
    using SiteX.Data.Models;
    using SiteX.Data.Models.Shop;
    using SiteX.Data.Repositories;
    using SiteX.Data.Seeding;
    using SiteX.Services.Data;
    using SiteX.Services.Data.ArticleService;
    using SiteX.Services.Data.ArticleService.Interface;
    using SiteX.Services.Data.BlogService;
    using SiteX.Services.Data.BlogService.Interface;
    using SiteX.Services.Data.ShopService;
    using SiteX.Services.Data.ShopService.Interface;
    using SiteX.Services.Data.TeamService;
    using SiteX.Services.Data.TeamService.Interfaces;
    using SiteX.Services.Mapping;
    using SiteX.Services.Messaging;
    using SiteX.Web.ViewModels;

    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(this.configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<ApplicationUser>(IdentityOptionsProvider.GetIdentityOptions)
                .AddRoles<ApplicationRole>().AddEntityFrameworkStores<ApplicationDbContext>();

            services.Configure<CookiePolicyOptions>(
                options =>
                    {
                        options.CheckConsentNeeded = context => true;
                        options.MinimumSameSitePolicy = SameSiteMode.None;
                    });

            services.AddControllersWithViews(
                options =>
                    {
                        options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
                    }).AddRazorRuntimeCompilation();
            services.AddRazorPages();
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddSingleton(this.configuration);

            // Data repositories
            services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<IDbQueryRunner, DbQueryRunner>();

            // Application services
            services.AddTransient<IEmailSender, NullMessageSender>();
            services.AddTransient<ISettingsService, SettingsService>();

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

            // Team
            services.AddTransient<ITeamService, TeamService>();

            // Article
            services.AddTransient<IArticleService, ArticleService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly, typeof(Product).GetTypeInfo().Assembly);

            // Seed data on application startup
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
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(
                endpoints =>
                    {
                        endpoints.MapControllerRoute("areaRoute", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                        endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                        endpoints.MapRazorPages();
                    });
        }
    }
}
