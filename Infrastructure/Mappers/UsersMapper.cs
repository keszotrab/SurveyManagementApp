using Azure.Identity;
using Infrastructure.Dto;
using Infrastructure.EF.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Infrastructure.Mappers
{
    public static class UsersMapper
    {
        public static UsersEntity FromDtoToUserEntity(UserRegisterDto user)
        {
            return new UsersEntity()
            {
                UserName = user.Username,
                Email = user.Email,
            };
        }
    }
}

