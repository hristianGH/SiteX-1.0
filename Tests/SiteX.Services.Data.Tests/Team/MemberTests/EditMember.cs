namespace SiteX.Services.Data.Tests.Team.MemberTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Moq;
    using SiteX.Data.Common.Repositories;
    using SiteX.Data.Models.Team;
    using Xunit;

    public class EditMember
    {
        [Fact]
        public async Task EditMemberShouldEditMemberData()
        {
            var list = new List<Member>();

            var mockProductRepo = new Mock<IDeletableEntityRepository<Member>>();

            mockProductRepo.Setup(x => x.All()).Returns(list.AsQueryable());

            mockProductRepo.Setup(x => x.AddAsync(It.IsAny<Member>())).Callback((Member x) => list.Add(x));

            var service = new TeamService.TeamService(mockProductRepo.Object);

            var member = new Member() { FirstName = "FirstName", LastName = "LastName" };
            var memberId = Guid.NewGuid();
            await service.CrateMemberAsync(member);
            list.First().Id = memberId;

            var edit = new Member() { FirstName = "Edit", LastName = "Edit", Id = memberId };
            await service.EditMemberAsync(edit);

            Assert.True(list.First().FirstName == "Edit");
            Assert.True(list.First().LastName == "Edit");
        }
    }
}
