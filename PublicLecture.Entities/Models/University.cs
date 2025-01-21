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
    public class University: IIdEntity
    {
        public University(string name)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
        }

        [StringLength(50)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [NotMapped]
        public virtual ICollection<Lecture>? Lectures { get; set; }
    }
}
