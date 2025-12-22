namespace CVA.Api;

public interface IUserService
{
    Task<int> CreateUser(string name, string surname, string email, CancellationToken ct);
}