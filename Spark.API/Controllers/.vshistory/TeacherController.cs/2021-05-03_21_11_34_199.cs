﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Spark.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class TeacherController : Controller
    {
        private readonly IMapper _mapper;

        public TeacherController(IMapper mapper)
        {
            this._mapper = mapper;
        }
    }
}
