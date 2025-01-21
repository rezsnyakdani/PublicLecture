using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PublicLecture.Entities.Dtos.Lecture;
using PublicLecture.Entities.Models;

namespace PublicLecture.Entities.Dtos.University
{
    public class UniversityViewDto
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public int LectureCount => Lectures?.Count() ?? 0;
        public IEnumerable<LectureShortViewDto>? Lectures { get; set; }

    }
}
