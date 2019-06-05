using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Domain;
using DAL.InterfaceRepo;
using Shared_Library.Interface;

namespace DAL.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepos
    {


        public UserRepository(IUnitofWork unit) : base(unit)
        {
            _unitofwork = unit;
        }
    }
}
