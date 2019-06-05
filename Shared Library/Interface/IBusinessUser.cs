using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared_Library.DTO;

namespace Shared_Library.Interface
{
    public interface IBusinessUser
    {
        LoginUserDTO Get(int UserID);
        List<LoginUserDTO> GetAll();
        bool Insert(LoginUserDTO value);
        bool Update(LoginUserDTO value);
        bool Delete(int id);
        LoginUserDTO LoginUser(LoginUserDTO login);

    }
}
