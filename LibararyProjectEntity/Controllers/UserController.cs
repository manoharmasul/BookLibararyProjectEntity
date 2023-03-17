using LibararyProjectEntity.Model;
using LibararyProjectEntity.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibararyProjectEntity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUser(AddUser adduser)
        {
            var result=await userRepository.AddUser(adduser);

                return Ok(result);
            
            
        }
        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser(AddUser adduser)
        {
            var result = await userRepository.UpdateUser(adduser);
            if(adduser.Id==0)
            {
                return Ok("Invalid User Id");
            }

            return Ok(result);

        }
    }
}
