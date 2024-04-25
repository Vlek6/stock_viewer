using StockViewer.Api.Dtos;
using StockViewer.Api.Entities;

namespace StockViewer.Api;

public static class UserMapping
{
    public static User ToEntity(this CreateUserDto user)
    {
        return new User()
        {
            Login = user.Login,
            Password = user.Password
        };
    }

    public static UserSummaryDto ToUserSummaryDto(this User user)
    {
        var stocks = user.Stocks.Select(s => new StockSummaryDto(s.Id, s.StockName)).ToList();
        return new(
            user.Id,
            user.Login,
            stocks
        );
    }

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
