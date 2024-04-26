using System.ComponentModel.DataAnnotations;

namespace StockViewer.Api.Dtos;

/// <summary>
/// Represents the data transfer object (DTO) used for creating a new user.
/// </summary>
public record class CreateUserDto
(
    string Login,

    string Password
);