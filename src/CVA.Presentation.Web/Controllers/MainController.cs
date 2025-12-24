using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CVA.Presentation.Web;

/// <summary>
/// The MainController class provides endpoints for managing user-related operations.
/// </summary>
[ApiController]
[Route("[controller]/api")]
[AllowAnonymous]
public class MainController(IUserService userService): ControllerBase
{
    /// <summary>
    /// Retrieves a collection of user data asynchronously.
    /// </summary>
    /// <param name="ct">A cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A result containing a collection of <c>UserDto</c> objects if successful; otherwise, a failure result with an error message.</returns>
    [HttpGet("/")]
    public async Task<Result<IEnumerable<UserDto>>> GetUsersAsync(CancellationToken ct)
    {
        var users = await userService.GetUsersAsync(ct);
        return users is null ? Result<IEnumerable<UserDto>>.Fail("Users not found") : Result<IEnumerable<UserDto>>.Ok(users);
    }

    /// <summary>
    /// Retrieves information about a user by their unique identifier asynchronously.
    /// </summary>
    /// <param name="id">The unique identifier of the user to retrieve.</param>
    /// <param name="ct">A cancellation token to observe while awaiting the operation.</param>
    /// <returns>A result containing the user data as a <c>UserDto</c> if found; otherwise, a failure result with an error message.</returns>
    [HttpGet("/{id:guid}")]
    public async Task<Result<UserDto>> GetUsersAsync(Guid id, CancellationToken ct)
    {
        var user = await userService.GetUserByIdAsync(id, ct);
        return user is null ? Result<UserDto>.Fail("User not found") : Result<UserDto>.Ok(user);
    }

    /// <summary>
    /// Creates a new user asynchronously.
    /// </summary>
    /// <param name="newUser">The data transfer object containing details of the user to be created.</param>
    /// <param name="ct">A cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A result containing the created <c>UserDto</c> object if successful; otherwise, a failure result with an error message.</returns>
    [HttpPost("/")]
    public async Task<Result<UserDto>> CreateUserAsync(UserDto newUser, CancellationToken ct)
    {
        var user = await userService.CreateUserAsync(newUser, ct);
        return user is null ? Result<UserDto>.Fail("User not found") : Result<UserDto>.Ok(user);
    }

    /// <summary>
    /// Updates an existing user's information asynchronously.
    /// </summary>
    /// <param name="updatedUser">A <c>UserDto</c> object containing the updated user details.</param>
    /// <param name="ct">A cancellation token to observe while waiting for the operation to complete.</param>
    /// <returns>A result containing the updated <c>UserDto</c> object if successful; otherwise, a failure result with an error message.</returns>
    [HttpPut("/")]
    public async Task<Result<UserDto>> UpdateUserAsync(UserDto updatedUser, CancellationToken ct)
    {
        var user = await userService.UpdateUserAsync(updatedUser, ct);
        return user is null ? Result<UserDto>.Fail("User not found") : Result<UserDto>.Ok(user);
    }

    /// <summary>
    /// Deletes a user identified by their unique identifier asynchronously.
    /// </summary>
    /// <param name="id">The unique identifier of the user to be deleted.</param>
    /// <param name="ct">A cancellation token to observe while waiting for the task to complete.</param>
    /// <returns>A result containing the deleted <c>UserDto</c> object if successful; otherwise, a failure result with an error message.</returns>
    [HttpDelete("/{id:guid}")]
    public async Task<Result<UserDto>> DeleteUserAsync(Guid id, CancellationToken ct)
    {
        var user = await userService.DeleteUserAsync(id, ct);
        return user is null ? Result<UserDto>.Fail("User not found") : Result<UserDto>.Ok(user);
    }
}