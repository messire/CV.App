namespace CVA.Api;

public interface IUserRepository
{
    Task<int> CreateUserAsync(User user, CancellationToken ct);
}