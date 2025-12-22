namespace CVA.Api;


public sealed class WorkPoint
{
    public string CompanyName { get; set; }

    public string Role { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public string? Description { get; set; }

    public List<string> Achievements { get; set; } = [];

    public List<string>? TechStack { get; set; } = [];
}