using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TechCodeLib.DTOS;
using TechCodeLib.Services.Contract;
using static TechCodeLib.Infrastructure.Common.Constants;
using System.Text;

namespace TechCodeLibAPI.Controllers
{
    https://localhost/api/appUsers/Token
        {
            userName: ""
            password: ""
        }
    [Route("api/[controller]")]
    [ApiController]
    public class AppUsersController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IAppUserService _appUserService;
        public AppUsersController(IConfiguration configuration, IAppUserService appUserService)
        {
            _appUserService = appUserService;
            _configuration = configuration;
        }

        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await _appUserService.GetAppUserDTOs());
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Token")]
        public async Task<IActionResult> Post([FromBody] TechCodeLibLoginDTO loginDto)
        {            
            if (ModelState.IsValid)
            {
                await _appUserService.GetAppUserDTOs();
                /*
                 
                var loggedInAppUser = await _service.GetUser(loginDto);
                if (loggedInAppUser == null)
                {
                    _logger.Error($"Unauthorized login attempt {loginDto.Username}");
                    return Unauthorized();
                }
                _logger.Information($"User logged in {loginDto.Username}");

                bool isadmin = await _userAffiliateManger.IsAdmin(loginDto);

                */

                var loggedInAppUser = new LoggedInAppUser();
                DateTime expiry = DateTime.UtcNow.AddHours(24);

                loggedInAppUser.CurrentTokenExpiry = expiry;
                var token = GetToken(loginDto.Username, expiry, false);
                //loggedInAppUser.Roles = new string[] { Web.ROLE_AFFILIATE_PARTNER };
                loggedInAppUser.Token = new JwtSecurityTokenHandler().WriteToken(token);
                loggedInAppUser.IsAdmin = false;
                return Ok(loggedInAppUser);
            }
            return BadRequest();
        }

        private JwtSecurityToken GetToken(string userName, DateTime expiry, bool isAdmin)
        {
            var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Sub, userName),
                    //new Claim(ClaimTypes.Role, Web.ROLE_AFFILIATE_PARTNER ),
                    //new Claim(Web.CLAIM_ALLOWED_AFFILIATE, allowedAffiliates)
                };

            if (isAdmin)
                claims.Add(new Claim("", ""));

            var token = new JwtSecurityToken
            (
                issuer: _configuration[WebConfig.TOKEN_ISSUER],
                audience: _configuration[WebConfig.TOKEN_AUDIENCE],
                claims: claims,
                expires: expiry,
                notBefore: DateTime.UtcNow,
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration[WebConfig.TOKEN_SIGNING_KEY])),
                     SecurityAlgorithms.HmacSha256)
            );

            return token;
        }
    }
}
