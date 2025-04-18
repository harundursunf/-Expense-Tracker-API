using Entities.Dto;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        void Add(UserDto userDto);
        void Update(UserDto userDto);
        void Delete(UserDto userDto);
        User GetById(Guid id);  
        List<User> GetList();


    }
}
