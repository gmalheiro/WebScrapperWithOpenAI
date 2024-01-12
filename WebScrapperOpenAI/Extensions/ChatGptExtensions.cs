using OpenAI_API;

namespace WebScrapperOpenAI.Extensions
{
    public static class ChatGptExtensions
    {
        public static WebApplicationBuilder AddChatGpt(this WebApplicationBuilder builder)
        {
            var chat = new OpenAIAPI("YOUR_OPENAI_API_KEY");
            builder.Services.AddSingleton(chat);
            return builder;
        }
    }
}
