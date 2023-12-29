using BlogApp.Business.DTOs.AccountDTOs;
using BlogApp.Core.Entities.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Services.ExternalServices.Interfaces
{
    public interface ITokenService
    {
        Task<TokenResponeDTO> CreateTokenAsync(AppUser user, int expireMin = 60);
    }
}
