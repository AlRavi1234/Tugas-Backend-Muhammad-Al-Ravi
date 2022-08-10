using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using TugasMinggu1.Helpers;
using TugasMinggu1.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TugasMinggu1.Domain;
using TugasMinggu1.Data;
using TugasMinggu1.Data.DAL;
using Microsoft.EntityFrameworkCore;

namespace TugasMinggu1.Services
{
    public interface IUserService:ICrud<User>
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        //IEnumerable<User> GetAll();
        User GetById(int id);
        Task<User> Insert (User obj);
    }
    public class UserService : IUserService
    {
        /*private List<User> _users = new List<User>
        {
            new User { Id = 1, FirstName = "Test", LastName = "User", Username = "test", Password = "test" }
        };*/
     

        private readonly AppSettings _appSettings;
        private readonly SwordContext _context;

        public UserService(IOptions<AppSettings> appSettings,SwordContext context)
        {
            _appSettings = appSettings.Value;
            _context = context;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _context.Users.SingleOrDefault(x => x.Username == model.Username && x.Password == model.Password);

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            var results = await _context.Users.OrderBy(s => s.Id).ToListAsync();
            return results;
        }

        //public async IEnumerable<User> GetAll()
        // {
        //     return _context.Users;
        //  }

        public User GetById(int id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }

        public Task<IEnumerable<User>> GetByName()
        {
            throw new NotImplementedException();
        }

        public async Task<User> Insert(User obj)
        {
            try
            {

                _context.Users.Add(obj);

                await _context.SaveChangesAsync();
                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }

        }

        public async Task<User> Update(User obj)
        {
            try
            {
                var updateUser = await _context.Users.FirstOrDefaultAsync(s => s.Id == obj.Id);
                if (updateUser == null) throw new Exception($"data samurai dengan id {obj.Id}tidak ditemukan");
                updateUser.FirstName = obj.FirstName;
                updateUser.LastName = obj.LastName;
                updateUser.Username = obj.Username;
                updateUser.Password=obj.Password;

                 await _context.SaveChangesAsync();
                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        private string generateJwtToken(User user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

     

        Task<User> ICrud<User>.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
