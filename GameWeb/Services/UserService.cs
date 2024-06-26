﻿using GameWeb.Models;
using GameWeb.Repositories;

namespace GameWeb.Services
{
    public interface IUserService
    {
       Task<List<User>> GetUsers();
        Task<User> GetUserId(int id);
        Task<User> AddUser(string Usuario, string Password);
        Task<User> UpdateUser(int UserId, string? Usuario = null, string? Password= null);
        Task<User> DeleteUser(int id);
        Task<User> Authenticate(string username, string password);
        Task<User> Register(string username, string password);

    }
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<User>> GetUsers()
        {
            return await _userRepository.GetUsers();
        }

        public async Task<User> GetUserId(int id)
        {
            return await _userRepository.GetUserId(id);
        }

        public async Task<User> AddUser(string Usuario, string Password)
        {
            return await _userRepository.AddUser(Usuario, Password);
        }

        public async Task<User> UpdateUser(int UserId, string? Usuario = null, string? Password = null)
        {
            var user = await _userRepository.GetUserId(UserId);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            if (Usuario != null)
            {
                user.Usuario = Usuario;
            }
            if (Password != null)
            {
                user.Password = Password;
            }

            return await _userRepository.UpdateUser(user);
        }

        public async Task<User> DeleteUser(int id)
        {
            return await _userRepository.DeleteUser(id);
        }

        public async Task<User> Authenticate(string username, string password)
        {
            return await _userRepository.Authenticate(username, password);
        }

        public async Task<User> Register(string username, string password)
        {
            return await _userRepository.Register(username, password);
        }
    }
}
