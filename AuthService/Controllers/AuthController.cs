using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductService.Models;
using Microsoft.Extensions.Configuration;
using AuthService.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;


namespace AuthService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        RegistationDb register;

        private IConfiguration _config;

        //public LoginController(IConfiguration config)
        //{
        //	_config = config;
        //}
        public AuthController(IConfiguration config)
        {
            register = new RegistationDb();
            _config = config;
            
        }


        //public IActionResult Index()
        //{
        //    return View(register);
        //}

        

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(register);
        }

        [HttpPost]
        public IActionResult Register([FromBody] Registration model)
        {
            register.Add(model);
            return Ok(register);
        }
        //[HttpGet]
        //public IActionResult Login()
        //{
        //    return View();
        //}

        [HttpPost]
        public IActionResult Login(LoginUser login)
        {
            IActionResult response = Unauthorized();
            var user = AuthenticateUser(login);

            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString });
            }

            return response;
        }

        private string GenerateJSONWebToken(LoginUser userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }




        private LoginUser AuthenticateUser(LoginUser login)
        {
            LoginUser user = new LoginUser();
            var name = register.Find(x => x.Email == login.Email);
            //Validate the User Credentials    
            //Demo Purpose, I have Passed HardCoded User Information    
            if (name.Email == login.Email)
            {
                user = new LoginUser { Email = login.Email, Password = login.Password };
            }
            return user;
        }


        //[HttpGet]
        //public IActionResult GetProducts()
        //{

        //    return View();
        //}

    }
}
