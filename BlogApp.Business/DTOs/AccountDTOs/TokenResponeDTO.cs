using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.DTOs.AccountDTOs
{
    public record TokenResponeDTO
    {
        public string Token {  get; set; }
        public string Username { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
