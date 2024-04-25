using System.ComponentModel.DataAnnotations;

namespace StockViewer.Api.Dtos;

public record class CreateUserDto
(
    string Login,
    string Password
);