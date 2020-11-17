using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DAL.Queries.Teachers.GetTeachersProfileInfo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class TeachersController : ApiController
    {
        [HttpGet("[action]")]
        [Authorize(Roles = "teacher")]
        public async Task<ActionResult<TeacherProfileInfoVM>> GetTeacherById()
        {
            long userId = long.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return Ok(await Mediator.Send(new GetTeacherProfileInfoQuery { Id = userId }));
        }
    }
}
