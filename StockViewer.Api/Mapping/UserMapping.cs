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
        return new(
            user.Id,
            user.Login
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
