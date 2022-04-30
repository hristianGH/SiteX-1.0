namespace SiteX.Web.Areas.Administration.Controllers
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using SiteX.Data.Models.Team;
    using SiteX.Services.Data.TeamService.Interfaces;

    public class MembersController : AdministrationController
    {
        private readonly ITeamService teamService;

        public MembersController(ITeamService teamService)
        {
            this.teamService = teamService;
        }

        // GET: MemberController
        public ActionResult Index()
        {
            return this.View(this.teamService.GetTeam());
        }

        // GET: MemberController/Details/5
        public ActionResult Details(int id)
        {
            return this.View();
        }

        // GET: MemberController/Create
        public ActionResult Create()
        {
            var member = new Member();
            return this.View(member);
        }

        // POST: MemberController/Create
        [HttpPost]
        public async Task<IActionResult> Create(Member member)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            await this.teamService.CrateMemberAsync(member);
            return this.RedirectToAction(nameof(this.Index));
        }

        // GET: MemberController/Edit/5
        public ActionResult Edit(Guid id)
        {
            Member member = this.teamService.GetMemberById(id);
            return this.View(member);
        }

        // POST: MemberController/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(Member member)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            await this.teamService.EditMemberAsync(member);
            return this.RedirectToAction(nameof(this.Index));
        }

        // GET: MemberController/Delete/5
        public ActionResult Delete(Guid id)
        {
            return this.View();
        }

        // POST: MemberController/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(Member member)
        {
            await this.teamService.DeleteMemberAsync(member);

            return this.RedirectToAction(nameof(this.Index));
        }
    }
}
