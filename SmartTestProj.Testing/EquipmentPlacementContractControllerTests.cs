using Microsoft.AspNetCore.Mvc;
using Moq;
using SmartTestProj.API.Controllers;
using SmartTestProj.BLL.Dto.EquipmentPlacementContract;
using SmartTestProj.BLL.Services.Interfaces;
using AutoFixture;
using FluentAssertions;
using SmartTestProj.BLL.BackgroundServices;
using Microsoft.Extensions.Logging;
using SmartTestProj.BLL.BackgroundService;

namespace SmartTestProj.Tests.Controllers
{
    public class EquipmentPlacementContractControllerTests
    {
        private readonly Mock<IEquipmentPlacementContractService> _mockService;
        private readonly Mock<ILogger<LoggingService>> _loggerMock;
        private readonly LoggingService _loggingService;
        private readonly Mock<IBackgroundJobService> _jobServiceMock;
        private readonly EquipmentPlacementContractController _controller;
        private readonly IFixture _fixture;

        public EquipmentPlacementContractControllerTests()
        {
            _mockService = new Mock<IEquipmentPlacementContractService>();
            _loggerMock = new Mock<ILogger<LoggingService>>();
            _loggingService = new LoggingService(_loggerMock.Object);
            _jobServiceMock = new Mock<IBackgroundJobService>();
            _controller = new EquipmentPlacementContractController(_mockService.Object,_loggingService,_jobServiceMock.Object);
            _fixture = new Fixture();
        }

        [Fact]
        public async Task GetAll_ReturnsOkResult_WithCorrectData()
        {
            var facilities = _fixture.CreateMany<GetEquipmentPlacementContractDto>(5).ToList();
            _mockService.Setup(service => service.GetAll())
                        .ReturnsAsync(facilities);

            var result = await _controller.GetAll();

            result.Should().BeOfType<OkObjectResult>();
            var okResult = result as OkObjectResult;
            okResult.Value.Should().BeEquivalentTo(facilities);
        }

        [Fact]
        public async Task GetAll_ReturnsInternalServerError_WhenExceptionOccurs()
        {
            var facilities = _fixture.CreateMany<GetEquipmentPlacementContractDto>(5).ToList();
            _mockService.Setup(service => service.GetAll())
                        .ThrowsAsync(new Exception("Somenthing went wrong"));

            var result = await _controller.GetAll();

            result.Should().BeOfType<ObjectResult>();
            var statusCodeResult = result as ObjectResult;
            statusCodeResult.StatusCode.Should().Be(500);
        }

        [Fact]
        public async Task Create_ReturnsOkResult_WithCreated()
        {
            var dto = _fixture.Create<CreateEquipmentPlacementContractDto>();
            _mockService.Setup(service => service.Insert(dto))
                        .ReturnsAsync("Created successful");


            var result = await _controller.Create(dto);

            result.Should().BeOfType<OkObjectResult>();
            var okResult = result as OkObjectResult;
            okResult.Value.Should().BeEquivalentTo("Created successful");
        }

        [Fact]
        public async Task Create_ReturnsInternalServerError_WhenExceptionOccurs()
        {
            var dto = _fixture.Create<CreateEquipmentPlacementContractDto>();
            _mockService.Setup(service => service.Insert(dto))
                        .ThrowsAsync(new Exception("Something went wrong"));

            var result = await _controller.Create(dto);

            result.Should().BeOfType<ObjectResult>();
            var statusCodeResult = result as ObjectResult;
            statusCodeResult.StatusCode.Should().Be(500);
        }

        [Fact]
        public async Task Delete_ReturnsOkResult_WhenSuccess()
        {
            var equipmentId = Guid.NewGuid();
            var facilityId = Guid.NewGuid();
            _mockService.Setup(service => service.Delete(equipmentId,facilityId))
                        .ReturnsAsync("Deleted successful");

            var result = await _controller.Delete(equipmentId,facilityId);

            result.Should().BeOfType<OkObjectResult>();
            var okResult = result as OkObjectResult;
            okResult.Value.Should().BeEquivalentTo("Deleted successful");
        }

        [Fact]
        public async Task Delete_ReturnsInternalServerError_WhenExceptionOccurs()
        {
            var equipmentId = Guid.NewGuid();
            var facilityId = Guid.NewGuid();
            _mockService.Setup(service => service.Delete(equipmentId, facilityId))
                        .ThrowsAsync(new Exception("Something went wrong"));

            var result = await _controller.Delete(equipmentId, facilityId);

            result.Should().BeOfType<ObjectResult>();
            var statusCodeResult = result as ObjectResult;
            statusCodeResult.StatusCode.Should().Be(500);
        }
        // замокати hangfire, щоб тест на створення нормально працював
        [Fact]
        public async Task Delete_ReturnsNotFound_WhenNoRecordIsDeleted()
        {
            var equipmentId = Guid.NewGuid();
            var facilityId = Guid.NewGuid();
            _mockService.Setup(service => service.Delete(equipmentId, facilityId))
                        .ThrowsAsync(new KeyNotFoundException("Item not found"));

            var result = await _controller.Delete(equipmentId, facilityId);

            result.Should().BeOfType<ObjectResult>();
            var statusCodeResult = result as ObjectResult;
            statusCodeResult.StatusCode.Should().Be(404);
        }
    }
}
