using AutoMapper;
using BlogApp.Business.DTOs.AccountDTOs;
using BlogApp.Business.DTOs.CategoryDTOs;
using BlogApp.Business.Exceptions.Common;
using BlogApp.Business.Services.ExternalServices.Interfaces;
using BlogApp.Business.Services.InternalServices.Intefaces;
using BlogApp.Core.Entities.Account;
using BlogApp.DAL.Context;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Http.Timeouts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Services.InternalServices.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ITokenService _service;

        public AccountService(UserManager<AppUser> userManager, IMapper mapper, AppDbContext context, ITokenService service)
        {
            _userManager = userManager;
            _mapper = mapper;
            _context = context;
            _service = service;
        }

        public async Task<IList<ReadUserDTO>> ReadAsync()
        {
            var result = await _context.Users.ToListAsync();

            var query = _mapper.Map<IList<ReadUserDTO>>(result);

            return query;
        }
        public async Task<TokenResponeDTO> LoginAsync(LoginDTO entity)
        {
            AppUser user = await _userManager.FindByEmailAsync(entity.UsernameOrEmail)
                ?? await _userManager.FindByNameAsync(entity.UsernameOrEmail);

            if (user == null) throw new ObjectNotFoundException();
            if (!await _userManager.CheckPasswordAsync(user, entity.Password)) throw new ObjectNotFoundException();

            return await _service.CreateTokenAsync(user);
        }

        public async Task<Dictionary<string, string>> RegisterAsync(RegisterDTO entity)
        {
            AppUser user = _mapper.Map<AppUser>(entity);
            var result = _userManager.CreateAsync(user, entity.Password).Result;

            var messages = new Dictionary<string, string>();

            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    messages.Add(item.Code, item.Description);
                }
            }
            else
            {
                messages.Add("Operation", "User created successfully!");
            }

            return messages;
        }
    }
}
