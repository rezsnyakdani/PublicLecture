using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PublicLecture.Entities.Dtos.Lecture;
using PublicLecture.Entities.Dtos.University;
using PublicLecture.Logic.Logic;

namespace PublicLecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LectureController : ControllerBase
    {
        LectureLogic logic;
        UserManager<IdentityUser> userManager;


        public LectureController(LectureLogic logic, UserManager<IdentityUser> userManager)
        {
            this.logic = logic;
            this.userManager = userManager;
        }

        [HttpPost]
        [Authorize]
        public async Task AddLecture(LectureCreateUpdateDto dto)
        {
            var user = await userManager.GetUserAsync(User);
            logic.AddLecture(dto, user.Id);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteLecture(string id)
        {
            var user = await userManager.GetUserAsync(User);
            var lecture = logic.GetLecture(id);

            if (lecture == null)
            {
                return NotFound(new { Message = "Lecture not found" });
            }

            var isAdmin = User.IsInRole("Admin");

            if (!isAdmin && lecture.CreatorUserName != user.UserName)
            {
                return Unauthorized(new { Message = "Nincs jogosultsága törölni ezt az előadást" });
            }

            logic.DeleteLecture(id);
            return Ok(new { Message = "Lecture deleted successfully" });
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateLecture(string id, [FromBody] LectureCreateUpdateDto dto)
        {
            var user = await userManager.GetUserAsync(User);
            var lecture = logic.GetLecture(id);

            if (lecture == null)
            {
                return NotFound(new { Message = "Lecture not found" });
            }

            var isAdmin = User.IsInRole("Admin");

            if (!isAdmin && lecture.CreatorUserName != user.UserName)
            {
                return Unauthorized(new { Message = "Nincs jogosultsága módosítani ezt az előadást" });
            }

            logic.UpdateLecture(id, dto);
            return Ok(new { Message = "Lecture updated successfully" });
        }

        [HttpGet("{id}")]
        public LectureViewDto GetLecture(string id)
        {
            return logic.GetLecture(id);
        }
    }
}
