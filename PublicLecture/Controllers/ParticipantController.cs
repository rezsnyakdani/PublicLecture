using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PublicLecture.Entities.Dtos.Lecture;
using PublicLecture.Entities.Dtos.Participant;
using PublicLecture.Logic.Logic;

namespace PublicLecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantController : ControllerBase
    {
        ParticipantLogic logic;
        UserManager<IdentityUser> userManager;


        public ParticipantController(ParticipantLogic logic, UserManager<IdentityUser> userManager)
        {
            this.logic = logic;
            this.userManager = userManager;
        }

        [HttpPost]
        [Authorize]
        public async Task AddParticipant(ParticipantCreateUpdateDto dto)
        {
            var user = await userManager.GetUserAsync(User);

            logic.AddParticipant(dto, user.Id);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteParticipant(string id)
        {
            var user = await userManager.GetUserAsync(User);
            var participant = logic.GetParticipant(id);

            if (participant == null)
            {
                return NotFound(new { Message = "Participant not found" });
            }

            var isAdmin = User.IsInRole("Admin");

            if (!isAdmin && participant.CreatorUserName != user.UserName)
            {
                return Unauthorized(new { Message = "Nincs jogosultsága törölni ezt a résztvevőt" });
            }

            logic.DeleteParticipant(id);
            return Ok(new { Message = "Participant deleted successfully" });
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateParticipant(string id, [FromBody] ParticipantCreateUpdateDto dto)
        {
            var user = await userManager.GetUserAsync(User);
            var participant = logic.GetParticipant(id);

            if (participant == null)
            {
                return NotFound(new { Message = "Participant not found" });
            }

            var isAdmin = User.IsInRole("Admin");

            if (!isAdmin && participant.CreatorUserName != user.UserName)
            {
                return Unauthorized(new { Message = "Nincs jogosultsága módosítani ezt a résztvevőt" });
            }

            logic.UpdateParticipant(id, dto);
            return Ok(new { Message = "Participant updated successfully" });
        }
    }
}
