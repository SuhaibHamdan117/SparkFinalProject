﻿using Microsoft.AspNetCore.Identity;
using Spark.Domain.Dto;
using Spark.Domain.Dto.CreateModels;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Spark.DB.Models.IdentityModels;
using PatientRegistrySystem.DB.Contexts;

namespace Spark.DB.Repositories.AplicationUserRepository
{
    public class AplicationUserRepository : IAplicationUserRepository
    {
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public AplicationUserRepository(IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<IdentityResult> CreateUserAsync(ApplicationUserCreateModel model)
        {
            var newAcount = _mapper.Map<ApplicationUser>(model.ApplicationUser);
            var result = await _userManager.CreateAsync(newAcount, model.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(newAcount, model.UserRole);
            }
            return result;
        }

        public async Task<ApplicationUserDto> FindUserAsync(ClaimsPrincipal claimsPrincipal)
        {
            return _mapper.Map<ApplicationUserDto>(await _userManager.GetUserAsync(claimsPrincipal));
        }
    }
}
