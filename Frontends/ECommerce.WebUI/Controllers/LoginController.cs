using ECommerce.DtoLayer.IdentityDtos.LoginDtos;
using ECommerce.WebUI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IIdentityService _identityService;

        public LoginController(IHttpClientFactory httpClientFactory, IIdentityService identityService)
        {
            _httpClientFactory = httpClientFactory;
            _identityService = identityService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(SignInDto signInDto)
        {
            await _identityService.SignIn(signInDto);
            return RedirectToAction("Index", "User");
        }

        public async Task<IActionResult> SignIn(SignInDto signInDto)
        {
            signInDto.Username = "berkant";
            signInDto.Password = "123456aA*";

            await _identityService.SignIn(signInDto);
            return RedirectToAction("Index", "User");
        }
    }
}
