using MediatR;
using System.Runtime.Serialization;

namespace DAL.Commands.Login
{
    public sealed class LoginCommand : IRequest<LoginViewModel>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        [IgnoreDataMember]
        public string ApiKey { get; set; }
    }
}
