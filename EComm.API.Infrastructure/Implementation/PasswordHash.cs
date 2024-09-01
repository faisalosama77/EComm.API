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
        public async Task<string> HashPassword(string password)
        {
            string PasswordHash = BC.HashPassword(password);
            await Task.CompletedTask;
            return PasswordHash;
        }

        public async Task<string> SaltPassword(string hashedPassword)
        {
            string passSalt = hashedPassword.Substring(7, 29);
            await Task.CompletedTask;
            return passSalt;
        }

        public async Task<bool> Verify(string incomingPassword, string dbPassword)
        {
            if (BC.Verify(incomingPassword, dbPassword) == true)
            {
                await Task.CompletedTask;
                return true;
            }
            else
            {
                await Task.CompletedTask;
                return false;
            }
        }
    }
}
