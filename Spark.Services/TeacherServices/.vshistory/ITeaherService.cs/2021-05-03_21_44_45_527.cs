﻿using Spark.Domain.Dto;
using Spark.Domain.Dto.CreateModels;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Spark.Services.TeacherServices
{
   public interface ITeaherService
    {
        Task<List<ApplicationUserDto>> GetAllEmployeeAsync();
        Task<bool> CreateAsync(ApplicationUserCreateModel model);
        Task<ApplicationUserCreateModel> FindUserAsync(ClaimsPrincipal claimsPrincipal);
    }
}
