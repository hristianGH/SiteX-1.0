namespace SiteX.Web.Controllers
{
    using System.Diagnostics;

    using Microsoft.AspNetCore.Mvc;
    using SiteX.Services.Data.ShopService.Interface;
    using SiteX.Services.Data.TeamService.Interfaces;
    using SiteX.Web.ViewModels;

    public class HomeController : BaseController
    {
        private readonly ITeamService teamService;

        public HomeController(ITeamService teamService)
        {
            this.teamService = teamService;
        }

        // TODO Make List of 5 articles to show on Home page
        public IActionResult Index()
        {

            return this.View();
        }

        public IActionResult About()
        {
            return this.View();
        }

      

        public IActionResult Locations()
        {
            return this.View();
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
