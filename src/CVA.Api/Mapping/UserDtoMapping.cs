namespace CVA.Api;

public static class UserDtoMapping
{
    public static User ToModel(this UserDto dto)
        => new ()
        {
            Name = dto.Name,
            Surname = dto.Surname,
            Email = dto.Email,
            Birthdate = dto.Birthdate,
            Phone = dto.Phone
        };
}