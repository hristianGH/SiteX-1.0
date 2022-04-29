using Microsoft.AspNetCore.Mvc;
using SiteX.Services.Data.TeamService.Interfaces;

namespace SiteX.Web.Controllers
{
    public class MembersController : Controller
    {

        private readonly ITeamService teamService;

        public MembersController(ITeamService teamService)
        {
            this.teamService = teamService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Team()
        {
            var members = this.teamService.GetTeam();

            return this.View(members);
        }
    }
}
