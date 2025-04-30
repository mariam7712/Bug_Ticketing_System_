using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bug_Ticketing_System_BL.DTOs
{
    public class LoginResponseDto
    {
        public string UserId { get; set; }
        public string Token { get; set; }
        public DateTime TokenExpiration { get; set; }

        public LoginResponseDto(string userId, string token, DateTime tokenExpiration)
        {
            UserId = userId;
            Token = token;
            TokenExpiration = tokenExpiration;
        }
    }

}
