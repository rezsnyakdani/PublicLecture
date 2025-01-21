using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PublicLecture.Data;
using PublicLecture.Entities.Dtos.University;
using PublicLecture.Entities.Models;
using PublicLecture.Logic.Helpers;

namespace PublicLecture.Logic.Logic
{
    public class UniversityLogic
    {
        Repository<University> repo;
        DtoProvider dtoProvider;

        public UniversityLogic(Repository<University> repo, DtoProvider dtoProvider)
        {
            this.repo = repo;
            this.dtoProvider = dtoProvider;
        }

        public void AddUniversity(UniversityCreateUpdateDto dto)
        {
            University uni = dtoProvider.Mapper.Map<University>(dto);
            if (repo.GetAll().FirstOrDefault(x => x.Name == uni.Name) == null)
            {
                repo.Create(uni);
            }
            else
            {
                throw new ArgumentException("Ilyen névvel már létezik egyetem!");
            }
        }

        public IEnumerable<UniversityShortViewDto> GetAllUniversities()
        {
            return repo.GetAll().Select(x => dtoProvider.Mapper.Map<UniversityShortViewDto>(x));

        }

        public void DeleteUniversity(string id)
        {
            repo.DeleteById(id);
        }

        public void UpdateUniversity(string id, UniversityCreateUpdateDto dto)
        {
            var old = repo.FindById(id);
            dtoProvider.Mapper.Map(dto, old);
            repo.Update(old);
        }

        public UniversityViewDto GetUniversity(string id)
        {
            var uni = repo.FindById(id);
            return dtoProvider.Mapper.Map<UniversityViewDto>(uni);
        }

    }
}
