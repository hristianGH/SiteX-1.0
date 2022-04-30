namespace SiteX.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SiteX.Services.Data.TeamService.Interfaces;

    public class MembersController : Controller
    {
        private readonly ITeamService teamService;

        public MembersController(ITeamService teamService)
        {
            this.teamService = teamService;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Team()
        {
            var members = this.teamService.GetTeam();

            return this.View(members);
        }
    }
}
