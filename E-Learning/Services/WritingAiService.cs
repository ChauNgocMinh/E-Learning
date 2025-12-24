/*using E_Learning.Services;
using E_Learning.ViewModel;
using OpenAI;
using OpenAI.Chat;
using System.Text.Json;

public class WritingAiService : IWritingAiService
{
    private readonly OpenAIClient _client;

    public WritingAiService(IConfiguration config)
    {
        _client = new OpenAIClient(config["OpenAI:ApiKey"]);
    }

    public async Task<WritingResultViewModel> EvaluateEssay(string essay)
    {
        var response = await _client.GetChatClient("gpt-4o-mini")
            .CompleteAsync(
                [
                    ChatMessage.CreateSystemMessage(
                        "You are an IELTS examiner. Return JSON ONLY with fields: band, taskResponse, coherenceCohesion, lexicalResource, grammarRangeAccuracy, strengths, weaknesses, suggestions."
                    ),
                    ChatMessage.CreateUserMessage(essay)
                ]
            );

        var json = response.Content[0].Text;

        return JsonSerializer.Deserialize<WritingResultViewModel>(json)
               ?? new WritingResultViewModel();
    }
}
*/