using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedDevSample.Domain.Entities
{
    public class AppUser
    {

        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Username { get; private set; }
        public string PasswordHash { get; private set; } // Stocker le hash, pas le mot de passe en clair
        public string Role { get; private set; } // ex: "Admin", "User"

        public AppUser(string username, string passwordHash, string role = "User")
        {
            Username = username;
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(passwordHash);
            Role = role;
        }

        public bool VerifyPassword(string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, PasswordHash);
        }

    }
}
