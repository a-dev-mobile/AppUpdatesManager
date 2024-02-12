// using Moq;
// using Xunit;
// using AppUpdatesManager.Domain.Interfaces;
// using System.Threading.Tasks;
// using AppUpdatesManager.Application.Services.Implementations;

// namespace AppUpdatesManager.Tests.UnitTests.Domain.Services;

// public class AppUpdateServiceTests
// {











    
//     [Fact]
//     public async Task IsPackageExists_ShouldReturnTrue_IfExists()
//     {
//         // Arrange
//         var mockRepository = new Mock<IAppUpdateRepository>();
//         mockRepository.Setup(repo => repo.IsPackageExists("com.example.app"))
//             .ReturnsAsync(true);

//         var service = new AppUpdateService(mockRepository.Object);

//         // Act
//         var result = await service.IsPackageExistsAsync("com.example.app");

//         // Assert
//         Assert.True(result);
//     }

//     [Fact]
//     public async Task IsPackageExists_ShouldReturnFalse_IfNotExists()
//     {
//         // Arrange
//         var mockRepository = new Mock<IAppUpdateRepository>();
//         mockRepository.Setup(repo => repo.IsPackageExists("com.unknown.app"))
//             .ReturnsAsync(false);

//         var service = new AppUpdateService(mockRepository.Object);

//         // Act
//         var result = await service.IsPackageExistsAsync("com.unknown.app");

//         // Assert
//         Assert.False(result);
//     }
// }
