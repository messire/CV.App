using CVA.Domain.Models;

namespace CVA.Tests.Common;

/// <summary>
/// A builder class that creates instances of the <see cref="Work"/> type using the AutoFixture library.
/// </summary>
internal sealed class WorkBuilder : ISpecimenBuilder
{
    /// <summary>
    /// A singleton instance of the <see cref="WorkBuilder"/> class.
    /// </summary>
    public static readonly ISpecimenBuilder Instance = new WorkBuilder();

    /// <inheritdoc />
    public object Create(object request, ISpecimenContext context)
    {
        if (request is not Type type || type != typeof(Work)) return new NoSpecimen();

        return new Work
        {
            CompanyName = (string)context.Resolve(typeof(string)),
            Role = (string)context.Resolve(typeof(string)),
            Description = (string)context.Resolve(typeof(string)),
            Location = (string)context.Resolve(typeof(string)),
            StartDate = (DateOnly)context.Resolve(typeof(DateOnly)),
            EndDate = (DateOnly)context.Resolve(typeof(DateOnly)),
            Achievements = ((string[])context.Resolve(typeof(string[]))).ToList(),
            TechStack = ((string[])context.Resolve(typeof(string[]))).ToList()
        };
    }
}