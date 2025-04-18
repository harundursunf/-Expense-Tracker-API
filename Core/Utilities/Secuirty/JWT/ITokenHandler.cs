using Core.Utilities.Secuirty.JWT;
using Entities.Entities;

namespace Core.Utilities.Security.JWT
{
    public interface ITokenHandler
    {
        Token CreateAccessToken(User user);
    }
}
