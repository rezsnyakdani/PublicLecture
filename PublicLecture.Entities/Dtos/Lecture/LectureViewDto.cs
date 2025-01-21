using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PublicLecture.Entities.Dtos.Participant;
using PublicLecture.Entities.Models;

namespace PublicLecture.Entities.Dtos.Lecture
{
    public class LectureViewDto
    {
        public string Id { get; set; } = "";
        public string CreatorUserName { get; set; } = "";
        public string Name { get; set; } = "";
        public string LecturerName { get; set; } = "";
        public string Place { get; set; } = "";
        public string Time { get; set; } = "";
        public string Capacity { get; set; } = "";
        public IEnumerable<ParticipantViewDto>? Participants { get; set; }

    }
}
