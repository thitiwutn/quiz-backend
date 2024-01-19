using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using quiz_api.Entities;
using quiz_api.Services;
using quiz_api.Services.Models.Request;

namespace TestAPI.Services;

[TestClass]
[TestSubject(typeof(GroupService))]
public class GroupServiceTest
{
    [TestMethod]
    public void GetGroup()
    {
        // Arrange
        IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();
        // Act
        using var context = new DatabaseContext(configuration);
        var service = new GroupService(context);
        var result = service.GetGroups();

        // Assert
        Assert.IsNotNull(result.Result);
        Assert.AreNotEqual(0, result.Result.Count);
    }
}