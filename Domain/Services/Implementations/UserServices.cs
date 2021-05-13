using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using Domain.Services.Interfaces;
using Domain.ViewModel;
using Shared.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Implementations
{
    public class UserServices : BaseService, IUserServices
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UserServices(
            IUserRepository repository, 
            IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }


        public async Task Insert(UserInsertViewModel model)
        {
            User entity = _mapper.Map<User>(model);
            await _repository.InsertAsync(entity);
        }
    }
}
