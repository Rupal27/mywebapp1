using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Domain;
using DAL.InterfaceRepo;
using Shared_Library.DTO;
using Shared_Library.Interface;

namespace BAL.BusinessLogic
{
    public class BusinessLogicUser : IBusinessUser
    {
        readonly DatabaseContext context;
        IUserRepos house;
        readonly CustomAutoMapper mapper;

        public BusinessLogicUser(IUserRepos _house)
        {
            mapper = new CustomAutoMapper();
            house = _house;

        }

        public bool Delete(int id)
        {
            house.Delete(id);
            return true;
        }

        public LoginUserDTO Get(int UserID)
        {
            User user = new User();
            return mapper.UserToLoginUserDTO(house.GetObjectByID(UserID));
        }

        public List<LoginUserDTO> GetAll()
        {

            List<User> list = new List<User>();
            return mapper.UserToLoginUserDTOList(house.GetAll());

        }


        public bool Insert(LoginUserDTO value)
        {
            User val = new User();
            val = mapper.LoginUserDTOToUser(value);
            val.CreatedOn = DateTime.Now;
            val.ModifiedOn = DateTime.Now;

            house.Insert(val);
            return true;
        }

        public bool Update(LoginUserDTO value)
        {
            User val = new User();
            val = mapper.LoginUserDTOToUser(value);
            val.ModifiedOn = DateTime.Now;
            val.CreatedOn = DateTime.Now;
            house.Update(val);
            return true;
        }

        public LoginUserDTO LoginUser(LoginUserDTO login)
        {
            //bool value;
            User evt = new User();
            evt.CreatedOn = DateTime.Now;
            evt.ModifiedOn = DateTime.Now;
            LoginUserDTO loginedUser = new LoginUserDTO();
            evt = mapper.LoginUserDTOToUser(login);
            var lists = house.Find(temp => (temp.Email == evt.Email && temp.Password == evt.Password)).ToList();
            if (lists.Count != 0)
            {
                loginedUser.Email = lists[0].Email;
                loginedUser.ID = lists[0].ID;
                loginedUser.FullName = lists[0].FullName;
                
            }
            else
            {
                loginedUser = null;
            }
            return loginedUser;
        }

    }
}
