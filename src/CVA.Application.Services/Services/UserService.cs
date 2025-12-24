namespace CVA.Application.Services;

/// <summary>
/// Implements the <see cref="IUserService"/> interface.
/// </summary>
/// <param name="userRepository">The repository for user data.</param>
public class UserService(IUserRepository userRepository) : IUserService
{
    /// <inheritdoc />
    public async Task<IEnumerable<UserDto>?> GetUsersAsync(CancellationToken ct)
    {
        var users = await userRepository.GetAllAsync(ct);
        return users.ToDto();
    }

    /// <inheritdoc />
    public async Task<UserDto?> GetUserByIdAsync(Guid id, CancellationToken ct)
    {
        var user = await userRepository.GetByIdAsync(id, ct);
        return user?.ToDto();
    }

    /// <inheritdoc />
    public async Task<UserDto?> UpdateUserAsync(UserDto updatedUser, CancellationToken ct)
    {
        var userModel = updatedUser.ToModel();
        var user = await userRepository.UpdateAsync(userModel, ct);
        return user?.ToDto();
    }

    /// <inheritdoc />
    public async Task<UserDto?> DeleteUserAsync(Guid id, CancellationToken ct)
    {
        var user = await userRepository.DeleteAsync(id, ct);
        return user?.ToDto();
    }

    /// <inheritdoc />
    public async Task<UserDto?> CreateUserAsync(UserDto userDto, CancellationToken ct)
    {
        var userModel = userDto.ToModel();
        var user = await userRepository.CreateAsync(userModel, ct);
        return user.ToDto();
    }
}