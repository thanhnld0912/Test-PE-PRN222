using BusinessLogic.Models;
using Repositories;
using Services;
using System.Collections.Generic;

namespace Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService()
        {
            userRepository = new UserRepository();
        }

        public void SaveUser(User user) => userRepository.SaveUser(user);

        public void UpdateUser(User user) => userRepository.UpdateUser(user);

        public void DeleteUser(int id) => userRepository.DeleteUser(id);

        public List<User> GetAllUsers() => userRepository.GetAllUsers();

        public User? GetUserById(int id) => userRepository.GetUserById(id);

        public User? GetUserByEmail(string email) => userRepository.GetUserByEmail(email);
    }
}
