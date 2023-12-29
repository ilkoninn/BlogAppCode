using BlogApp.Business.DTOs.AccountDTOs;
using BlogApp.Business.DTOs.CategoryDTOs;
using BlogApp.Core.Entities.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Services.InternalServices.Intefaces
{
    public interface IAccountService
    {
        Task<IList<ReadUserDTO>> ReadAsync();
        Task<Dictionary<string, string>> RegisterAsync(RegisterDTO entity);

        Task<TokenResponeDTO> LoginAsync(LoginDTO entity);
    }
}
