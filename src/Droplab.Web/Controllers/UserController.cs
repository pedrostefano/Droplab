using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Droplab.Data;
using Droplab.Data.Models;
using Droplab.Data.Repositories.Interfaces;
using Droplab.VO.ViewModels;
using Droplab.Web.Helpers;
using Droplab.Web.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Droplab.Web.Controllers
{
    [Authorize]
    [Route("/api/user")]
    public class UserController : BaseController<User, UserVO>
    {

        private readonly IAuthenticationService _authService;
        private readonly AppSettings _appSettings;


        public UserController(IUserRepository repository, IUnitOfWork unitOfWork, IOptions<AppSettings> appSettings, IAuthenticationService authService) : base(repository, unitOfWork)
        {
            _appSettings = appSettings.Value;
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody]UserVO userVO){
            
            var user = await _authService.Authenticate(userVO.Username, userVO.Password);

            if (user == null)
                return Unauthorized();

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] 
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            // return basic user info (without password) and token to store client side
            return Ok(new {
                Id = user.Id,
                Username = user.Username,
                FirstName = user.Name,
                LastName = user.LastName,
                Token = tokenString
            });
        }


        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]UserVO userVO)
        {
            var user = await _repository.ToEntity(userVO);

            try 
            {
                // save 
                await _authService.CreateUser(user, userVO.Password);
                return Ok();
            } 
            catch(Exception ex)
            {
                // return error message if there was an exception
                return BadRequest(ex.Message);
            }
        }

        public override Task<IActionResult> Delete(long id)
        {
            throw new System.NotImplementedException();
        }

        public override Task<IActionResult> Get(long id)
        {
            throw new System.NotImplementedException();
        }

        public override Task<IActionResult> GetAll(int offset, int limit)
        {
            throw new System.NotImplementedException();
        }

        public override Task<IActionResult> CreateOrEdit([FromBody] UserVO vo)
        {
            throw new NotImplementedException();
        }
    }
}