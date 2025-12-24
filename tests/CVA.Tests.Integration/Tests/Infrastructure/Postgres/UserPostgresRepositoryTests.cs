using CVA.Domain.Models;
using CVA.Infrastructure.Postgres;
using CVA.Tests.Common;
using CVA.Tests.Common.Comparers;
using CVA.Tests.Integration.Fixtures;
using Microsoft.EntityFrameworkCore;

namespace CVA.Tests.Integration.Tests.Infrastructure.Postgres;

/// <summary>
/// Integration tests for the <see cref="UserPostgresRepository"/> using Testcontainers.
/// </summary>
[Trait(Layer.Infrastructure, Category.Repository)]
public sealed class UserPostgresRepositoryTests(PostgresFixture fixture) : PostgresTestBase(fixture)
{
    private static UserPostgresRepository CreateRepository(PostgresContext context) => new(context);
    private static readonly UserComparer UserComp = new();

    /// <summary>
    /// Purpose: Verify that CreateAsync correctly persists a user entity to the database.
    /// Should: Assign an ID to the user and ensure all fields are correctly saved.
    /// When: A new user object is passed to the repository.
    /// </summary>
    [Fact]
    public async Task CreateAsync_ShouldPersistUser()
    {
        // Arrange
        var user = DataGenerator.CreateUser();
        await using var context = CreateContext();
        var repository = CreateRepository(context);

        // Act
        var result = await repository.CreateAsync(user, Cts.Token);

        // Assert
        var dbUser = await GetFreshUser(result.Id);
        Assert.NotNull(dbUser);
        Assert.Equal(user, dbUser, UserComp);
    }

    /// <summary>
    /// Purpose: Verify that GetByIdAsync retrieves the correct user including related data.
    /// Should: Return the user with populated work experience.
    /// When: A valid existing user ID is provided.
    /// </summary>
    [Fact]
    public async Task GetByIdAsync_ShouldReturnUserWithWorkExperience()
    {
        // Arrange
        var seedUser = DataGenerator.CreateUser();
        await using (var setupContext = CreateContext())
        {
            await setupContext.Users.AddAsync(seedUser);
            await setupContext.SaveChangesAsync();
        }

        await using var context = CreateContext();
        var repository = CreateRepository(context);

        // Act
        var result = await repository.GetByIdAsync(seedUser.Id, Cts.Token);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(seedUser, result, UserComp);
    }

    /// <summary>
    /// Purpose: Verify that UpdateAsync updates both basic fields and related collections.
    /// Should: Reflect changes in the database for name, surname, and work experience.
    /// When: An existing user entity is modified and updated.
    /// </summary>
    [Fact]
    public async Task UpdateAsync_ShouldUpdateFieldsAndWorkExperience()
    {
        // Arrange
        var initialUser = DataGenerator.CreateUser();
        var newName = DataGenerator.CreateString();
        var newSurname = DataGenerator.CreateString();

        await using (var setupContext = CreateContext())
        {
            await setupContext.Users.AddAsync(initialUser);
            await setupContext.SaveChangesAsync();
        }

        await using var context = CreateContext();
        var repository = CreateRepository(context);

        initialUser.Name = newName;
        initialUser.Surname = newSurname;
        initialUser.UpdateWorkExperience([new Work { CompanyName = "Fact Corp" }]);

        // Act
        await repository.UpdateAsync(initialUser, Cts.Token);

        // Assert
        var dbUser = await GetFreshUser(initialUser.Id);
        Assert.Equal(newName, dbUser!.Name);
        Assert.Equal("Fact Corp", dbUser.WorkExperience.FirstOrDefault()?.CompanyName);
    }

    /// <summary>
    /// Purpose: Verify that DeleteAsync correctly removes a user from the database.
    /// Should: Ensure the user no longer exists in the context after deletion.
    /// When: A valid user ID is provided for removal.
    /// </summary>
    [Fact]
    public async Task DeleteAsync_ShouldRemoveUser()
    {
        // Arrange
        var user = DataGenerator.CreateUser();
        await using (var setupContext = CreateContext())
        {
            await setupContext.Users.AddAsync(user);
            await setupContext.SaveChangesAsync();
        }

        await using var context = CreateContext();
        var repository = CreateRepository(context);

        // Act
        await repository.DeleteAsync(user.Id, Cts.Token);

        // Assert
        var dbUser = await GetFreshUser(user.Id);
        Assert.Null(dbUser);
    }

    /// <summary>
    /// Purpose: Verify that GetAllAsync retrieves all users from the repository.
    /// Should: Return a collection containing all seeded users.
    /// When: Multiple users exist in the database.
    /// </summary>
    [Fact]
    public async Task GetAllAsync_ShouldReturnUsers()
    {
        // Arrange
        var users = DataGenerator.CreateUsers(2);
        await using (var setupContext = CreateContext())
        {
            await setupContext.Users.AddRangeAsync(users);
            await setupContext.SaveChangesAsync();
        }

        await using var context = CreateContext();
        var repository = CreateRepository(context);

        // Act
        var result = await repository.GetAllAsync(Cts.Token);

        // Assert
        Assert.Equal(2, result.Count());
    }

    /// <summary>
    /// Purpose: Verify that GetByIdAsync returns null when user does not exist.
    /// Should: Return null without throwing an exception.
    /// When: A non-existent Guid is provided.
    /// </summary>
    [Fact]
    public async Task GetByIdAsync_ShouldReturnNull_WhenUserDoesNotExist()
    {
        // Arrange
        await using var context = CreateContext();
        var repository = CreateRepository(context);

        // Act
        var result = await repository.GetByIdAsync(Guid.CreateVersion7(), Cts.Token);

        // Assert
        Assert.Null(result);
    }

    /// <summary>
    /// Purpose: Ensure DeleteAsync does not fail when trying to delete a non-existent user.
    /// Should: Complete successfully (idempotent behavior).
    /// When: An invalid ID is passed to DeleteAsync.
    /// </summary>
    [Fact]
    public async Task DeleteAsync_ShouldNotThrow_WhenUserDoesNotExist()
    {
        // Arrange
        await using var context = CreateContext();
        var repository = CreateRepository(context);

        // Act & Assert
        var exception = await Record.ExceptionAsync(() => repository.DeleteAsync(Guid.CreateVersion7(), Cts.Token));
        Assert.Null(exception);
    }

    private async Task<User?> GetFreshUser(Guid id)
    {
        await using var checkContext = CreateContext();
        return await checkContext.Users
            .Include(user => user.WorkExperience)
            .AsNoTracking()
            .FirstOrDefaultAsync(user => user.Id == id);
    }
}