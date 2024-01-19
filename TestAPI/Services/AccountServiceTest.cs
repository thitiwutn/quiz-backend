using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using quiz_api.Entities;
using quiz_api.Services;
using quiz_api.Services.Models.Request;

namespace TestAPI.Services;

[TestClass]
[TestSubject(typeof(AccountService))]
public class AccountServiceTest
{
    [TestMethod]
    public void CreateUser()
    {
        // Arrange
        var userData = new CreateUser()
        {
            GroupId = 2,
            Name = "Test User 3"
        };

        IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();
        // Act
        using var context = new DatabaseContext(configuration);
        var service = new AccountService(context);
        var result = service.CreateUser(userData);

        // Assert
        Assert.IsNotNull(result.Result);
        Assert.AreNotEqual(0, result.Result.Id);
    }
    
    [TestMethod]
    public void GetUser()
    {
        // Arrange
        var userName = "Test User 3";

        IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();
        // Act
        using var context = new DatabaseContext(configuration);
        var service = new AccountService(context);
        var result = service.GetUser(userName);

        // Assert
        Assert.IsNotNull(result.Result);
        Assert.AreNotEqual(0, result.Result.Id);
    }
}