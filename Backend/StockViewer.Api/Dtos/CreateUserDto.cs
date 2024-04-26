using System.ComponentModel.DataAnnotations;

namespace StockViewer.Api.Dtos;

/// <summary>
/// Represents the data transfer object (DTO) used for creating a new user.
/// </summary>
public record class CreateUserDto
(
    /// <summary>
    /// Gets or sets the login of the user.
    /// </summary>
    string Login,

    /// <summary>
    /// Gets or sets the password of the user.
    /// </summary>
    string Password
);