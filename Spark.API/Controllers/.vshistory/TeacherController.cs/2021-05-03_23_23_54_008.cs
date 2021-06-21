﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Spark.API.ViewModel.Users;
using Spark.Domain.Roles;
using Spark.Services.TeacherServices;
using System.Threading.Tasks;

namespace Spark.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class TeacherController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ITeaherService _teaherService;

        public TeacherController(IMapper mapper, ITeaherService teaherService)
        {
            _mapper = mapper;
            _teaherService = teaherService;
        }

        [Route("[action]")]
        [HttpGet]
        [Authorize(Roles = UserRoles.Student)]
        [Authorize(Roles = UserRoles.Teacher)]
        public async Task<IActionResult> getAllTeachers() {

            var result =  await _teaherService.GetAllUsersAsync();
            if (result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(new ListUsersViewModel
                {
                    ListOfUsers = result
                }) ;
            }
        }
    }
}
