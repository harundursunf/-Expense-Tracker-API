using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Utilities.Hashing;
using Core.Utilities.Secuirty.JWT;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using Entities.Dto;
using Entities.Entities;
using FluentValidation.Results;
using Microsoft.Extensions.Configuration;
using System;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IUserDal _userDal;
        private readonly IRolesDal _rolesDal;
        private readonly IConfiguration _configuration;

        public AuthManager(IUserDal userDal, IRolesDal rolesDal, IConfiguration configuration)
        {
            _userDal = userDal;
            _rolesDal = rolesDal;
            _configuration = configuration;
        }

        public void Register(RegisterDto registerDto)
        {
            // 1. FluentValidation doğrulaması
            var validator = new RegisterDtoValidator();
            ValidationResult result = validator.Validate(registerDto);

            if (!result.IsValid)
            {
                // Validation hatalarını döndürüyoruz
                //var errorMessages = string.Join(" | ", result.Errors.Select(x => x.ErrorMessage));
                //throw new ArgumentException("Geçersiz giriş: " + errorMessages);
            }

            // 2. Aynı e-posta ile kullanıcı var mı kontrol et
            var existingUser = _userDal.GetByFilter(u => u.Email == registerDto.Email);
            if (existingUser != null)
            {
                throw new InvalidOperationException("Bu e-posta adresi zaten kayıtlı.");
            }

            // 3. Şifreyi hashle
            HashingHelper.CreatePasswordHash(registerDto.Password, out byte[] passwordHash, out byte[] passwordSalt);

            // 4. "User" rolünü al
            var userRole = _rolesDal.GetByFilter(r => r.RoleName == "User");
            if (userRole == null)
            {
                throw new InvalidOperationException("Varsayılan kullanıcı rolü bulunamadı.");
            }

            // 5. Kullanıcıyı oluştur
            var user = new User
            {
                Id = Guid.NewGuid(),
                Username = registerDto.Username,
                Email = registerDto.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                RoleId = userRole.Id
            };

            _userDal.Add(user);
        }

        public Token Login(LoginDto loginDto)
        {
            // Kullanıcıyı bul
            var user = _userDal.GetByFilter(u => u.Email == loginDto.Email);
            if (user == null)
                throw new UnauthorizedAccessException("E-posta veya şifre hatalı.");

            // Şifreyi doğrula
            bool isPasswordValid = HashingHelper.VerifyPasswordHash(loginDto.Password, user.PasswordHash, user.PasswordSalt);
            if (!isPasswordValid)
                throw new UnauthorizedAccessException("E-posta veya şifre hatalı.");

            // Token üreticiyi kullan
            var tokenHandler = new TokenHandler(_configuration); // IConfiguration enjekte edilmeli
            var token = tokenHandler.CreateAccessToken(user);

            return token;
        }



    }
}
