namespace CVA.Api;

public record UserDto(string Name, string Surname, string Email, DateOnly? Birthdate, string? Phone);