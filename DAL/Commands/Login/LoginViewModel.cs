using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Commands.Login
{
    public sealed class LoginViewModel
    {
        public string Token { get; set; }
        public string Role { get; set; }
    }
}
