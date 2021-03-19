using AutoMapper;
using Domain.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service.Users
{
    public class UserService : IUserService
    {
        private List<User> users;
        private IMapper _mapper;
        public UserService(IMapper mapper)
        {
            users = User.GetUsers();
            _mapper = mapper;
        }
        public SearrchPagingDto GetList(SearchUserDto searchModel)
        {
            if (searchModel != null)
            {
                var result = _mapper.Map<SearchUserDto, SearrchPagingDto>(searchModel);
                var data = users.Take(searchModel.Take).Skip(searchModel.PageSize).ToList();
                result.Data = _mapper.Map<List<User>, List<UserDto>>(data);
                result.TotalItems = users.Count();
                return result;
            }
            return new SearrchPagingDto();
        }

        public bool Login(LoginDto model)
        {
            var result = users.Any(t => t.Username == model.Username && t.Password == model.Password);
            return result;
        }
    }
}
