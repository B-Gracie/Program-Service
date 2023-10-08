using DataAccessLayer.Model;
using DataAccessLayer.Repository.@interface;
using Moq;
using ServiceLayer.ServiceImplementation;

namespace program_workflow_service_test.ServiceTest;

public class ApplicationTemplateServiceTests
{
    [Fact]
    public async Task GetApplicationTemplateAsync_ExistingTemplate_ReturnsTemplate()
    {
        // Arrange
        var templateId = "123";
        var expectedTemplate = new ApplicationTemplateModel { };

        var templateRepositoryMock = new Mock<IApplicationTemplateRepo>();
        templateRepositoryMock.Setup(repo => repo.GetApplicationTemplateAsync(templateId))
            .ReturnsAsync(expectedTemplate);

        var templateService = new ApplicationTemplateService(templateRepositoryMock.Object);

        // Act
        var result = await templateService.GetApplicationTemplateAsync(templateId);

        // Assert
        Assert.Equal(expectedTemplate, result);
    }

    [Fact]
    public async Task GetQuestionAsync_ExistingQuestion_ReturnsQuestion()
    {
        // Arrange
        var templateId = "123";
        var questionId = "456";
        var expectedQuestion = new ApplicationQuestionModel {  };

        var templateRepositoryMock = new Mock<IApplicationTemplateRepo>();
        templateRepositoryMock.Setup(repo => repo.GetQuestionAsync(templateId, questionId))
            .ReturnsAsync(expectedQuestion);

        var templateService = new ApplicationTemplateService(templateRepositoryMock.Object);

        // Act
        var result = await templateService.GetQuestionAsync(templateId, questionId);

        // Assert
        Assert.Equal(expectedQuestion, result);
    }

    [Fact]
    public async Task AddQuestionAsync_ValidQuestion_ReturnsCreatedQuestion()
    {
        // Arrange
        var templateId = "123";
        var validQuestion = new ApplicationQuestionModel {  };
        var expectedCreatedQuestion = new ApplicationQuestionModel { };

        var templateRepositoryMock = new Mock<IApplicationTemplateRepo>();
        templateRepositoryMock.Setup(repo => repo.AddQuestionAsync(templateId, validQuestion))
            .ReturnsAsync(expectedCreatedQuestion);

        var templateService = new ApplicationTemplateService(templateRepositoryMock.Object);

        // Act
        var result = await templateService.AddQuestionAsync(templateId, validQuestion);

        // Assert
        Assert.Equal(expectedCreatedQuestion, result);
    }

    [Fact]
    public async Task UpdateQuestionAsync_ValidQuestion_ReturnsUpdatedQuestion()
    {
        // Arrange
        var templateId = "123";
        var validQuestion = new ApplicationQuestionModel {  };
        var expectedUpdatedQuestion = new ApplicationQuestionModel {  };

        var templateRepositoryMock = new Mock<IApplicationTemplateRepo>();
        templateRepositoryMock.Setup(repo => repo.UpdateQuestionAsync(templateId, validQuestion))
            .ReturnsAsync(expectedUpdatedQuestion);

        var templateService = new ApplicationTemplateService(templateRepositoryMock.Object);

        // Act
        var result = await templateService.UpdateQuestionAsync(templateId, validQuestion);

        // Assert
        Assert.Equal(expectedUpdatedQuestion, result);
    }

    [Fact]
    public async Task DeleteQuestionAsync_ExistingQuestion_ReturnsTrue()
    {
        // Arrange
        var templateId = "123";
        var existingQuestionId = "456";

        var templateRepositoryMock = new Mock<IApplicationTemplateRepo>();
        templateRepositoryMock.Setup(repo => repo.DeleteQuestionAsync(templateId, existingQuestionId))
            .ReturnsAsync(true);

        var templateService = new ApplicationTemplateService(templateRepositoryMock.Object);

        // Act
        var result = await templateService.DeleteQuestionAsync(templateId, existingQuestionId);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public async Task DeleteQuestionAsync_NonExistentQuestion_ReturnsFalse()
    {
        // Arrange
        var templateId = "123";
        var nonExistentQuestionId = "456";

        var templateRepositoryMock = new Mock<IApplicationTemplateRepo>();
        templateRepositoryMock.Setup(repo => repo.DeleteQuestionAsync(templateId, nonExistentQuestionId))
            .ReturnsAsync(false);

        var templateService = new ApplicationTemplateService(templateRepositoryMock.Object);

        // Act
        var result = await templateService.DeleteQuestionAsync(templateId, nonExistentQuestionId);

        // Assert
        Assert.False(result);
    }
}