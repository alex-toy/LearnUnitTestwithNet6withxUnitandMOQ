using System.Linq;
using TestingApp.Functionality;
using TestingApp.Models;
using Xunit;

namespace TestingApp.Test
{   
    public class UserManagementTest
    {
        [Fact]
        public void Add_create_user()
        {
            var userManagement = new UserManagement();
            userManagement.Add(new User("alex", "BG") { });
            var savedUser = Assert.Single(userManagement.AllUsers);
            Assert.NotNull(savedUser);
            Assert.Equal("alex", savedUser.firstName);
            Assert.Equal("BG", savedUser.lastName);
            Assert.False(savedUser.VerifiedEmail);
        }

        [Fact]
        public void Update_mobile_number()
        {
            var userManagement = new UserManagement();
            userManagement.Add(new User("alex", "BG") { });
            var firstUser = userManagement.AllUsers.First();
            firstUser.Phone = "+03387654";

            userManagement.UpdatePhone(firstUser);

            var savedUser = Assert.Single(userManagement.AllUsers);
            Assert.NotNull(savedUser);
            Assert.Equal("+03387654", savedUser.Phone);
        }
    }
}