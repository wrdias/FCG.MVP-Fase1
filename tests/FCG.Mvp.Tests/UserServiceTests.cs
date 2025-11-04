using FCG.Mvp.API.Data;
using FCG.Mvp.API.Services;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCG.Mvp.Tests
{
    public class UserServiceTests
    {
        private UserService CreateService(out AppDbContext db)
        {
            var opts = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase("testdb")
                .Options;
            db = new AppDbContext(opts);
            var inMemoryConfig = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string> { { "Jwt:Key", "TestKey123" } })
                .Build();
            return new UserService(db, inMemoryConfig);
        }

        [Fact]
        public async Task Register_Should_Create_User()
        {
            var svc = CreateService(out var db);
            var result = await svc.RegisterAsync(new API.DTOs.RegisterRequest("Name", "email@example.com", "P@ssw0rd!"));
            result.Email.Should().Be("email@example.com");
            db.Users.Should().HaveCount(1);
        }
    }
}
