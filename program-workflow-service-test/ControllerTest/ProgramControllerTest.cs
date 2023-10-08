
using AutoMapper;
using DataAccessLayer.DTOs;
using DataAccessLayer.Model;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ProgramAPI.Controllers;
using ServiceLayer.ServiceInterface;

namespace program_workflow_service_test.ControllerTest
{
    public class ProgramControllerTests
    {

        [Fact]
        public async Task GetProgramAsync_ExistingProgram_ReturnsOkResult()
        {
            // Arrange
            var programId = "valid-program-id";
            var programModel = new ProgramModel
            {
                Id = programId,
                // Other properties...
            };

            var mockProgramService = new Mock<IProgramService>();
            mockProgramService
                .Setup(service => service.GetProgramAsync(programId))
                .ReturnsAsync(programModel); // Return ProgramModel instead of ProgramDto

            var mockMapper = new Mock<IMapper>();
            var controller = new ProgramController(mockProgramService.Object, mockMapper.Object);

            // Act
            var result = await controller.GetProgramAsync(programId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedProgram = Assert.IsType<ProgramModel>(okResult.Value); // Change to ProgramModel
            Assert.Equal(programId, returnedProgram.Id);
            // Validate other properties...
        }


        [Fact]
        public async Task CreateProgramAsync_ValidInput_ReturnsOkResult()
        {
            // Arrange
            var programDto = new ProgramDto
            {
                // Initialize with valid data
                // ...
            };

            var mockProgramService = new Mock<IProgramService>();
            mockProgramService
                .Setup(service => service.CreateProgramAsync(It.IsAny<ProgramDto>()))
                .ReturnsAsync(programDto); // Mocking the service method to return the same programDto

            var mockMapper = new Mock<IMapper>();
            var controller = new ProgramController(mockProgramService.Object, mockMapper.Object);

            // Act
            var result = await controller.CreateProgramAsync(programDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedProgram = Assert.IsType<ProgramDto>(okResult.Value);
            // Validate the returned program and other assertions.
        }

        [Fact]
        public async Task DeleteProgramAsync_ExistingProgram_ReturnsNoContent()
        {
            // Arrange
            var programId = "valid-program-id";

            var mockProgramService = new Mock<IProgramService>();
            mockProgramService
                .Setup(service => service.DeleteProgramAsync(programId))
                .ReturnsAsync(true); // Mocking a successful deletion

            var mockMapper = new Mock<IMapper>();
            var controller = new ProgramController(mockProgramService.Object, mockMapper.Object);

            // Act
            var result = await controller.DeleteProgramAsync(programId);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DeleteProgramAsync_NonExistentProgram_ReturnsNotFound()
        {
            // Arrange
            var programId = "non-existent-program-id";

            var mockProgramService = new Mock<IProgramService>();
            mockProgramService
                .Setup(service => service.DeleteProgramAsync(programId))
                .ReturnsAsync(false); // Mocking an unsuccessful deletion
        }
    }
}

           
