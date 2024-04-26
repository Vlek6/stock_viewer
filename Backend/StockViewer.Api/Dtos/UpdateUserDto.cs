namespace StockViewer.Api.Dtos;

/// <summary>
/// Represents the data transfer object (DTO) used for updating user information.
/// </summary>
public record class UpdateUserDto
(
    string Login,
    string Password
);