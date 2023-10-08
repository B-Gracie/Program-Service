using DataAccessLayer.Model;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ProgramAPI.Controllers;
using ServiceLayer.ServiceInterface;

namespace program_workflow_service_test.ControllerTest;

public class ApplicationTemplateControllerTests
{
    [Fact]
    public async Task GetApplicationTemplateAsync_ExistingTemplate_ReturnsOkResult()
    {
        // Arrange
        var templateId = "2";
        var templateServiceMock = new Mock<IApplicationTemplateService>();
        var expectedTemplate = new ApplicationTemplateModel { Id = templateId /*, other properties */ };
        templateServiceMock.Setup(service => service.GetApplicationTemplateAsync(templateId)).ReturnsAsync(expectedTemplate);
        var controller = new ApplicationTemplateController(templateServiceMock.Object);

        // Act
        var result = await controller.GetApplicationTemplateAsync(templateId);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnedTemplate = Assert.IsType<ApplicationTemplateModel>(okResult.Value);
        Assert.Equal(templateId, returnedTemplate.Id);
        // Add more assertions for other properties as needed.
    }

    [Fact]
    public async Task GetApplicationTemplateAsync_NonExistentTemplate_ReturnsNotFound()
    {
        // Arrange
        var templateId = "1";
        var templateServiceMock = new Mock<IApplicationTemplateService>();
        templateServiceMock.Setup(service => service.GetApplicationTemplateAsync(templateId)).ReturnsAsync((ApplicationTemplateModel)null);
        var controller = new ApplicationTemplateController(templateServiceMock.Object);

        // Act
        var result = await controller.GetApplicationTemplateAsync(templateId);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task AddQuestionAsync_ValidInput_ReturnsCreatedAtAction()
    {
        // Arrange
        var templateId = "2";
        var question = new ApplicationQuestionModel { };
        var templateServiceMock = new Mock<IApplicationTemplateService>();
        var addedQuestion = new ApplicationQuestionModel { Id = "new-question-id" };
        templateServiceMock.Setup(service => service.AddQuestionAsync(templateId, question)).ReturnsAsync(addedQuestion);
        var controller = new ApplicationTemplateController(templateServiceMock.Object);

        // Act
        var result = await controller.AddQuestionAsync(templateId, question);

        // Assert
        var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
        Assert.Equal("GetQuestion", createdAtActionResult.ActionName);
        // Add more assertions as needed.
    }

    [Fact]
    public async Task GetQuestionAsync_ExistingQuestion_ReturnsOkResult()
    {
        // Arrange
        var templateId = "2";
        var questionId = "3";
        var templateServiceMock = new Mock<IApplicationTemplateService>();
        var expectedQuestion = new ApplicationQuestionModel { Id = questionId };
        templateServiceMock.Setup(service => service.GetQuestionAsync(templateId, questionId)).ReturnsAsync(expectedQuestion);
        var controller = new ApplicationTemplateController(templateServiceMock.Object);

        // Act
        var result = await controller.GetQuestionAsync(templateId, questionId);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnedQuestion = Assert.IsType<ApplicationQuestionModel>(okResult.Value);
        Assert.Equal(questionId, returnedQuestion.Id);
        // Add more assertions for other properties as needed.
    }

    [Fact]
    public async Task GetQuestionAsync_NonExistentQuestion_ReturnsNotFound()
    {
        // Arrange
        var templateId = "2";
        var questionId = "3";
        var templateServiceMock = new Mock<IApplicationTemplateService>();
        templateServiceMock.Setup(service => service.GetQuestionAsync(templateId, questionId)).ReturnsAsync((ApplicationQuestionModel)null);
        var controller = new ApplicationTemplateController(templateServiceMock.Object);

        // Act
        var result = await controller.GetQuestionAsync(templateId, questionId);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task UpdateQuestionAsync_ValidInput_ReturnsOkResult()
    {
        // Arrange
        var templateId = "2";
        var questionId = "3";
        var question = new ApplicationQuestionModel { /* Initialize with valid data */ };
        var templateServiceMock = new Mock<IApplicationTemplateService>();
        var updatedQuestion = new ApplicationQuestionModel { Id = questionId /*, other properties */ };
        templateServiceMock.Setup(service => service.UpdateQuestionAsync(templateId, question)).ReturnsAsync(updatedQuestion);
        var controller = new ApplicationTemplateController(templateServiceMock.Object);

        // Act
        var result = await controller.UpdateQuestionAsync(templateId, questionId, question);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnedQuestion = Assert.IsType<ApplicationQuestionModel>(okResult.Value);
        Assert.Equal(questionId, returnedQuestion.Id);
        // Add more assertions for other properties as needed.
    }

    [Fact]
    public async Task DeleteQuestionAsync_ExistingQuestion_ReturnsNoContent()
    {
        // Arrange
        var templateId = "2";
        var questionId = "3";
        var templateServiceMock = new Mock<IApplicationTemplateService>();
        templateServiceMock.Setup(service => service.DeleteQuestionAsync(templateId, questionId)).ReturnsAsync(true);
        var controller = new ApplicationTemplateController(templateServiceMock.Object);

        // Act
        var result = await controller.DeleteQuestionAsync(templateId, questionId);

        // Assert
        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public async Task DeleteQuestionAsync_NonExistentQuestion_ReturnsNotFound()
    {
        // Arrange
        var templateId = "1";
        var questionId = "4";
        var templateServiceMock = new Mock<IApplicationTemplateService>();
        templateServiceMock.Setup(service => service.DeleteQuestionAsync(templateId, questionId)).ReturnsAsync(false);
        var controller = new ApplicationTemplateController(templateServiceMock.Object);

        // Act
        var result = await controller.DeleteQuestionAsync(templateId, questionId);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }
}