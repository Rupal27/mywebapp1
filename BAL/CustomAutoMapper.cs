using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DAL.Domain;
using Shared_Library.DTO;

namespace BAL
{
    public class CustomAutoMapper
    {
        IMapper Mapper;

    public CustomAutoMapper()
    {
        MapperConfiguration config = new MapperConfiguration(cfg =>
        {
            
            cfg.CreateMap<User, LoginUserDTO>().ReverseMap();

        });

        Mapper = config.CreateMapper();
    }


    public List<LoginUserDTO> UserToLoginUserDTOList(List<User> houselist)
    {
        return Mapper.Map<List<LoginUserDTO>>(houselist);
    }

    public List<User> LoginUserDTOListToUserList(List<LoginUserDTO> houselist)
    {
        return Mapper.Map<List<User>>(houselist);
    }

    public LoginUserDTO UserToLoginUserDTO(User houselist)
    {
        return Mapper.Map<LoginUserDTO>(houselist);
    }
    public User LoginUserDTOToUser(LoginUserDTO houselist)
    {
        return Mapper.Map<User>(houselist);
    }
}
}
