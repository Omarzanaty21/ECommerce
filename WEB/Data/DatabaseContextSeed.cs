using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WEB.Models;

namespace WEB.Data
{
    public static class DatabaseContextSeed
    {
        public static void SeedData(DatabaseContext context)
        {
            using var hmac = new HMACSHA512();

            if (!context.Admins.Any())
            {
                var admin = new Admin();
                    admin.FirstName = "Abdelrahman";
                    admin.LastName = "Osama";
                    admin.Email = "admin@admin.com";
                    admin.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("admin"));
                    admin.PasswordSalt = hmac.Key;

                context.Admins.Add(admin);
                context.SaveChanges();
            }
        }
    }
}