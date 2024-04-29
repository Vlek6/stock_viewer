using StockViewer.Api.Dtos;
using StockViewer.Api.Entities;

namespace StockViewer.Api;

/// <summary>
/// Provides mapping methods for converting between user entities and DTOs.
/// </summary>
public static class UserMapping
{
    /// <summary>
    /// Converts a <see cref="CreateUserDto"/> to a <see cref="User"/>.
    /// </summary>
    /// <param name="user">The <see cref="CreateUserDto"/> instance.</param>
    /// <returns>The corresponding <see cref="User"/> entity.</returns>
    public static User ToEntity(this CreateUserDto user)
    {
        return new User()
        {
            Login = user.Login,
            Password = user.Password
        };
    }

    /// <summary>
    /// Converts a <see cref="User"/> entity to a <see cref="UserSummaryDto"/>.
    /// </summary>
    /// <param name="user">The <see cref="User"/> entity.</param>
    /// <returns>The corresponding <see cref="UserSummaryDto"/>.</returns>
    public static UserSummaryDto ToUserSummaryDto(this User user)
    {
        var stocks = user.Stocks.Select(s => new StockSummaryDto(s.Id, s.StockSymbol)).ToList();
        return new(
            user.Id,
            user.Login,
            user.Password,
            stocks
        );
    }

    /// <summary>
    /// Converts a <see cref="UpdateUserDto"/> to a <see cref="User"/> entity with the specified ID.
    /// </summary>
    /// <param name="user">The <see cref="UpdateUserDto"/> instance.</param>
    /// <param name="id">The ID of the user.</param>
    /// <returns>The corresponding <see cref="User"/> entity.</returns>
    public static User ToEntity(this UpdateUserDto user, int id)
    {
        return new User()
        {
            Id = id,
            Login = user.Login,
            Password = user.Password
        };
    }
}
