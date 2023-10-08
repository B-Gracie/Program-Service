using DataAccessLayer.Model;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ProgramAPI.Controllers;
using ServiceLayer.ServiceInterface;

namespace program_workflow_service_test.ControllerTest
{
    public class WorkFlowControllerTests
    {
        [Fact]
        public async Task GetStageAsync_ExistingStage_ReturnsOkResult()
        {
            // Arrange
            var workFlowId = "1";
            var stageId = "2";
            var workFlowServiceMock = new Mock<IWorkFlowService>();
            var expectedStage = new WorkflowStageModel { Id = stageId /*, other properties */ };
            workFlowServiceMock.Setup(service => service.GetStageAsync(workFlowId, stageId)).ReturnsAsync(expectedStage);
            var controller = new WorkFlowController(workFlowServiceMock.Object);

            // Act
            var result = await controller.GetStageAsync(workFlowId, stageId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedStage = Assert.IsType<WorkflowStageModel>(okResult.Value);
            Assert.Equal(stageId, returnedStage.Id);
            // Add more assertions for other properties as needed.
        }

        [Fact]
        public async Task GetStageAsync_NonExistentStage_ReturnsNotFound()
        {
            // Arrange
            var workFlowId = "1";
            var stageId = "2";
            var workFlowServiceMock = new Mock<IWorkFlowService>();
            workFlowServiceMock.Setup(service => service.GetStageAsync(workFlowId, stageId)).ReturnsAsync((WorkflowStageModel)null);
            var controller = new WorkFlowController(workFlowServiceMock.Object);

            // Act
            var result = await controller.GetStageAsync(workFlowId, stageId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task CreateOrUpdateStageAsync_ValidInput_ReturnsCreatedAtAction()
        {
            // Arrange
            var workFlowId = "1";
            var stage = new WorkflowStageModel { };
            var workFlowServiceMock = new Mock<IWorkFlowService>();
            var createdOrUpdatedStage = new WorkflowStageModel { Id = "1" };
            workFlowServiceMock.Setup(service => service.CreateOrUpdateStageAsync(workFlowId, stage)).ReturnsAsync(createdOrUpdatedStage);
            var controller = new WorkFlowController(workFlowServiceMock.Object);

            // Act
            var result = await controller.CreateOrUpdateStageAsync(workFlowId, stage);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal("GetStage", createdAtActionResult.ActionName);
            // Add more assertions as needed.
        }

        [Fact]
        public async Task DeleteStageAsync_ExistingStage_ReturnsNoContent()
        {
            // Arrange
            var workFlowId = "1";
            var stageId = "2";
            var workFlowServiceMock = new Mock<IWorkFlowService>();
            workFlowServiceMock.Setup(service => service.DeleteStageAsync(workFlowId, stageId)).ReturnsAsync(true);
            var controller = new WorkFlowController(workFlowServiceMock.Object);

            // Act
            var result = await controller.DeleteStageAsync(workFlowId, stageId);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DeleteStageAsync_NonExistentStage_ReturnsNotFound()
        {
            // Arrange
            var workFlowId = "1";
            var stageId = "2";
            var workFlowServiceMock = new Mock<IWorkFlowService>();
            workFlowServiceMock.Setup(service => service.DeleteStageAsync(workFlowId, stageId)).ReturnsAsync(false);
            var controller = new WorkFlowController(workFlowServiceMock.Object);

            // Act
            var result = await controller.DeleteStageAsync(workFlowId, stageId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
