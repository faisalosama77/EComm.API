using EComm.API.Infrastructure.Entities;
using EComm.API.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;


namespace EComm.API.Infrastructure.Implementation
{
    public class PasswordHash : IPasswordHash
    {
        public string HashPassword(string password)
        {
            string PasswordHash = BC.HashPassword(password);
            return PasswordHash;
        }

        public string SaltPassword(string hashedPassword)
        {
            string passSalt = hashedPassword.Substring(7, 29);
            return passSalt;
        }

        public bool Verify(string incomingPassword, string dbPassword)
        {
            if (BC.Verify(incomingPassword, dbPassword) == true)
            {
                return true;
            }
                return false;
        }
    }
}
