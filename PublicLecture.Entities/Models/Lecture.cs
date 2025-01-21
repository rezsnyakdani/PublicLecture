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
    public class Lecture: IIdEntity
    {
        public Lecture(string name, string universityId, string lecturerName, string place, string time, int capacity)
        {
            UniversityId = universityId;
            Id = Guid.NewGuid().ToString();
            Name = name;
            LecturerName = lecturerName;
            Place = place;
            Time = time;
            Capacity = capacity;
        }

        [StringLength(50)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [StringLength(50)]
        public string UniversityId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string LecturerName { get; set; }

        [StringLength(50)]
        public string Place { get; set; }

        [StringLength(50)]
        public string Time { get; set; }

        [Range(1, 500)]
        public int Capacity { get; set; }

        [NotMapped]
        public virtual ICollection<Participant>? Participants { get; set; }

        [NotMapped]
        public virtual University? University { get; set; }

        [StringLength(50)]
        public string UserId { get; set; }

    }
}
