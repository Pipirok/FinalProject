using FinalProject.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace FinalProject.lib
{
    public class UsersDAL
    {
        private static LaundryDBEntities db = DALC.dbEntryPoint;

        public static List<User> GetAllUsers()
        {
            return db.Users.ToList();
        }

        public static void DeleteUser(int ID)
        {
            User userToDelete = GetUserByUserID(ID);
            db.Users.Remove(userToDelete);
            db.SaveChanges();
        }

        public static User GetUserByUsername(string UserName)
        {
            List<User> usersWithUsername = db.Users.Where(u => u.UserName == UserName).ToList();
            return usersWithUsername.Count() == 0 ? null : usersWithUsername[0];
        }

        public static User GetUserByUserID(int UserID)
        {
            return db.Users.Find(UserID);
        }


        public static User Login(string UserName, string Password)
        {
            User userToLogin = GetUserByUsername(UserName);
            if (userToLogin == null) return null;

            if(Hasher.Verify(Password, userToLogin.Password)) return userToLogin;
            return null;
        }

        public static User AddUser(string UserName, string FullName, string Password)
        {
            db.AddUser(UserName, Hasher.Hash(Password), FullName);
            return db.Users.Find(db.Users.Where(u => u.UserName == UserName).First().UserID);
        }

        public static void UpdateUser(int UserID, string FullName)
        {
            User userToUpdate = GetUserByUserID(UserID);
            userToUpdate.FullName = FullName;
            db.SaveChanges();
        }

        public static void UpdateUser(int UserID, string FullName, string Password)
        {
            User userToUpdate = GetUserByUserID(UserID);
            userToUpdate.FullName = FullName;
            userToUpdate.Password = Hasher.Hash(Password);
            db.SaveChanges();
        }
    }
}