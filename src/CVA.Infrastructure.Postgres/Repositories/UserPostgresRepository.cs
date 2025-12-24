namespace CVA.Infrastructure.Postgres;

/// <summary>
/// Provides an implementation of the <see cref="IUserRepository"/> interface for interacting with user data in a PostgreSQL database.
/// </summary>
public class UserPostgresRepository(PostgresContext context) : IUserRepository
{
    /// <inheritdoc />
    public async Task<User> CreateAsync(User user, CancellationToken ct)
    {
        await context.Users.AddAsync(user, ct);
        await context.SaveChangesAsync(ct);
        return user;
    }

    /// <inheritdoc />
    public async Task<User?> GetByIdAsync(Guid id, CancellationToken ct)
        => await context.Users
            .Include(user => user.WorkExperience)
            .FirstOrDefaultAsync(user => user.Id == id, ct);

    /// <inheritdoc />
    public async Task<IEnumerable<User>> GetAllAsync(CancellationToken ct)
        => await context.Users
            .Include(user => user.WorkExperience)
            .ToListAsync(ct);

    /// <inheritdoc />
    public async Task<User?> UpdateAsync(User updatedUser, CancellationToken ct)
    {
        var existingUser = await context.Users
            .Include(user => user.WorkExperience)
            .FirstOrDefaultAsync(user => user.Id == updatedUser.Id, ct);

        if (existingUser is null) return null;

        existingUser.Name = updatedUser.Name;
        existingUser.Surname = updatedUser.Surname;
        existingUser.Email = updatedUser.Email;
        existingUser.Phone = updatedUser.Phone;
        existingUser.Birthday = updatedUser.Birthday;
        existingUser.SummaryInfo = updatedUser.SummaryInfo;
        existingUser.Skills = updatedUser.Skills;
        existingUser.UpdateWorkExperience(updatedUser.WorkExperience);

        await context.SaveChangesAsync(ct);
        return existingUser;
    }

    /// <inheritdoc />
    public async Task<User?> DeleteAsync(Guid id, CancellationToken ct)
    {
        var user = await context.Users.FindAsync([id], ct);
        if (user is null) return null;

        context.Users.Remove(user);
        await context.SaveChangesAsync(ct);
        return user;
    }
}