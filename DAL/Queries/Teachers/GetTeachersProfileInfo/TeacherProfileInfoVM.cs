using DAL.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DAL.Helpers.Mapping;

namespace DAL.Queries.Teachers.GetTeachersProfileInfo
{
    public class TeacherProfileInfoVM : IMapFrom<Teacher>
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Degree { get; set; }
        public string ImageUrl { get; set; }
        public string DateOfBirth { get; set; }
        public string GroupName { get; set; }
        public string UniversityName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Teacher, TeacherProfileInfoVM>()
                .ForMember(x => x.FirstName, opt => opt.MapFrom(x => x.User.FirstName))
                .ForMember(x => x.Surname, opt => opt.MapFrom(x => x.User.Surname))
                .ForMember(x => x.PhoneNumber, opt => opt.MapFrom(x => x.User.PhoneNumber))
                .ForMember(x => x.Email, opt => opt.MapFrom(x => x.User.Email))
                .ForMember(x => x.Degree, opt => opt.MapFrom(x => x.User.Teacher.Degree))
                .ForMember(x => x.ImageUrl, opt => opt.MapFrom(x => x.User.ImageUrl))
                .ForMember(x => x.DateOfBirth, opt => opt.MapFrom(x => x.User.DateOfBirth.ToString("yyyy-MM-dd")))
                .ForMember(
                    x => x.GroupName,
                    opts => opts.MapFrom(
                        x => x.Groupes.First().Number + " - " + x.Groupes.First().Character)
                )
                .ForMember(
                    x => x.UniversityName,
                    opt => opt.MapFrom(
                        x => x.User.University.ShortName));
        }
    }
}
