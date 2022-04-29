using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiteX.Data.Models.Team;
using SiteX.Services.Data.TeamService.Interfaces;
using System;
using System.Threading.Tasks;

namespace SiteX.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MemberController : ControllerBase
    {
        private readonly ITeamService teamService;

        public MemberController(ITeamService teamService)
        {
            this.teamService = teamService;
        }

        // GET: MemberController
        [Route("All")]
        [HttpGet]
        public ActionResult Index()
        {
            return this.Ok(this.teamService.GetTeam());
        }

        // POST: MemberController/Create
        [HttpPost("Create")]
        public async Task<IActionResult> Create(Member member)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            await this.teamService.CrateMemberAsync(member);
            return this.Ok(member);
        }

         

        // POST: MemberController/Edit/5
        [HttpPut("Edit")]
        public async Task<IActionResult> Edit(Member member)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            await this.teamService.EditMemberAsync(member);
            return this.Ok(member);
        }

        // POST: MemberController/Delete/5
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(Member member)
        {
            await this.teamService.DeleteMemberAsync(member);

            return this.Ok(member);
        }

    }
}
