﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Spark.API.Controllers.ControllersHelper;
using Spark.API.ViewModel.Login;
using Spark.API.ViewModel.Register;
using Spark.DB.Models.IdentityModels;
using Spark.Domain.Dto.CreateModels;
using Spark.Services.StudentServices;
using Spark.Services.TeacherServices;
using System.Threading.Tasks;

namespace Spark.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IMapper _mapper;
        private readonly IStudentService _studentService;
        private readonly ITeaherService _teaherService;


        public AccountController(UserManager<ApplicationUser> userManager
             , SignInManager<ApplicationUser> signInManager
            , IMapper mapper,
            IStudentService studentService,
            ITeaherService teaherService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _studentService = studentService;
            _teaherService = teaherService;
        }


        [Route("[action]")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var currentUser = (await _userManager.FindByEmailAsync(model.Email));
                if (currentUser != null)
                {
                    await _signInManager.SignOutAsync();
                    var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
                    if (result.Succeeded)
                    {
                        return Ok(_mapper.Map<UserInitInfo>(await _userManager.FindByEmailAsync(model.Email)));
                    }
                    else
                    {
                        return BadRequest("Field to signing ");
                    }
                }
                else
                {
                    return BadRequest("Invalid Email or password");
                }
            }
            else
            {
                return BadRequest(ModelState.GetErrors());
            }
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }

        [Route("[action]")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterStudent([FromBody] RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _studentService.CreateAsync(_mapper.Map<ApplicationUserCreateModel>(model));
                if (result)
                {
                    return Ok("Created");
                }
                else
                {
                    return BadRequest("Bad Inputs");
                }
            }
            else
            {
                return BadRequest(ModelState.GetErrors());
            }
        }

        [Route("[action]")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterTeacher([FromBody] RegisterTeacherViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _teaherService.CreateAsync(_mapper.Map<ApplicationUserCreateModel>(model));
                if (result)
                {
                    return Ok("Created");
                }
                else
                {
                    return BadRequest("Bad Inputs");
                }
            }
            else
            {
                return BadRequest(ModelState.GetErrors());
            }
        }
    }
}
