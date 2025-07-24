using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IUserService
    {
        void SaveUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
        List<User> GetAllUsers();
        User? GetUserById(int id);
        User? GetUserByEmail(string email);
    }
}
