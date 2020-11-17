using AutoMapper;
using AutoMapper.QueryableExtensions;
using DAL.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DAL.Queries.Teachers.GetTeachersProfileInfo
{
    public class GetTeacherProfileInfoQuery : IRequest<TeacherProfileInfoVM>
    {
        public long Id;
        public class GetTeacherProfileInfoQueryHandler : IRequestHandler<GetTeacherProfileInfoQuery, TeacherProfileInfoVM>
        {
            private readonly IAppDbContext _dbContext;
            private readonly IMapper _mapper;

            public GetTeacherProfileInfoQueryHandler(IAppDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }
            public async Task<TeacherProfileInfoVM> Handle(GetTeacherProfileInfoQuery request, CancellationToken cancellationToken)
            {
                TeacherProfileInfoVM teacher = await _dbContext.Teachers
                    .ProjectTo<TeacherProfileInfoVM>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(x => x.UserId == request.Id);

                return teacher;
            }
        }
    }
}
