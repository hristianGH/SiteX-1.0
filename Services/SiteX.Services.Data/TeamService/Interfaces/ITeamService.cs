namespace SiteX.Services.Data.TeamService.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using SiteX.Data.Models.Team;

    public interface ITeamService
    {
        public IEnumerable<Member> GetTeam();

        public Task CrateMemberAsync(Member member);

        public Task EditMemberAsync(Member member);

        public Task DeleteMemberAsync(Member member);

        public Member GetMemberById(Guid id);
    }
}
