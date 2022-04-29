using Moq;
using SiteX.Data.Common.Repositories;
using SiteX.Data.Models.Team;
using SiteX.Services.Data.TeamService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace SiteX.Services.Data.Tests.Team.MemberTests
{
    public class GetTeam
    {

        [Fact]
        public async Task GetTeamShouldReturnAllMembers()
        {
            var list = new List<Member>();

            var mockProductRepo = new Mock<IDeletableEntityRepository<Member>>();

            mockProductRepo.Setup(x => x.AllAsNoTracking()).Returns(list.AsQueryable());

            mockProductRepo.Setup(x => x.AddAsync(It.IsAny<Member>())).Callback((Member x) => list.Add(x));

            var service = new TeamService.TeamService(mockProductRepo.Object);

            for (int i = 0; i < 3; i++)
            {
                var member = new Member() { FirstName = "FirstName", LastName = "LastName" };
                await service.CrateMemberAsync(member);
                var memberId = Guid.NewGuid();
                list[i].Id = memberId;
            }

            var team = service.GetTeam();

            Assert.NotEmpty(team);
            Assert.True(team.Count() == 3);

        }
    }
}