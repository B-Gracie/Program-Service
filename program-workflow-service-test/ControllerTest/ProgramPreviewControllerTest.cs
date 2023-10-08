using DataAccessLayer.Model;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ProgramAPI.Controllers;
using ServiceLayer.ServiceInterface;

namespace program_workflow_service_test.ControllerTest;

public class ProgramPreviewControllerTests
{
    [Fact]
    public async Task GetProgramPreviewAsync_ExistingProgramPreview_ReturnsOkResult()
    {
        // Arrange
        var programName = "summer internship";
        var programPreviewServiceMock = new Mock<IProgramPreviewService>();
        var expectedProgramPreview = new ProgramPreviewModel
        {
            ProgramName = programName,
            // Initialize with other valid data
        };
        programPreviewServiceMock.Setup(service => service.GetProgramPreviewAsync(programName)).ReturnsAsync(expectedProgramPreview);
        var controller = new ProgramPreviewController(programPreviewServiceMock.Object);

        // Act
        var result = await controller.GetProgramPreviewAsync(programName);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnedProgramPreview = Assert.IsType<ProgramPreviewModel>(okResult.Value);
        Assert.Equal(programName, returnedProgramPreview.ProgramName);
        // Add more assertions for other properties as needed.
    }

    [Fact]
    public async Task GetProgramPreviewAsync_NonExistentProgramPreview_ReturnsNotFound()
    {
        // Arrange
        var programId = "1";
        var programPreviewServiceMock = new Mock<IProgramPreviewService>();
        programPreviewServiceMock.Setup(service => service.GetProgramPreviewAsync(programId)).ReturnsAsync((ProgramPreviewModel)null);
        var controller = new ProgramPreviewController(programPreviewServiceMock.Object);

        // Act
        var result = await controller.GetProgramPreviewAsync(programId);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }
}