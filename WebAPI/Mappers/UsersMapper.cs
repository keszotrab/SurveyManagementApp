using Azure.Identity;
using Infrastructure;
using Infrastructure.EF.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Dto;

namespace WebAPI.Mappers
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

