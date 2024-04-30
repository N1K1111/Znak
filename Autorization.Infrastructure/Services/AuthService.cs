using Autorization.Domain.Entities;
using Autorization.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Autorization.Infrastructure.Services
{
    public class AuthService
    {
        private readonly IRepository<User> _repository;
        public AuthService(IRepository<User> repository)
        {
            _repository = repository;
        }
        public async Task<User> GetByEmailAsync(string email)
        {
            return await _repository.Get(email);
        }
        public async Task<List<User>> GetAllUsers()
        {
            var res = await _repository.GetAll();
            return (List<User>)res;
        }
        public async Task SaveUserPhoto(Guid id, string path)
        {
            var user = await _repository.Get(id);
            user.ImagePath = path;
            await _repository.Update(user);

        }
        public async Task SaveUserInfo(Guid id, string email, string username, string newpass)
        {
            var user = await _repository.Get(id);
            user.Username = username;
            user.Email = email;

            if (newpass != "***")
            {
                user.PasswordHash = await Hash(newpass);
            }

            await _repository.Update(user);
        }
        public async Task<List<User>> GetUsersByFilter(string filter)
        {
            return await _repository.GetByFilter(filter);
        }
        public async Task<User> GetByIdAsync(Guid id)
        {
            return await _repository.Get(id);
        }

        public async Task<User> CreateAsync(User user)
        {
            return await _repository.Create(user);
        }

        public async Task<string> Hash(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                var hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
                return hash;
            }
        }
    }
}
