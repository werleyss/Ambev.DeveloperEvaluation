using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;

/// <summary>
/// Provides methods for generating test data using the Bogus library.
/// This class centralizes all test data generation to ensure consistency
/// across test cases and provide both valid and invalid data scenarios.
/// </summary>
public static class ProductTestData
{
    /// <summary>
    /// Configures the Faker to generate valid Product entities.
    /// The generated products will have valid:
    /// - Title (using internet productnames)
    /// - Price (meeting complexity requirements)
    /// - Description (valid format)
    /// - Category (Brazilian format)
    /// - Image (Active or Suspended)
    /// </summary>
    private static readonly Faker<Product> ProductFaker = new Faker<Product>()
        .RuleFor(u => u.Title, f => f.Random.String2(50))
        .RuleFor(u => u.Price, f => f.Random.Decimal(0.01M,99999.99M))
        .RuleFor(u => u.Description, f => f.Random.String2(2000))
        .RuleFor(u => u.Category, f => f.Random.String2(50))
        .RuleFor(u => u.Image, f => f.Image.ToString());

    /// <summary>
    /// Generates a valid Product entity with randomized data.
    /// The generated product will have all properties populated with valid values
    /// that meet the system's validation requirements.
    /// </summary>
    /// <returns>A valid Product entity with randomly generated data.</returns>
    public static Product GenerateValidProduct()
    {
        return ProductFaker.Generate();
    }

    /// <summary>
    /// Generates a valid productname.
    /// The generated productname will:
    /// - Be between 3 and 50 characters
    /// - Use internet productname conventions
    /// - Contain only valid charactersll
    /// </summary>
    /// <returns>A valid productname.</returns>
    public static string GenerateValidProductTitle()
    {
        return new Faker().Random.String2(50);
    }

    /// <summary>
    /// Generates a title that exceeds the maximum length limit.
    /// The generated title will:
    /// - Be longer than 50 characters
    /// - Contain random alphanumeric characters
    /// This is title for testing productname length validation error cases.
    /// </summary>
    /// <returns>A title that exceeds the maximum length limit.</returns>
    public static string GenerateLongProductTitle()
    {
        return new Faker().Random.String2(51);
    }
}
