using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tcc1_api.Dtos.Conta;
using tcc1_api.Interfaces;
using tcc1_api.Models;
using Microsoft.AspNetCore.Authorization;
using tcc1_api.Extensions;

namespace tcc1_api.Controllers
{
    [Route("api/conta")]
    [ApiController]
    public class ContaController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<AppUser> _signInManager;
        public ContaController(UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _signInManager = signInManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == loginDTO.Email);

                if(user == null)
                {
                    return Unauthorized("Login inválido.");
                }

                var result = await _signInManager.CheckPasswordSignInAsync(user, loginDTO.Password, false);

                if(!result.Succeeded)
                {
                    return Unauthorized("Login inválido.");
                }

                return Ok(
                    new NewUserDTO
                    {
                        UserName = user.UserName,
                        Email = user.Email,
                        FullName = user.FullName,
                        Token = _tokenService.CreateToken(user)
                    }
                );
            }catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO registerDTO)
        {
            try
            {
                if(!ModelState.IsValid){
                    return BadRequest(ModelState);
                }

                var appUser = new AppUser
                {
                    FullName = registerDTO.FullName ?? throw new ArgumentNullException(nameof(registerDTO.FullName)),
                    UserName = registerDTO.Email,
                    Email = registerDTO.Email
                };

                if (string.IsNullOrEmpty(registerDTO.Password))
                {
                    return BadRequest("Password cannot be null or empty.");
                }

                var createdUser = await _userManager.CreateAsync(appUser, registerDTO.Password);

                if(createdUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(appUser, "User");
                    if(roleResult.Succeeded)
                    {
                        return Ok(
                            new NewUserDTO
                            {
                                UserName = appUser.UserName,
                                Email = appUser.Email,
                                FullName = appUser.FullName,
                                Token = _tokenService.CreateToken(appUser)
                            }
                        );
                    }
                    else
                    {
                        return BadRequest(roleResult.Errors);
                    }
                }
                else
                {
                    return BadRequest(createdUser.Errors);
                }
            }catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("update")]
        [Authorize]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserDTO updateUserDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                // Get the current user
                var username = User.GetUsername();
                var user = await _userManager.FindByNameAsync(username);

                if (user == null)
                {
                    return NotFound("User not found");
                }

                bool needsUpdate = false;
                
                // Update email if provided
                if (!string.IsNullOrEmpty(updateUserDTO.Email) && updateUserDTO.Email != user.Email)
                {
                    // Check if email is already in use
                    var existingUser = await _userManager.FindByEmailAsync(updateUserDTO.Email);
                    if (existingUser != null)
                    {
                        return BadRequest("Email is already in use");
                    }

                    user.Email = updateUserDTO.Email;
                    user.UserName = updateUserDTO.Email; // Also update username since it's the same as email
                    user.NormalizedEmail = updateUserDTO.Email.ToUpper();
                    user.NormalizedUserName = updateUserDTO.Email.ToUpper();
                    needsUpdate = true;
                }

                // Update full name if provided
                if (!string.IsNullOrEmpty(updateUserDTO.FullName) && updateUserDTO.FullName != user.FullName)
                {
                    user.FullName = updateUserDTO.FullName;
                    needsUpdate = true;
                }

                // Update password if both current and new passwords are provided
                if (!string.IsNullOrEmpty(updateUserDTO.CurrentPassword) && !string.IsNullOrEmpty(updateUserDTO.NewPassword))
                {
                    var changePasswordResult = await _userManager.ChangePasswordAsync(user, updateUserDTO.CurrentPassword, updateUserDTO.NewPassword);
                    if (!changePasswordResult.Succeeded)
                    {
                        return BadRequest(changePasswordResult.Errors);
                    }
                }
                
                // Save changes if any field was updated
                if (needsUpdate)
                {
                    var updateResult = await _userManager.UpdateAsync(user);
                    if (!updateResult.Succeeded)
                    {
                        return BadRequest(updateResult.Errors);
                    }
                }

                // Return updated user info with a new token
                return Ok(new NewUserDTO
                {
                    UserName = user.UserName,
                    Email = user.Email,
                    FullName = user.FullName,
                    Token = _tokenService.CreateToken(user)
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}