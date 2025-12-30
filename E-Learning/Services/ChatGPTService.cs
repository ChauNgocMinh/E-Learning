using System.Text.Json;
using OpenAI.Chat;
using E_Learning.Models;
using E_Learning.ViewModel;

namespace E_Learning.Services;

public class IeltsWritingService
{
    private readonly ChatClient _client;

    public IeltsWritingService(string apiKey)
    {
        _client = new ChatClient("gpt-4o-mini", apiKey);
    }

    public async Task<WritingResultViewModel> EvaluateAsync(string prompt, string essay)
    {
        var messages = new List<ChatMessage>
        {
            new SystemChatMessage(IeltsExaminerPersona.SystemPrompt),

            new UserChatMessage($$"""
Essay prompt:
{{prompt}}

Student essay:
{{essay}}
""")
        };

        var response = await _client.CompleteChatAsync(messages);

        var text = response.Value.Content.FirstOrDefault()?.Text;

        if (string.IsNullOrWhiteSpace(text))
            throw new Exception("AI returned empty response.");

        var start = text.IndexOf('{');
        var end = text.LastIndexOf('}');

        if (start == -1 || end == -1 || end <= start)
            throw new Exception("No valid JSON found in AI output.");

        var json = text[start..(end + 1)];

        var result = JsonSerializer.Deserialize<WritingResultViewModel>(
            json,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        if (result == null)
            throw new Exception("Failed to parse IELTS result.");

        return result;
    }
}
