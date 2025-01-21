using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicLecture.Entities.Dtos.Lecture
{
    public class LectureCreateUpdateDto
    {
        public required string UniversityId { get; set; } = "";

        [MinLength(5)]
        [MaxLength(500)]
        public required string Name { get; set; } = "";

        [MinLength(5)]
        [MaxLength(500)]
        public required string LecturerName { get; set; } = "";

        [MinLength(5)]
        [MaxLength(500)]
        public required string Place { get; set; } = "";

        [MinLength(5)]
        [MaxLength(500)]
        public required string Time { get; set; } = "";

        [Range(1, 500)]
        public required int Capacity { get; set; }
    }
}
