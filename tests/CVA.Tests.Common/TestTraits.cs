namespace CVA.Tests.Common;

/// <summary>
/// Provides constant string values that represent test categories.
/// </summary>
public static class Category
{
    /// <summary>
    /// Represents the test category for contracts-related tests.
    /// </summary>
    public const string Contracts = nameof(Contracts);

    /// <summary>
    /// Represents the test category for extension methods tests.
    /// </summary>
    public const string Helpers = nameof(Helpers);

    /// <summary>
    /// Represents the test category for repository-related tests.
    /// </summary>
    public const string Repository = nameof(Repository);

    /// <summary>
    /// Represents the test category for service-related tests.
    /// </summary>
    public const string Services = nameof(Services);

    /// <summary>
    /// Represents the test category for validator-related tests.
    /// </summary>
    public const string Validators = nameof(Validators);
}

/// <summary>
/// Provides constant string values that represent architectural layers.
/// </summary>
public static class Layer
{
    /// <summary>
    /// Represents the architectural layer for application-related logic in the testing framework.
    /// </summary>
    public const string Application = nameof(Application);

    /// <summary>
    /// Represents the architectural layer for infrastructure-related logic in the testing framework.
    /// </summary>
    public const string Infrastructure = nameof(Infrastructure);

    /// <summary>
    /// Represents the architectural layer for infrastructure-related logic in the testing framework.
    /// </summary>
    public const string Utility = nameof(Utility);
}