using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PublicLecture.Data;
using PublicLecture.Entities.Dtos.Lecture;
using PublicLecture.Entities.Dtos.Participant;
using PublicLecture.Entities.Models;
using PublicLecture.Logic.Helpers;

namespace PublicLecture.Logic.Logic
{
    public class ParticipantLogic
    {
        Repository<Participant> repo;
        Repository<Lecture> lecRepo;
        DtoProvider dtoProvider;

        public ParticipantLogic(Repository<Participant> repo, DtoProvider dtoProvider, Repository<Lecture> lecRepo)
        {
            this.repo = repo;
            this.dtoProvider = dtoProvider;
            this.lecRepo = lecRepo;
        }

        public void AddParticipant(ParticipantCreateUpdateDto dto, string userId)
        {
            var participant = dtoProvider.Mapper.Map<Participant>(dto);
            participant.UserId = userId;
            var lecture = lecRepo.GetAll().FirstOrDefault(x => x.Id == participant.LectureId);
            if (lecture.Participants?.Count() < lecture.Capacity)
            {
                repo.Create(participant);
            }
            else
            {
                throw new ArgumentException("Nem tudsz jelentkezni erre az előadásra, mert már betelt!");
            }
        }

        public void DeleteParticipant(string id)
        {
            repo.DeleteById(id);
        }

        public void UpdateParticipant(string id, ParticipantCreateUpdateDto dto)
        {
            var old = repo.FindById(id);
            dtoProvider.Mapper.Map(dto, old);
            repo.Update(old);
        }

        public ParticipantViewDto GetParticipant(string id)
        {
            var part = repo.FindById(id);
            return dtoProvider.Mapper.Map<ParticipantViewDto>(part);
        }
    }
}
