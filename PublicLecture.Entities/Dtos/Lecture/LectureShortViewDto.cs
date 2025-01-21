using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicLecture.Entities.Dtos.Lecture
{
    public class LectureShortViewDto
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public string LecturerName { get; set; } = "";
        public string Place { get; set; } = "";
        public string Time { get; set; } = "";
        public string Capacity { get; set; } = "";
    }
}
