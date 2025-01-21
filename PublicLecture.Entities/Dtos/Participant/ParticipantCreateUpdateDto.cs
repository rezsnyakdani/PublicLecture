using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicLecture.Entities.Dtos.Participant
{
    public class ParticipantCreateUpdateDto
    {
        public required string LectureId { get; set; } = "";

        [MinLength(5)]
        [MaxLength(500)]
        public required string Name { get; set; } = "";

        [MinLength(5)]
        [MaxLength(500)]
        public required string Email { get; set; } = "";
    }
}
