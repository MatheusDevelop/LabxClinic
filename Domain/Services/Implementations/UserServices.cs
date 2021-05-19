using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using Domain.Services.Interfaces;
using Domain.ViewModel;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Shared.Domain.Services;
using Shared.Utils;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Implementations
{
    public class UserServices : CrudService<User,UserInsertViewModel>, IUserServices
    {
        private readonly IConfiguration _config;

        public UserServices(
            IUserRepository repository,
            IMapper mapper, IConfiguration config) : base(repository, mapper)
        {
            _config = config;
        }


        public override Task Insert(UserInsertViewModel model)
        {
            model.Password = Encript.GetPasswordEncripted(model.Password, model.Email);
            return base.Insert(model);
        }
        public string Login(UserLoginViewModel model)
        {
            User entity = _mapper.Map<User>(model);
            var query = _repository.GetQuery();
            var password = Encript.GetPasswordEncripted(model.Password, model.Email);
            User user = query.FirstOrDefault(e => e.Password.Equals(password));
            if (user == null) return null;
            return GetJwt(user);
        }
        private string GetJwt(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Definimos nossas Claims (dados da sessão) para poderem ser capturadas
            // a qualquer momento enquanto o Token for ativo
            var claims = new Claim[] {

            };

            // Configuramos nosso Token e seu tempo de vida
            var token = new JwtSecurityToken
                (
                    _config["Jwt:Issuer"],
                    _config["Jwt:Issuer"],
                    claims,
                    expires: DateTime.Now.AddMinutes(120),
                    signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
