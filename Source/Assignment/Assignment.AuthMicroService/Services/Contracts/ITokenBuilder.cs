using Assignment.Models;

namespace Assignment.AuthMicroService.Services
{
    public interface ITokenBuilder
    {
        string BuildToken(UserViewModel userInfo);
    }
}
