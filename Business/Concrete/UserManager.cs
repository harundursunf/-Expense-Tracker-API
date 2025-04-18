using Business.Abstract;
using Core.Utilities.Hashing;
using DataAccess.Abstract;
using Entities.Dto;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private  readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
     
        public void Add(UserDto userDto)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userDto.Password, out passwordHash, out passwordSalt);

            User user = new User
            {
                Id = Guid.NewGuid(),
                Username = userDto.Username,
                Email = userDto.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
             
            };
            _userDal.Add(user);
        }

    

        public void Delete(UserDto userDto)
        {
            throw new NotImplementedException();
        }

        public User GetById(Guid id)
        {
           return _userDal.GetById(id);
        }

        public List<User> GetList()
        {
            return _userDal.GetAll();
        }

        public void Update(UserDto userDto)
        {
            throw new NotImplementedException();
        }
    }
}
