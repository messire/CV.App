namespace CVA.Api;

public class User
{
    public Guid Id { get; } = Guid.NewGuid();
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }

    public DateOnly? Birthdate { get; set; }

    public string? Phone { get; set; }

    public string? SummaryInfo { get; set; }

    public List<Language> Languages { get; set; }

    public List<WorkPoint> WorkExperienсe { get; set; }

    public List<string> Skills { get; set; }
}