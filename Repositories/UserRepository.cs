using BusinessLogic.Models;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class UserRepository : IUserRepository
    {
        public void SaveUser(User user) => UserDAO.SaveUser(user);

        public void UpdateUser(User user) => UserDAO.UpdateUser(user);

        public void DeleteUser(int id) => UserDAO.DeleteUser(id);

        public List<User> GetAllUsers() => UserDAO.GetAllUsers();

        public User? GetUserById(int id) => UserDAO.GetUserById(id);

        public User? GetUserByEmail(string email) => UserDAO.GetUserByEmail(email);
    }
}
