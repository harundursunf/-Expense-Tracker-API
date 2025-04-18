using Core.Utilities.Secuirty.JWT;
using Entities.Dto;

namespace Business.Abstract
{
    public interface IAuthService
    {
        void Register(RegisterDto registerDto);
       public Token Login(LoginDto loginDto);
    }
}
