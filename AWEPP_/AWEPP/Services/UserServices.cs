﻿using AWEPP.Model;
using AWEPP.Modelo;
using AWEPP.Repositories;
using AWEPP.Services;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;

namespace AWEPP.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;
        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task CreateUserAsync(User Users)
        {
            await _userRepository.CreateUserAsync(Users);
        }

        public async Task<IEnumerable<User>> GetAllUserAsync()
        {
        return await _userRepository.GetAllUserAsync();
        }

        public async Task<User> GetUserByIdAsync(int Id)
        {
        return await _userRepository.GetUserByIdAsync(Id);
        }

        public async Task SoftDeleteUserAsync(int Id)
        {
        await _userRepository.SoftDeleteUserAsync(Id);
        }

        public async Task UpdateUserAsync(User Users)
        {
         await _userRepository.UpdateUserAsync(Users);
        }

        public async Task<User> LoginAsync(string email, string password)
        {
            // Buscar el usuario por correo electrónico
            var Users = await _userRepository.GetUserByEmailAsync(email);

            // Verificar si el usuario existe y no está eliminado
            if (Users == null || Users.IsDeleted)
            {
                return null;
            }

            // Comparar las contraseñas usando BCrypt
            if (!BCrypt.Net.BCrypt.Verify(password, Users.Passaword))
            {
                return null; // Si las contraseñas no coinciden, retornar nulo
            }

            return Users; // Retornar el usuario si las credenciales son correctas
        }
    }
}


