using System.Security.Claims;
using System.Text;
using AdvancedDevSample.Domain.Entities;
using Microsoft.IdentityModel.Tokens; // Ajouté pour SymmetricSecurityKey
using System.IdentityModel.Tokens.Jwt; // Ajouté pour JwtSecurityTokenHandler et SecurityTokenDescriptor

namespace AdvancedDevSample.Application.Services
{
    public class AuthService
    {

        private readonly List<AppUser> _users;

        private readonly string _jwtSecret;

        public AuthService(string jwtSecret)
        {
            _jwtSecret = jwtSecret;
            _users = new List<AppUser>
            {
                new AppUser("admin", "admin", "Admin"), // exemple
                new AppUser("user", "user", "User")
            };
        }

        public string Authenticate(string username, string password)
        {
            var user = _users.FirstOrDefault(u => u.Username == username && u.VerifyPassword(password));
            if (user == null) throw new UnauthorizedAccessException("Utilisateur ou mot de passe incorrect.");

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSecret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}
