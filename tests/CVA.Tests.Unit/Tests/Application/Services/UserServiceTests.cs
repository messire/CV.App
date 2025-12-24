using CVA.Application.Services;
using CVA.Domain.Interfaces;
using CVA.Domain.Models;
using Moq;

namespace CVA.Tests.Unit.Application.Services;

/// <summary>
/// Unit tests for the <see cref="UserService"/> class.
/// </summary>
[Trait(Layer.Application, Category.Services)]
public class UserServiceTests
{
    /// <summary>
    /// Purpose: Verify that GetUsersAsync returns a collection of DTOs.
    /// Should: Return all users mapped to DTOs.
    /// When: Repository contains users.
    /// </summary>
    [Theory, CvaAutoData]
    public async Task GetUsersAsync_Should_Return_All_Users(
        List<User> users,
        [Frozen] Mock<IUserRepository> userRepositoryMock,
        UserService sut)
    {
        // Arrange
        userRepositoryMock
            .Setup(repository => repository.GetAllAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(users);

        // Act
        var result = await sut.GetUsersAsync(CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(users.Count, result.Count());
        userRepositoryMock.Verify(repository => repository.GetAllAsync(It.IsAny<CancellationToken>()), Times.Once);
    }

    /// <summary>
    /// Purpose: Verify that GetUserByIdAsync returns a DTO when a user is found.
    /// Should: Call repository GetByIdAsync once and map the result to DTO.
    /// When: A valid Guid is provided and user exists in the database.
    /// </summary>
    [Theory, CvaAutoData]
    public async Task GetUserByIdAsync_Should_Return_UserDto_When_User_Exists(
        User user,
        [Frozen] Mock<IUserRepository> userRepositoryMock,
        UserService sut)
    {
        // Arrange
        userRepositoryMock
            .Setup(repository => repository.GetByIdAsync(user.Id, It.IsAny<CancellationToken>()))
            .ReturnsAsync(user);

        // Act
        var result = await sut.GetUserByIdAsync(user.Id, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(user.Id, result.Id);
        Assert.Equal(user.Name, result.Name);
        userRepositoryMock.Verify(repository => repository.GetByIdAsync(user.Id, It.IsAny<CancellationToken>()), Times.Once);
    }

    /// <summary>
    /// Purpose: Verify that GetUserByIdAsync returns null when user is not found.
    /// Should: Return null without throwing an exception.
    /// When: Repository returns null for the given ID.
    /// </summary>
    [Theory, CvaAutoData]
    public async Task GetUserByIdAsync_Should_Return_Null_When_User_Does_Not_Exist(
        Guid userId,
        [Frozen] Mock<IUserRepository> userRepositoryMock,
        UserService sut)
    {
        // Arrange
        userRepositoryMock
            .Setup(repository => repository.GetByIdAsync(userId, It.IsAny<CancellationToken>()))
            .ReturnsAsync((User?)null);

        // Act
        var result = await sut.GetUserByIdAsync(userId, CancellationToken.None);

        // Assert
        Assert.Null(result);
        userRepositoryMock.Verify(repository => repository.GetByIdAsync(userId, It.IsAny<CancellationToken>()), Times.Once);
    }

    /// <summary>
    /// Purpose: Verify that CreateUserAsync correctly saves a new user.
    /// Should: Map DTO to Model, call CreateAsync and return the resulting DTO.
    /// When: A valid UserDto is provided.
    /// </summary>
    [Theory, CvaAutoData]
    public async Task CreateUserAsync_Should_Return_Created_UserDto(
        UserDto inputDto,
        User createdModel,
        [Frozen] Mock<IUserRepository> userRepositoryMock,
        UserService sut)
    {
        // Arrange
        userRepositoryMock
            .Setup(repository => repository.CreateAsync(It.IsAny<User>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(createdModel);

        // Act
        var result = await sut.CreateUserAsync(inputDto, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(createdModel.Name, result.Name);
        userRepositoryMock.Verify(repository => repository.CreateAsync(It.IsAny<User>(), It.IsAny<CancellationToken>()), Times.Once);
    }

    /// <summary>
    /// Purpose: Verify that UpdateUserAsync updates an existing user.
    /// Should: Map DTO to Model, call UpdateAsync and return the updated DTO.
    /// When: Valid UserDto with existing ID is provided.
    /// </summary>
    [Theory, CvaAutoData]
    public async Task UpdateUserAsync_Should_Return_Updated_UserDto(
        UserDto updateDto,
        User model,
        [Frozen] Mock<IUserRepository> userRepositoryMock,
        UserService sut)
    {
        // Arrange
        var updatedModel = new User
        {
            Id = (Guid)updateDto.Id!,
            Name = model.Name,
            Surname = model.Surname,
            Email = model.Email,
            Phone = model.Phone,
            Birthday = model.Birthday,
            SummaryInfo = model.SummaryInfo,
            Skills = model.Skills
        };
        updatedModel.UpdateWorkExperience(model.WorkExperience);

        userRepositoryMock
            .Setup(repository => repository.UpdateAsync(It.IsAny<User>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(updatedModel);

        // Act
        var result = await sut.UpdateUserAsync(updateDto, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(updateDto.Id, result.Id);
        userRepositoryMock.Verify(repository => repository.UpdateAsync(It.IsAny<User>(), It.IsAny<CancellationToken>()), Times.Once);
    }

    /// <summary>
    /// Purpose: Ensure DeleteUserAsync triggers repository deletion.
    /// Should: Call DeleteAsync and return DTO of the deleted user.
    /// When: Delete is requested for an existing user.
    /// </summary>
    [Theory, CvaAutoData]
    public async Task DeleteUserAsync_Should_Return_Deleted_UserDto(
        Guid userId,
        User model,
        [Frozen] Mock<IUserRepository> userRepositoryMock,
        UserService sut)
    {
        // Arrange
        var deletedModel = new User
        {
            Id = userId,
            Name = model.Name,
            Surname = model.Surname,
            Email = model.Email
        };
        userRepositoryMock
            .Setup(repository => repository.DeleteAsync(userId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(deletedModel);

        // Act
        var result = await sut.DeleteUserAsync(userId, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(userId, result.Id);
        userRepositoryMock.Verify(repository => repository.DeleteAsync(userId, It.IsAny<CancellationToken>()), Times.Once);
    }
}