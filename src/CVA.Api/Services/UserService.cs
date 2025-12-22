namespace CVA.Api;

public class UserService(ILogger logger, IUserRepository userRepository) : IUserService
{
    public async Task<int> CreateUser(string name, string surname, string email, CancellationToken ct)
    {
        var user = new User
        {
            Name = name,
            Surname = surname,
            Email = email,
        };

        try
        {
            await userRepository.CreateUserAsync(user, ct);
            return 0;
        }
        catch (Exception e)
        {
            logger.LogError(e, "Error creating user");
            return -1;
        }
        
    }
}