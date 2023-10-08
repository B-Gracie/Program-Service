using DataAccessLayer.Model;
using DataAccessLayer.Repository.@interface;
using Moq;
using ServiceLayer.ServiceImplementation;

namespace program_workflow_service_test.ServiceTest;

public class WorkFlowServiceTests
{
    [Fact]
    public async Task GetWorkFlowAsync_ExistingWorkFlow_ReturnsWorkFlow()
    {
        // Arrange
        var workFlowId = "2";
        var expectedWorkFlow = new WorkFlowModel
        {
            /* Initialize with valid data */
        };

        var workFlowRepositoryMock = new Mock<IWorkFlowRepository>();
        workFlowRepositoryMock.Setup(repo => repo.GetWorkFlowAsync(workFlowId))
            .ReturnsAsync(expectedWorkFlow);

        var workFlowService = new WorkFlowService(workFlowRepositoryMock.Object);

        // Act
        var result = await workFlowService.GetWorkFlowAsync(workFlowId);

        // Assert
        Assert.Equal(expectedWorkFlow, result);
    }

    [Fact]
    public async Task GetWorkFlowAsync_NonExistentWorkFlow_ReturnsNull()
    {
        // Arrange
        var workFlowId = "1";

        var workFlowRepositoryMock = new Mock<IWorkFlowRepository>();
        workFlowRepositoryMock.Setup(repo => repo.GetWorkFlowAsync(workFlowId))
            .ReturnsAsync((WorkFlowModel)null);

        var workFlowService = new WorkFlowService(workFlowRepositoryMock.Object);

        // Act
        var result = await workFlowService.GetWorkFlowAsync(workFlowId);

        // Assert
        Assert.Null(result);
    }


    [Fact]
    public async Task GetStageAsync_ExistingStage_ReturnsStage()
    {
        // Arrange
        var workFlowId = "1";
        var stageId = "4";
        var expectedStage = new WorkflowStageModel
        {
            /* Initialize with valid data */
        };

        var workFlowRepositoryMock = new Mock<IWorkFlowRepository>();
        workFlowRepositoryMock.Setup(repo => repo.GetStageAsync(workFlowId, stageId))
            .ReturnsAsync(expectedStage);

        var workFlowService = new WorkFlowService(workFlowRepositoryMock.Object);

        // Act
        var result = await workFlowService.GetStageAsync(workFlowId, stageId);

        // Assert
        Assert.Equal(expectedStage, result);
    }
    [Fact]
    public async Task GetStageAsync_NonExistentStage_ReturnsNull()
    {
        // Arrange
        var workFlowId = "1";
        var nonExistentStageId = "2";

        var workFlowRepositoryMock = new Mock<IWorkFlowRepository>();
        workFlowRepositoryMock.Setup(repo => repo.GetStageAsync(workFlowId, nonExistentStageId))
            .ReturnsAsync((WorkflowStageModel)null);

        var workFlowService = new WorkFlowService(workFlowRepositoryMock.Object);

        // Act
        var result = await workFlowService.GetStageAsync(workFlowId, nonExistentStageId);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task CreateOrUpdateStageAsync_ValidStage_ReturnsCreatedStage()
    {
        // Arrange
        var workFlowId = "1d";
        var validStage = new WorkflowStageModel {  };
        var expectedCreatedStage = new WorkflowStageModel { };

        var workFlowRepositoryMock = new Mock<IWorkFlowRepository>();
        workFlowRepositoryMock.Setup(repo => repo.CreateOrUpdateStageAsync(workFlowId, validStage))
            .ReturnsAsync(expectedCreatedStage);

        var workFlowService = new WorkFlowService(workFlowRepositoryMock.Object);

        // Act
        var result = await workFlowService.CreateOrUpdateStageAsync(workFlowId, validStage);

        // Assert
        Assert.Equal(expectedCreatedStage, result);
    }

    [Fact]
    public async Task DeleteStageAsync_ExistingStage_ReturnsTrue()
    {
        // Arrange
        var workFlowId = "1";
        var existingStageId = "2";

        var workFlowRepositoryMock = new Mock<IWorkFlowRepository>();
        workFlowRepositoryMock.Setup(repo => repo.DeleteStageAsync(workFlowId, existingStageId))
            .ReturnsAsync(true);

        var workFlowService = new WorkFlowService(workFlowRepositoryMock.Object);

        // Act
        var result = await workFlowService.DeleteStageAsync(workFlowId, existingStageId);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public async Task DeleteStageAsync_NonExistentStage_ReturnsFalse()
    {
        // Arrange
        var workFlowId = "1";
        var nonExistentStageId = "2";

        var workFlowRepositoryMock = new Mock<IWorkFlowRepository>();
        workFlowRepositoryMock.Setup(repo => repo.DeleteStageAsync(workFlowId, nonExistentStageId))
            .ReturnsAsync(false);

        var workFlowService = new WorkFlowService(workFlowRepositoryMock.Object);

        // Act
        var result = await workFlowService.DeleteStageAsync(workFlowId, nonExistentStageId);

        // Assert
        Assert.False(result);
    }


}