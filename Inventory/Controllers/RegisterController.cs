using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IRegister  register;
        public RegisterController(IRegister register)
        {
            this.register = register;
        }

        [HttpPost]
        public async Task<IActionResult> Register ([FromForm]UserRegisterDTO model)
        {
            try
            {
                var res = await register.RegisterAsync(model);
                if (res.IsSuccessful)
                {
                    return Ok(res);
                }
                return BadRequest(res);
            }

            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
