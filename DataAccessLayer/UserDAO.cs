using BusinessLogic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class UserDAO
    {
        public static List<User> GetAllUsers()
        {
            using var db = new InnocodeDbContext();
            return db.Users.ToList();
        }

        public static User? GetUserById(int id)
        {
            using var db = new InnocodeDbContext();
            return db.Users.FirstOrDefault(u => u.Id == id);
        }

        public static User? GetUserByEmail(string email)
        {
            using var db = new InnocodeDbContext();
            return db.Users.FirstOrDefault(u => u.Email == email);
        }

        public static void SaveUser(User user)
        {
            try
            {
                using var db = new InnocodeDbContext();
                db.Users.Add(user);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void UpdateUser(User user)
        {
            try
            {
                using var db = new InnocodeDbContext();
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void DeleteUser(int id)
        {
            try
            {
                using var db = new InnocodeDbContext();
                var user = db.Users.FirstOrDefault(u => u.Id == id);
                if (user != null)
                {
                    db.Users.Remove(user);
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
