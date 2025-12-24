namespace CVA.Domain.Models;

/// <summary>
/// Represents work experience associated with a user.
/// </summary>
public sealed class Work
{
    /// <summary>
    /// The name of the company where the work experience took place.
    /// </summary>
    public string? CompanyName { get; set; }

    /// <summary>
    /// The position or title held by the user at the company.
    /// </summary>
    public string? Role { get; set; }

    /// <summary>
    /// A detailed description of the work experience, including responsibilities and tasks performed.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// The location where the work experience took place.
    /// </summary>
    public string? Location { get; set; }

    /// <summary>
    /// The start date of the work experience.
    /// </summary>
    public DateOnly? StartDate { get; set; }

    /// <summary>
    /// The end date of the work experience.
    /// </summary>
    public DateOnly? EndDate { get; set; }

    /// <summary>
    /// A collection of accomplishments or milestones achieved during the work experience.
    /// </summary>
    public List<string>? Achievements { get; set; }

    /// <summary>
    /// The collection of technologies, tools, or frameworks utilized in the work experience.
    /// </summary>
    public List<string>? TechStack { get; set; }
}