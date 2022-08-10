using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TugasMinggu1.Data;
using TugasMinggu1.Domain;
using TugasMinggu1.Models;
using TugasMinggu1.Services;
using AutoMapper;


using TugasMinggu1.DTO;

namespace TugasMinggu1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
       private readonly IMapper _mapper;

        public UsersController(IUserService userService,IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
            
            
            
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });
            return Ok(response);
        }
       
        //insert
        [HttpPost("New User")]
        public async Task<ActionResult> Post(UserDTO userDTO)
        {
            try
            {
               // var newUser = _mapper.Map<User>(userDTO);
               /* var newUser = new User
                {   //Id=userDTO.Id,
                    FirstName = userDTO.FirstName,
                    LastName = userDTO.LastName,
                    Username=userDTO.Username,
                    Password=userDTO.Password
                };
                var result = await _userService.Insert(newUser);
                var userRead = new UserReadDTO
                {
                    Id=result.Id,
                    FirstName = result.FirstName,
                    LastName = result.LastName,
                    Username = result.Username,
                    Password = result.Password

                };*/
                var newUser = _mapper.Map<User>(userDTO);
                var result = await _userService.Insert(newUser);
                var userRead = _mapper.Map<User>(result);

                
                return Ok(userRead);
               
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //update
        [HttpPut("Update User")]
        public async Task<ActionResult> Put(UserReadDTO userReadDTO)
        {
            try
            {
             /*  var updateUser = new User
                {
                    Id = userReadDTO.Id,
                    FirstName = userReadDTO.FirstName,
                    LastName = userReadDTO.LastName,
                    Username = userReadDTO.Username,
                    Password = userReadDTO.Password
                };
                var result = await _userService.Update(updateUser);
                var userRead = new UserReadDTO
                {
                    Id = result.Id,
                    FirstName = result.FirstName,
                    LastName = result.LastName,
                    Username = result.Username,
                    Password = result.Password

                };*/
               var updateUser = _mapper.Map<User>(userReadDTO);
                var result = await _userService.Update(updateUser);
                return Ok(userReadDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //getuser
        [HttpGet]
        //get pakai mapper
        public async Task<IEnumerable<User>> GetAll()
        {

            var results = await _userService.GetAll();
            var userDTO = _mapper.Map<IEnumerable<User>>(results);

            return userDTO;
        }
    }
}
