using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using Domain.Services.Interfaces;
using Domain.ViewModel;
using Shared.Domain.Services;
using Shared.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Implementations
{
    public class UserServices : CrudService<User,UserInsertViewModel>, IUserServices
    {
        public UserServices(
            IUserRepository repository,
            IMapper mapper):base(repository,mapper)
        {
        }


        public override Task Insert(UserInsertViewModel model)
        {
<<<<<<< HEAD
            User entity = _mapper.Map<User>(model);

            await _repository.InsertAsync(entity);
=======
            model.Password = Encript.GetPasswordEncripted(model.Password);
            return base.Insert(model);
>>>>>>> 18a35065dcda8686c17a751511eaca6bf8e9357b
        }
        public string Login(UserLoginViewModel model)
        {
            User entity = _mapper.Map<User>(model);
            var query = _repository.GetQuery();
            var password = Encript.GetPasswordEncripted(model.Password);
            User user = query.FirstOrDefault(e => e.Password.Equals(password));
            if (user == null) return null;
            return GetJwt(user);
        }
        private string GetJwt(User user)
        {
            return "jwt";
        }
    }
}
