using Moq;
using SiteX.Data.Common.Repositories;
using SiteX.Data.Models.Team;
using SiteX.Services.Data.TeamService;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace SiteX.Services.Data.Tests.Team.MemberTests
{
    public class CreateMember
    {
        [Fact]
        public async Task CreateMemberShouldAddMemberToRepository()
        {
            var list = new List<Member>();

            var mockProductRepo = new Mock<IDeletableEntityRepository<Member>>();

            mockProductRepo.Setup(x => x.AllAsNoTracking()).Returns(list.AsQueryable());

            mockProductRepo.Setup(x => x.AddAsync(It.IsAny<Member>())).Callback((Member x) => list.Add(x));

            var service = new TeamService.TeamService(mockProductRepo.Object);

            var member = new Member() { FirstName = "FirstName", LastName = "LastName" };

            await service.CrateMemberAsync(member);

            Assert.NotNull(list);
            Assert.True(list.First().FirstName == "FirstName");
            Assert.True(list.First().LastName == "LastName");

        }
    }
}
