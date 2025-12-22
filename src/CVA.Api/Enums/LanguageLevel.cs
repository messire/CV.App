namespace CVA.Api;

/// <summary>
/// Defines language proficiency levels, ranging from no proficiency to native-level fluency.
/// </summary>
public enum LanguageLevel
{
    /// <summary>
    /// Represents the absence of any language proficiency.
    /// </summary>
    None = 0,

    /// <summary>
    /// Represents a basic or introductory level
    /// </summary>
    Beginner,

    /// <summary>
    /// Indicates a moderate level of language proficiency, suitable for handling everyday communication and tasks.
    /// </summary>
    Intermediate,

    /// <summary>
    /// Represents a high level of language proficiency, enabling the user to effectively communicate in complex situations with confidence.
    /// </summary>
    Advanced,

    /// <summary>
    /// Indicates a high level of language proficiency, demonstrating expertise and fluency.
    /// </summary>
    Proficient,

    /// <summary>
    /// Represents a language proficiency level where the individual has the fluency and understanding of a native speaker.
    /// </summary>
    Native,
}