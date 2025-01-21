using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PublicLecture.Data;
using PublicLecture.Entities.Models;
using PublicLecture.Entities.Helpers;
using PublicLecture.Entities.Dtos.University;
using PublicLecture.Logic.Logic;
using Microsoft.AspNetCore.Authorization;


namespace PublicLecture.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UniversityController : ControllerBase
    {
        UniversityLogic logic;        
        public UniversityController(UniversityLogic logic)
        {
            this.logic = logic;
        }
        
        [HttpPost]
        [Authorize]
        [Authorize(Roles = "Admin")]
        public void AddUniversity(UniversityCreateUpdateDto dto)
        {
            logic.AddUniversity(dto);   
        }

        [HttpGet]
        public IEnumerable<UniversityShortViewDto> GetUniversities()
        {
            return logic.GetAllUniversities();
        }

        [HttpDelete("{id}")]
        [Authorize]
        [Authorize(Roles = "Admin")]
        public void DeleteUniversity(string id)
        {
            logic.DeleteUniversity(id);
        }

        [HttpPut("{id}")]
        [Authorize]
        [Authorize(Roles = "Admin")]
        public void UpdateUniversity(string id, [FromBody] UniversityCreateUpdateDto dto)
        {
            logic.UpdateUniversity(id, dto);
        }

        [HttpGet("{id}")]
        public UniversityViewDto GetUniversity(string id)
        {
            return logic.GetUniversity(id);
        }

    }
}
