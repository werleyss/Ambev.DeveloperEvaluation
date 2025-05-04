﻿namespace Ambev.DeveloperEvaluation.Application.Products.UpdateProduct;

/// <summary>
/// Represents the response returned after successfully creating a new product.
/// </summary>
/// <remarks>
/// This response contains the unique identifier of the newly updated product,
/// which can be used for subsequent operations or reference.
/// </remarks>
public class UpdateProductResult
{
    /// <summary>
    /// Gets the unique identifier of the newly updated product.
    /// </summary>
    /// <value>A GUID that uniquely identifies the updated product in the system.</value>
    public Guid Id { get; set; }
}
