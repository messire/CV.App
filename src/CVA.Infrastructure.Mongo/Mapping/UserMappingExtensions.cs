using CVA.Infrastructure.Mongo.Documents;

namespace CVA.Infrastructure.Mongo.Mapping;

/// <summary>
/// Mapping between domain models and Mongo persistence documents.
/// </summary>
public static class UserMongoMappingExtensions
{
    /// <summary>
    /// Maps a domain <see cref="User"/> to a Mongo <see cref="UserDocument"/>.
    /// </summary>
    public static UserDocument ToDocument(this User user)
        => new()
        {
            Id = user.Id,
            Name = user.Name,
            Surname = user.Surname,
            Email = user.Email,
            Phone = user.Phone,
            Birthday = user.Birthday,
            SummaryInfo = user.SummaryInfo,
            Skills = user.Skills ?? [],
            WorkExperience = user.WorkExperience.Select(ToDocument).ToList(),
        };

    /// <summary>
    /// Maps a domain <see cref="Work"/> to a Mongo <see cref="WorkDocument"/>.
    /// </summary>
    public static WorkDocument ToDocument(this Work work)
        => new()
        {
            CompanyName = work.CompanyName,
            Role = work.Role,
            Description = work.Description,
            Location = work.Location,
            StartDate = work.StartDate,
            EndDate = work.EndDate,
            Achievements = work.Achievements ?? [],
            TechStack = work.TechStack ?? [],
        };

    /// <summary>
    /// Maps a Mongo <see cref="UserDocument"/> to a domain <see cref="User"/>.
    /// </summary>
    public static User ToDomain(this UserDocument document)
    {
        var user = new User
        {
            Id = document.Id,
            Name = document.Name,
            Surname = document.Surname,
            Email = document.Email,
            Phone = document.Phone,
            Birthday = document.Birthday,
            SummaryInfo = document.SummaryInfo,
            Skills = document.Skills,
        };

        user.UpdateWorkExperience(document.WorkExperience.Select(ToDomain));
        return user;
    }

    /// <summary>
    /// Maps a Mongo <see cref="WorkDocument"/> to a domain <see cref="Work"/>.
    /// </summary>
    public static Work ToDomain(this WorkDocument document)
        => new()
        {
            CompanyName = document.CompanyName,
            Role = document.Role,
            Description = document.Description,
            Location = document.Location,
            StartDate = document.StartDate,
            EndDate = document.EndDate,
            Achievements = document.Achievements,
            TechStack = document.TechStack,
        };
}