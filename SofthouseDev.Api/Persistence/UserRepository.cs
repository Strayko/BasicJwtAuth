using SofthouseDev.Api.Managers;
using SofthouseDev.Api.Models;
using SofthouseDev.Api.Models.Request;
using SofthouseDev.Api.Models.Response;

namespace SofthouseDev.Api.Persistence
{
    public class UserRepository : IUserRepository
    {
        private static readonly List<User> _users = new();

        public UserProfile Authenticate(LoginClient request)
        {
            var user = _users.FirstOrDefault(u => u.Email == request.Email);
            if (user == null) return null;

            var password = JwtCredentials.EncodeAndHash(request.Password);
            if (password != user.Password) return null;

            var token = JwtManager.GenerateToken(user);

            var result = new UserProfile(
                user.Email,
                user.FirstName,
                user.LastName,
                token);

            return result;
        }

        public UserProfile Registration(RegisterClient request)
        {
            var hashPassword = JwtCredentials.EncodeAndHash(request.Password);

            var user = new User
            {
                Id = Guid.NewGuid(),
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password = hashPassword,
                Phone = request.Phone,
                Active = true,
                CreatedAt = DateTime.UtcNow
            };

            _users.Add(user);

            var token = JwtManager.GenerateToken(user);

            var result = new UserProfile(
                user.Email,
                user.FirstName,
                user.LastName,
                token);

            return result;
        }
    }
}
