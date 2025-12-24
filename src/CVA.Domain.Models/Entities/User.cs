namespace CVA.Domain.Models;

/// <summary>
/// Represents a user entity in the application.
/// </summary>
public sealed class User
{
    private readonly List<Work> _workExperience = [];

    /// <summary>
    /// The unique identifier of the user.
    /// </summary>
    public Guid Id { get; init; } = Guid.CreateVersion7();

    /// <summary>
    /// The name of the user.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// The last name of the user.
    /// </summary>
    public required string Surname { get; set; }

    /// <summary>
    /// The email address of the user.
    /// </summary>
    public required string Email { get; set; }

    /// <summary>
    /// The phone number associated with the user.
    /// </summary>
    public string? Phone { get; set; }

    /// <summary>
    /// The date of birth of the user.
    /// </summary>
    public DateOnly? Birthday { get; set; }

    /// <summary>
    /// A brief summary or description of the user, typically highlighting key details or personal attributes.
    /// </summary>
    public string? SummaryInfo { get; set; }

    /// <summary>
    /// A collection of skills associated with the user.
    /// </summary>
    public List<string>? Skills { get; set; }

    /// <summary>
    /// A collection of work experiences associated with the user, detailing their professional roles, achievements, and other related information.
    /// </summary>
    public IReadOnlyCollection<Work> WorkExperience => _workExperience;

    /// <summary>
    /// Replaces the current work experience of the user with a new collection of work entries.
    /// </summary>
    /// <param name="works">The collection of new work entries to replace the existing work experience.</param>
    public void UpdateWorkExperience(IEnumerable<Work> works)
    {
        _workExperience.Clear();
        _workExperience.AddRange(works);
    }
}