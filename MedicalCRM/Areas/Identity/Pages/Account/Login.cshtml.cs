// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using MedicalCRM.DataAccess.Entities.UserEntities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MedicalCRM.Models.UserModels;
using MedicalCRM.Business.Services.Interfaces;
using AutoMapper;
using MedicalCRM.Business.Models;
using MedicalCRM.DataAccess.Enums;

namespace MedicalCRM.Areas.Identity.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly IPatientManager _signInManager;
        private readonly ILogger<LoginModel> _logger;
        private readonly IMapper _mapper;

        public LoginModel(IPatientManager signInManager, ILogger<LoginModel> logger, IMapper mapper)
        {
            _signInManager = signInManager;
            _logger = logger;
            _mapper = mapper;
        }

        [BindProperty]
        public UserAuthorizationViewModel Input { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }
        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl ??= Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ReturnUrl = returnUrl;

            RedirectToAction("Login", "Patient");
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            if (ModelState.IsValid)
            {
                var user = _mapper.Map<UserDTO>(Input);
                var result = await _signInManager.LoginAsync(user, Input.RememberMe);
                if (result == UserType.Doctor)
                {
                    return RedirectToAction("Index", "Doctor");
                }
                if (result == UserType.Admin) {
                    return RedirectToAction("Index", "Admin");
                }

                if (result == UserType.Patient) {
                    return RedirectToAction("Index", "Patient");
                } else {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return Page();
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
