namespace SiteX.Services.Data.Tests.Team.MemberTests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Moq;
    using SiteX.Data.Common.Repositories;
    using SiteX.Data.Models.Team;
    using Xunit;

    public class DeleteMember
    {
        [Fact]
        public async Task DeleteMemberShoulRemoveMemberFromRepository()
        {
            var list = new List<Member>();

            var mockProductRepo = new Mock<IDeletableEntityRepository<Member>>();

            mockProductRepo.Setup(x => x.AllAsNoTracking()).Returns(list.AsQueryable());

            mockProductRepo.Setup(x => x.AddAsync(It.IsAny<Member>())).Callback((Member x) => list.Add(x));
            mockProductRepo.Setup(x => x.Delete(It.IsAny<Member>())).Callback((Member x) => list.Remove(x));

            var service = new TeamService.TeamService(mockProductRepo.Object);

            var member = new Member() { FirstName = "FirstName", LastName = "LastName" };

            await service.CrateMemberAsync(member);
            Assert.True(list.Any());

            await service.DeleteMemberAsync(member);
            Assert.False(list.Any());
        }
    }
}
