namespace SiteX.Services.Data.TeamService
{
    using SiteX.Data.Common.Repositories;
    using SiteX.Data.Models.Team;
    using SiteX.Services.Data.TeamService.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class TeamService : ITeamService
    {
        private readonly IDeletableEntityRepository<Member> memberRepo;

        public TeamService(IDeletableEntityRepository<Member> memberRepo)
        {
            this.memberRepo = memberRepo;
        }

        public async Task CrateMemberAsync(Member member)
        {
            await this.memberRepo.AddAsync(member);
            await this.memberRepo.SaveChangesAsync();
        }

        public async Task DeleteMemberAsync(Member member)
        {
            this.memberRepo.Delete(member);
            await this.memberRepo.SaveChangesAsync();
        }

        public async Task EditMemberAsync(Member member)
        {
            var edit = this.memberRepo.All().FirstOrDefault(x => x.Id == member.Id);
            edit.FirstName = member.FirstName;
            edit.LastName = member.LastName;
            edit.Picture = member.Picture;
            edit.Description = member.Description;

            await this.memberRepo.SaveChangesAsync();
        }

        public Member GetMemberById(Guid id)
        {
            var member = this.memberRepo.AllAsNoTracking().FirstOrDefault(x => x.Id == id);
            return member;
        }

        public IEnumerable<Member> GetTeam()
        {
            var members = this.memberRepo.AllAsNoTracking().ToList();
            return members;
        }
    }
}
