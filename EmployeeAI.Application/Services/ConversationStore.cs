using Microsoft.SemanticKernel.ChatCompletion;

namespace EmployeeAI.Application.Services
{
    public  class ConversationStore
    {
        public readonly Dictionary<string,ChatHistory> conversations=new Dictionary<string, ChatHistory>();

        public async Task<ChatHistory> GetConversationAsync(string conversationId)
        {
            if (conversations.TryGetValue(conversationId, out var chatHistory))
            {
                return chatHistory;
            }
            else
            {
                var newChatHistory = new ChatHistory();
                newChatHistory.AddSystemMessage("You are employee assistant. answer in 3 lines");
                conversations[conversationId] = newChatHistory;
                return newChatHistory;
            }
        }
    }
}
