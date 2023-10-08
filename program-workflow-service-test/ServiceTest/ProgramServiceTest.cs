using AutoMapper;
using DataAccessLayer.Model;
using DataAccessLayer.Repository.@interface;
using Moq;
using ServiceLayer.ServiceImplementation;

namespace program_workflow_service_test.ServiceTest;

public class ProgramServiceTests
{
    [Fact]
    public async Task GetProgramAsync_ExistingProgramId_ReturnsProgramModel()
    {
        // Arrange
        var programRepositoryMock = new Mock<IProgramRepository>();
        var mapperMock = new Mock<IMapper>();

        var programId = "1";
        var programModel = new ProgramModel
        {
            Id = programId,
            ProgramTitle = "Test Program",
            // Other properties...
        };

        programRepositoryMock.Setup(repo => repo.GetProgramAsync(programId))
            .ReturnsAsync(programModel);

        var programService = new ProgramService(programRepositoryMock.Object, mapperMock.Object);

        // Act
        var result = await programService.GetProgramAsync(programId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(programId, result.Id);
        // Add more assertions for other properties as needed.
    }

    [Fact]
    public async Task GetProgramAsync_NonExistentProgramId_ReturnsNull()
    {
        // Arrange
        var programRepositoryMock = new Mock<IProgramRepository>();
        var mapperMock = new Mock<IMapper>();

        var programId = "2";
        programRepositoryMock.Setup(repo => repo.GetProgramAsync(programId))
            .ReturnsAsync((ProgramModel)null); // Cast to ProgramModel explicitly

        var programService = new ProgramService(programRepositoryMock.Object, mapperMock.Object);

        // Act
        var result = await programService.GetProgramAsync(programId);

        // Assert
        Assert.Null(result);
    }


    [Fact]
    public async Task UpdateProgramAsync_ExistingProgram_ReturnsUpdatedProgramModel()
    {
        // Arrange
        var programRepositoryMock = new Mock<IProgramRepository>();
        var mapperMock = new Mock<IMapper>();

        var programId = "1";
        var updatedProgramModel = new ProgramModel
        {
            Id = programId,
            ProgramTitle = "Updated Program",
            // Other properties...
        };

        programRepositoryMock.Setup(repo => repo.UpdateProgramAsync(programId, It.IsAny<ProgramModel>()))
            .ReturnsAsync(updatedProgramModel);

        var programService = new ProgramService(programRepositoryMock.Object, mapperMock.Object);

        // Act
        var result = await programService.UpdateProgramAsync(programId, updatedProgramModel);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(programId, result.Id);
        // Add more assertions for other properties as needed.
    }

    [Fact]
    public async Task DeleteProgramAsync_ExistingProgram_ReturnsTrue()
    {
        // Arrange
        var programRepositoryMock = new Mock<IProgramRepository>();
        var mapperMock = new Mock<IMapper>();

        var programId = "1";
        programRepositoryMock.Setup(repo => repo.DeleteProgramAsync(programId))
            .ReturnsAsync(true);

        var programService = new ProgramService(programRepositoryMock.Object, mapperMock.Object);

        // Act
        var result = await programService.DeleteProgramAsync(programId);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public async Task DeleteProgramAsync_NonExistentProgram_ReturnsFalse()
    {
        // Arrange
        var programRepositoryMock = new Mock<IProgramRepository>();
        var mapperMock = new Mock<IMapper>();

        var programId = "2";
        programRepositoryMock.Setup(repo => repo.DeleteProgramAsync(programId))
            .ReturnsAsync(false);

        var programService = new ProgramService(programRepositoryMock.Object, mapperMock.Object);

        // Act
        var result = await programService.DeleteProgramAsync(programId);

        // Assert
        Assert.False(result);
    }
}