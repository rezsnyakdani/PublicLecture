using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PublicLecture.Entities.Helpers;

namespace PublicLecture.Entities.Models
{
    public class Participant : IIdEntity
    {
        [StringLength(50)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [StringLength(50)]
        public string LectureId { get; set; }
        
        [StringLength(50)]
        public string Name { get; set; }
        
        [StringLength(50)]
        public string Email { get; set; }

        [NotMapped]
        public virtual Lecture? Lecture { get; set; }

        [StringLength(50)]
        public string UserId { get; set; }


        public Participant(string lectureId, string name, string email)
        {
            Id = Guid.NewGuid().ToString();
            LectureId = lectureId;
            Name = name;
            Email = email;
        }
    }
}
