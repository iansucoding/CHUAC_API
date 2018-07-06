using CHUACSystem.Data.Models;
using CHUACSystem.Repo;
using CHUACSystem.Service.Interfaces;
using CHUACSystem.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CHUACSystem.Service
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _repository;

        public UserService(IRepository<User> repository)
        {
            _repository = repository;
        }

        protected UserView ConvertToViewModel(User entity) => new UserView
        {
            Id = entity.Id,
            Email = entity.Email,
        };

        public UserView SignIn(string account, string password)
        {
            return _repository.GetQueryable()
                .Where(user => user.Email == account && user.Password == password)
                .Select(user=> ConvertToViewModel(user))
                .FirstOrDefault();
        }

        public UserView GetById(long id)
        {
            var user = _repository.GetById(id);
            if(user != null)
            {
                return ConvertToViewModel(user);
            }
            return null;
        }

        //以下用不到
        public ReturnVM Create(UserBase model)
        {
            throw new NotImplementedException();
        }

        public ReturnVM Delete(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserView> Find(Func<User, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserView> GetAll()
        {
            throw new NotImplementedException();
        }



        public ReturnVM Update(UserView model)
        {
            throw new NotImplementedException();
        }


    }
}
