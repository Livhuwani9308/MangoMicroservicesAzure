using Mango.Web.Models;
using Mango.Web.Services.IService;
using Mango.Web.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Mango.Web.Controllers
{
    [Route("Auth")]
    public class AuthController(IAuthService _authService) : Controller
    {
        [HttpGet("login")]
        public IActionResult Login()
        {
            LoginRequestDto loginRequestDto = new();
            return View(loginRequestDto);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestDto obj)
        {
            ResponseDto responseDto = await _authService.LoginAsync(obj);

            if (responseDto != null && responseDto.IsSuccess)
            {
                LoginResponseDto loginResponseDto = JsonConvert.DeserializeObject<LoginResponseDto>(responseDto.Result.ToString());
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("CustomError", responseDto.Message);
                return View(obj);
            }
        }

        [HttpGet("register")]
        public IActionResult Register()
        {
            var roleList = new List<SelectListItem>()
            {
                new() {Text=SD.RoleAdmin, Value=SD.RoleAdmin},
                new() {Text=SD.RoleCustomer, Value=SD.RoleCustomer}
            };
            ViewBag.RoleList = roleList;
            return View();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegistrationRequestDto obj)
        {
            ResponseDto result = await _authService.RegisterAsync(obj);
            ResponseDto assignRole;

            if (result != null && result.IsSuccess)
            {
                if (string.IsNullOrEmpty(obj.Role))
                {
                    obj.Role = SD.RoleCustomer;
                }
                assignRole = await _authService.AssignRoleAsync(obj);
                if (assignRole != null && assignRole.IsSuccess)
                {
                    TempData["success"] = "Registration Successful";
                    return RedirectToAction(nameof(Login));
                }
            }

            var roleList = new List<SelectListItem>()
            {
                new() {Text=SD.RoleAdmin, Value=SD.RoleAdmin},
                new() {Text=SD.RoleCustomer, Value=SD.RoleCustomer}
            };

            ViewBag.RoleList = roleList;
            return View(obj);
        }


        public IActionResult Logout()
        {
            return View();
        }
    }
}
