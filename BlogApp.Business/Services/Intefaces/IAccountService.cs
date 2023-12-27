using BlogApp.Core.Entities.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Services.Intefaces
{
    public interface IAccountService
    {
        Task Register();
    }
}
