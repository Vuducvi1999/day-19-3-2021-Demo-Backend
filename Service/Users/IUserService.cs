using Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Users
{
    public interface IUserService
    {
        public bool Login(LoginDto model);
        public SearrchPagingDto GetList(SearchUserDto searchModel);
    }
}
