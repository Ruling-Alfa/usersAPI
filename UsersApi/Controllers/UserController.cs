using Infrastructure.Caching;
using Infrastructure.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using UsersApi.Domain;
using UsersApi.ViewModel;

namespace UsersApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        //private readonly ILogger<UserController> _logger;
        private readonly IUserDomain _userDomain;
        private readonly ILogging _consoleLogger;

        public UserController(ILogger<UserController> logger, IUserDomain userDomain,
            IFactory<IConsoleLoggingFactory> factory)
        {
            //_logger = logger;
            _userDomain = userDomain;
            _consoleLogger = factory.Create().GetLogger();
        }

        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            _consoleLogger.LogInfo("Executed Get endpoint for Users Controller");
            return await _userDomain.GetAllUser();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<User>>> Get([FromRoute] int id)
        {
            var user = await _userDomain.GetUser(id);
            if (user is null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] User user)
        {
            user.Id = 0;
            var newUser = await _userDomain.AddUser(user);
            return CreatedAtAction(nameof(Get), new { user.Id }, user);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] User user)
        {
            await _userDomain.UpdateUser(user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            await _userDomain.DeleteUser(id);
            return NoContent();
        }
    }
}
