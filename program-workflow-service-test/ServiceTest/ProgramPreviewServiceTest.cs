using DataAccessLayer.Model;
using DataAccessLayer.Repository.@interface;
using Moq;
using ServiceLayer.ServiceImplementation;

namespace program_workflow_service_test.ServiceTest;

public class ProgramPreviewServiceTests
{
    [Fact]
    public async Task GetProgramPreviewAsync_ExistingProgramPreview_ReturnsProgramPreview()
    {
        // Arrange
        var programId = "123";
        var expectedProgramPreview = new ProgramPreviewModel {  };

        var programPreviewRepositoryMock = new Mock<IProgramPreviewRepo>();
        programPreviewRepositoryMock.Setup(repo => repo.GetProgramPreviewAsync(programId))
            .ReturnsAsync(expectedProgramPreview);

        var programPreviewService = new ProgramPreviewService(programPreviewRepositoryMock.Object);

        // Act
        var result = await programPreviewService.GetProgramPreviewAsync(programId);

        // Assert
        Assert.Equal(expectedProgramPreview, result);
    }

    [Fact]
    public async Task GetProgramPreviewAsync_NonExistentProgramPreview_ReturnsNull()
    {
        // Arrange
        var programId = "non-existent-program-id";

        var programPreviewRepositoryMock = new Mock<IProgramPreviewRepo>();
        programPreviewRepositoryMock.Setup(repo => repo.GetProgramPreviewAsync(programId))
            .ReturnsAsync((ProgramPreviewModel)null); // Return null of type ProgramPreviewModel

        var programPreviewService = new ProgramPreviewService(programPreviewRepositoryMock.Object);

        // Act
        var result = await programPreviewService.GetProgramPreviewAsync(programId);

        // Assert
        Assert.Null(result);
    }

}