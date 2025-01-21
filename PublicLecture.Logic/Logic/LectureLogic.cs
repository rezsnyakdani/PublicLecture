using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PublicLecture.Data;
using PublicLecture.Entities.Dtos.Lecture;
using PublicLecture.Entities.Dtos.University;
using PublicLecture.Entities.Models;
using PublicLecture.Logic.Helpers;

namespace PublicLecture.Logic.Logic
{
    public class LectureLogic
    {
        Repository<Lecture> repo;
        DtoProvider dtoProvider;

        public LectureLogic(Repository<Lecture> repo, DtoProvider dtoProvider)
        {
            this.repo = repo;
            this.dtoProvider = dtoProvider;
        }

        public IEnumerable<LectureShortViewDto> GetAllLectures()
        {
            return repo.GetAll().Select(x => dtoProvider.Mapper.Map<LectureShortViewDto>(x));

        }

        public void AddLecture(LectureCreateUpdateDto dto, string userId)
        {
            var lec = dtoProvider.Mapper.Map<Lecture>(dto);
            lec.UserId = userId;
            repo.Create(lec);
        }

        public void DeleteLecture(string id)
        {
            repo.DeleteById(id);
        }

        public void UpdateLecture(string id, LectureCreateUpdateDto dto)
        {
            var old = repo.FindById(id);
            dtoProvider.Mapper.Map(dto, old);
            repo.Update(old);
        }

        public LectureViewDto GetLecture(string id)
        {
            var lec = repo.FindById(id);
            return dtoProvider.Mapper.Map<LectureViewDto>(lec);
        }
    }
}
