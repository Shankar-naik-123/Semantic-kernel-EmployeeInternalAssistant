using EmployeeAI.AI.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;

namespace EmployeeAI.Application.Services
{
    public class ChatService
    {
        private readonly ConversationStore _conversationStore;

        public ChatService(ConversationStore conversationStore)
        {
            _conversationStore = conversationStore;
        }

        public async Task<string> GetResponseAsync(string message, string ConversationId, CancellationToken cancellationToken = default)
        {
            var chatHistory = await _conversationStore.GetConversationAsync(ConversationId);
            chatHistory.AddUserMessage(message);
            var kernel = KernelFactory.Create();
            var chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();
            var response = await chatCompletionService.GetChatMessageContentsAsync(chatHistory: chatHistory, kernel: kernel, cancellationToken: cancellationToken);
            var res = response[0]?.Content ?? string.Empty;
            chatHistory.AddAssistantMessage(res);
            return res;
        }
    }
}
