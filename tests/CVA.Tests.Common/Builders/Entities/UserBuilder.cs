using CVA.Domain.Models;

namespace CVA.Tests.Common;

/// <summary>
/// A builder class that creates instances of the <see cref="User"/> type using the AutoFixture library.
/// </summary>
internal sealed class UserBuilder : ISpecimenBuilder
{
    /// <summary>
    /// A singleton instance of the <see cref="UserBuilder"/> class.
    /// </summary>
    public static readonly ISpecimenBuilder Instance = new UserBuilder();

    /// <inheritdoc />
    public object Create(object request, ISpecimenContext context)
    {
        if (request is not Type type || type != typeof(User)) return new NoSpecimen();

        var name = context.Resolve(new SeededRequest(typeof(string), nameof(User.Name))).ToString()?.Split('-')[0];
        var surname = context.Resolve(new SeededRequest(typeof(string), nameof(User.Surname))).ToString()?.Split('-')[0];
        var randomNumber = Math.Abs((long)context.Resolve(typeof(long))).ToString();
        var phone = "+" + (randomNumber.Length > 11 ? randomNumber[..11] : randomNumber);
        
        var user = new User
        {
            Id = (Guid)context.Resolve(typeof(Guid)),
            Name = name ?? nameof(User.Name),
            Surname = surname ?? nameof(User.Surname),
            Email = $"{name}.{surname}@test.test".ToLower(),
            Phone = phone,
            Birthday = (DateOnly?)context.Resolve(typeof(DateOnly?)),
            SummaryInfo = (string)context.Resolve(typeof(string)),
            Skills = ((string[])context.Resolve(typeof(string[]))).ToList()
        };
        user.UpdateWorkExperience(((Work[])context.Resolve(typeof(Work[]))).ToList());
        return user;
    }
}