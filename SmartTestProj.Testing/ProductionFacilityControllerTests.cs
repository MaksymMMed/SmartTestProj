using Microsoft.AspNetCore.Mvc;
using Moq;
using SmartTestProj.API.Controllers;
using SmartTestProj.BLL.Dto.ProductionFacility;
using SmartTestProj.BLL.Services.Interfaces;
using AutoFixture;
using FluentAssertions;

namespace SmartTestProj.Tests.Controllers
{
    public class ProductionFacilityControllerTests
    {
        private readonly Mock<IProductionFacilityService> _mockService;
        private readonly ProductionFacilityController _controller;
        private readonly IFixture _fixture;

        public ProductionFacilityControllerTests()
        {
            _mockService = new Mock<IProductionFacilityService>();
            _controller = new ProductionFacilityController(_mockService.Object);
            _fixture = new Fixture();
        }

        [Fact]
        public async Task GetAll_ReturnsOkResult_WithCorrectData()
        {
            var facilities = _fixture.CreateMany<GetProductionFacilityDto>(5).ToList();
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
            var facilities = _fixture.CreateMany<GetProductionFacilityDto>(5).ToList();
            _mockService.Setup(service => service.GetAll())
                        .ThrowsAsync(new Exception("Somenthing went wrong"));

            var result = await _controller.GetAll();

            result.Should().BeOfType<ObjectResult>();
            var statusCodeResult = result as ObjectResult;
            statusCodeResult.StatusCode.Should().Be(500);
        }

        [Fact]
        public async Task Create_ReturnsOkResult_WithCreatedFacility()
        {
            var dto = _fixture.Create<CreateProductionFacilityDto>();
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
            var dto = _fixture.Create<CreateProductionFacilityDto>();
            _mockService.Setup(service => service.Insert(dto))
                        .ThrowsAsync(new Exception("Something went wrong"));

            var result = await _controller.Create(dto);

            result.Should().BeOfType<ObjectResult>();
            var statusCodeResult = result as ObjectResult;
            statusCodeResult.StatusCode.Should().Be(500);
        }

        [Fact]
        public async Task Update_ReturnsOkResult_WithUpdatedFacility()
        {
            var dto = _fixture.Create<UpdateProductionFacilityDto>();
            var updatedFacility = _fixture.Create<GetProductionFacilityDto>();

            _mockService.Setup(service => service.Update(dto))
                        .ReturnsAsync("Updated succesful");

            var result = await _controller.Update(dto);

            result.Should().BeOfType<OkObjectResult>();
            var okResult = result as OkObjectResult;
            okResult.Value.Should().BeEquivalentTo("Updated succesful");
        }

        [Fact]
        public async Task Update_ReturnsInternalServerError_WhenExceptionOccurs()
        {
            var dto = _fixture.Create<UpdateProductionFacilityDto>();
            _mockService.Setup(service => service.Update(dto))
                        .ThrowsAsync(new Exception("Something went wrong"));

            var result = await _controller.Update(dto);

            result.Should().BeOfType<ObjectResult>();
            var statusCodeResult = result as ObjectResult;
            statusCodeResult.StatusCode.Should().Be(500);
        }

        [Fact]
        public async Task Delete_ReturnsOkResult_WhenSuccess()
        {
            var id = Guid.NewGuid();
            _mockService.Setup(service => service.Delete(id))
                        .ReturnsAsync("Deleted successful");

            var result = await _controller.Delete(id);

            result.Should().BeOfType<OkObjectResult>();
            var okResult = result as OkObjectResult;
            okResult.Value.Should().BeEquivalentTo("Deleted successful");
        }

        [Fact]
        public async Task Delete_ReturnsInternalServerError_WhenExceptionOccurs()
        {
            var id = Guid.NewGuid();
            _mockService.Setup(service => service.Delete(id))
                        .ThrowsAsync(new Exception("Something went wrong"));

            var result = await _controller.Delete(id);

            result.Should().BeOfType<ObjectResult>();
            var statusCodeResult = result as ObjectResult;
            statusCodeResult.StatusCode.Should().Be(500);
        }

        [Fact]
        public async Task Delete_ReturnsNotFound_WhenNoRecordIsDeleted()
        {
            var id = Guid.NewGuid();
            _mockService.Setup(service => service.Delete(id))
                        .ThrowsAsync(new KeyNotFoundException("Item not found"));

            var result = await _controller.Delete(id);

            result.Should().BeOfType<ObjectResult>();
            var statusCodeResult = result as ObjectResult;
            statusCodeResult.StatusCode.Should().Be(404);
        }
    }
}
