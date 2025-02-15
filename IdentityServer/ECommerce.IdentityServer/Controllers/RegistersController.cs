using ECommerce.IdentityServer.Dtos;
using ECommerce.IdentityServer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace ECommerce.IdentityServer.Controllers
{
    //[Authorize(LocalApi.PolicyName)]
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class RegistersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public RegistersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> UserRegister(UserRegisterDto userRegisterDto)
        {
            var values = new ApplicationUser()
            {
                Name = userRegisterDto.Name,
                Surname = userRegisterDto.Surname,
                UserName = userRegisterDto.Username,
                Email = userRegisterDto.Email
            };

            var result = await _userManager.CreateAsync(values, userRegisterDto.Password);

            if (result.Succeeded)
            {
                return Ok("Kullanıcı eklendi.");
            }
            else
            {
                return Ok("Kullanıcı eklenirken bir hata oluştu.");
            }
        }
    }
}
