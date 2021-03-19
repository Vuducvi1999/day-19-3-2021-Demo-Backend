using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities
{
    public class User 
    {
        [Key]
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public int Type { get; set; }


        public static List<User> GetUsers()
        {
            var users = new List<User>();
            for (int i = 0; i < 100; i++)
            {
                users.Add(new User() { Username = $"admin{(i + 1):3}", Password = "123456" });
            }
            return users;

        }

    }
}
