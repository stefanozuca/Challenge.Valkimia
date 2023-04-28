﻿using Challenge.Valkimia.Application.DTOs;
using Challenge.Valkimia.Application;
using Challenge.Valkimia.Common;
using Microsoft.Extensions.Logging;
using Challenge.Valkimia.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;

namespace Challenge.Valkimia.Infrastructure.Services
{
    public class UserAuthenticationService : IUserAuthenticationService
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<UserAuthenticationService> _logger;

        public UserAuthenticationService(ILogger<UserAuthenticationService> logger, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
        }

        public async Task<Result<string>> Login(LoginRequestDTO loginRequest)
        {
            var serviceResult = new Result<string>();
            try
            {
                var applicationUser = await _userManager.FindByEmailAsync(loginRequest?.Email);
                var validationResult = ValidateUserForLogin(applicationUser);
                if (validationResult.Failed)
                    return validationResult;

                return await SignInUser(applicationUser, loginRequest);
            }
            catch (Exception ex)
            {
                ServicesHelper.HandleServiceError(ref serviceResult, _logger, ex, "Error while trying to sign in user.");
            }
            return serviceResult;
        }

        public async Task<Result> Logout()
        {
            var serviceResult = new Result<string>();
            try
            {
                await _signInManager.SignOutAsync();
                serviceResult.Successful().WithMessage("Successfully logged out.");
            }
            catch (Exception ex)
            {
                ServicesHelper.HandleServiceError(ref serviceResult, _logger, ex, "Error while trying to sign out user.");
            }
            return serviceResult;
        }

        private Result<string> ValidateUserForLogin(ApplicationUser applicationUser)
        {
            var serviceResult = new Result<string>();
            if (applicationUser == null)
                return serviceResult.Failed().WithMessage("User not found.");

            if (applicationUser.IsActive == false)
                return serviceResult.Failed().WithMessage("User is not active.");
            return serviceResult;
        }

        private async Task<Result<string>> SignInUser(ApplicationUser applicationUser, LoginRequestDTO loginRequest)
        {
            var serviceResult = new Result<string>();
            var loginResult = await _signInManager.PasswordSignInAsync(applicationUser, loginRequest.Password, true, false);
            if (loginResult.Succeeded)
                serviceResult.Successful().WithData(applicationUser.UserName);
            else
                serviceResult.Failed().WithMessage($"Unable to login.");
            return serviceResult;
        }
    }
}
