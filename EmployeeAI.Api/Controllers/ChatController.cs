using EmployeeAI.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAI.Api.Controllers
{
    [ApiController]
    [Route("api/chat")]
    public class ChatController : ControllerBase
    {
        private readonly ChatService _chatService;

        public ChatController(ChatService chatService)
        {
            _chatService = chatService;
        }

        [HttpPost]
        public async Task<IActionResult> Chat([FromBody] ChatRequest request)
        {
            var response = await _chatService.GetResponseAsync(
                request.Message, request.ConversationId);

            return Ok(response);
        }
    }
}
