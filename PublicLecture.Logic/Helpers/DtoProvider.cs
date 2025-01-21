using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using PublicLecture.Entities.Dtos.Lecture;
using PublicLecture.Entities.Dtos.Participant;
using PublicLecture.Entities.Dtos.University;
using PublicLecture.Entities.Dtos.User;
using PublicLecture.Entities.Models;

namespace PublicLecture.Logic.Helpers
{
    public class DtoProvider
    {
        UserManager<IdentityUser> userManager;

        public Mapper Mapper { get; }

        public DtoProvider(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<University, UniversityShortViewDto>()
                .AfterMap((src, dest) =>
                {
                    dest.LectureCount = src.Lectures?.Count ?? 0;
                });
                cfg.CreateMap<University, UniversityViewDto>();
                cfg.CreateMap<UniversityCreateUpdateDto, University>();
                cfg.CreateMap<LectureCreateUpdateDto, Lecture>();
                cfg.CreateMap<Lecture, LectureShortViewDto>()
                .AfterMap((src, dest) =>
                {
                    dest.Capacity = $"{src.Participants?.Count ?? 0}/{src.Capacity}";
                });
                cfg.CreateMap<Lecture, LectureViewDto>()
                .AfterMap((src, dest) =>
                {
                    dest.Capacity = $"{src.Participants?.Count ?? 0}/{src.Capacity}";
                })
                .AfterMap((src, dest) =>
                {
                    dest.CreatorUserName = userManager.Users.First(u => u.Id == src.UserId).UserName!;
                });
                cfg.CreateMap<ParticipantCreateUpdateDto, Participant>();
                cfg.CreateMap<Participant, ParticipantViewDto>()
                .AfterMap((src, dest) =>
                {
                    dest.CreatorUserName = userManager.Users.First(u => u.Id == src.UserId).UserName!;
                });
                cfg.CreateMap<IdentityUser, UserViewDto>()
                .AfterMap((src, dest) =>
                {
                    dest.IsAdmin = userManager.IsInRoleAsync(src, "Admin").Result;
                });


            });

            Mapper = new Mapper(config);
        }
    }
}
