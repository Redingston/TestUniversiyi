using AutoMapper;
using DAL.Exceptions;
using DAL.Helpers;
using DAL.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DAL.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginViewModel>
    {
        private readonly IAppDbContext _dbContext;
        private readonly IMapper _mapper;

        public LoginCommandHandler(IAppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<LoginViewModel> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users
                .SingleOrDefaultAsync(x =>
                        x.Email.ToUpper() == request.Email.ToUpper(), cancellationToken: cancellationToken)
                .ConfigureAwait(false);

            if (user == null)
            {
                throw new ValidationException();
            }

            byte[] hashBytes = Convert.FromBase64String(user.Password);

            PasswordHash hash = new PasswordHash(hashBytes);

            if (!hash.Verify(request.Password))
                throw new ValidationException();

            var role = await _dbContext.Roles.SingleOrDefaultAsync(x => x.Id == user.RoleId);

            var claims = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, role.Name),
                new Claim(ClaimTypes.Name, user.FirstName),
                new Claim(ClaimTypes.GivenName, user.UniversityId.ToString())
            };
            var token = AuthHelpers.GenerateToken(request.ApiKey, claims);

            await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return new LoginViewModel
            {
                Token = token,
                Role = role.Name
            };
        }
    }
}
