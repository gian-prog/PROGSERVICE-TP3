﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TP3__FlappyBirb.Models;

namespace TP3__FlappyBirb.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        readonly UserManager<User> UserManager;
                 IConfiguration Config;

        public UsersController(UserManager<User> userManager, IConfiguration configuration)
        {
            this.UserManager = userManager;
            this.Config = configuration;
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterDTO register)
        {
            if (register.Password != register.PasswordConfirm)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                new { Message = "Les deux mots de passe spécifiés sont différents." });
            }

            User user = new User()
            {
                UserName = register.Username,
                Email = register.Email
            };

            IdentityResult identityResult = await this.UserManager.CreateAsync(user, register.Password);
            if (!identityResult.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                new { Message = "La création de l'utilisateur a échoué." });
            }
            return Ok();
        }
        [HttpPost]
        public async Task<ActionResult> Login(LoginDTO login)
        {
            User user = await UserManager.FindByNameAsync(login.Username);

            if (user != null && await UserManager.CheckPasswordAsync(user, login.Password))
            {
                IList<string> roles = await UserManager.GetRolesAsync(user);
                List<Claim> authClaims = new List<Claim>();

                foreach (string role in roles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, role));
                }

                authClaims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));

                SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Loo00ongue Phrase SiNoN Ça ne Marchera PaAaAAAaAas !"));

                JwtSecurityToken token = new JwtSecurityToken(
                    issuer: "https://localhost:7128",
                    audience: "http://localhost:4200",
                    claims: authClaims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
                );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    validTo = token.ValidTo
                });
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, new { Message = "Le nom d'utilisateur ou le mot de passe est invalide." });
            }
        }
    }
}
