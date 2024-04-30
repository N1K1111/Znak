using Autorization.Core.Models;
using Autorization.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Autorization.Core.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly AuthService _service;

        public UserController(AuthService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        [HttpPost("savephoto", Name = "savephoto")]
        public async Task<IActionResult> SavePhoto([FromBody] SaveUserPhotoModel model)
        {
            await _service.SaveUserPhoto(model.UserId, model.ImagePath);
            return Ok();
        }

        [Authorize]
        [HttpPost("saveinfo", Name = "saveinfo")]
        public async Task<IActionResult> SaveInfo([FromBody] SaveUserInfoModel model)
        {
            try
            {
                await _service.SaveUserInfo(model.UserId, model.Email, model.Username, model.NewPass);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

            return Ok();
        }
    }
}
