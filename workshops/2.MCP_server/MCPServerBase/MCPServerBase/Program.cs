using Microsoft.Extensions.AI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModelContextProtocol.Server;
using System.ComponentModel;

var builder = Host.CreateApplicationBuilder(args);
builder.Logging.AddConsole(consoleLogOptions =>
{
    // Configure all logs to go to stderr
    consoleLogOptions.LogToStandardErrorThreshold = LogLevel.Trace;
});
builder.Services
    .AddMcpServer()
    .WithStdioServerTransport()
    .WithToolsFromAssembly();
await builder.Build().RunAsync();

[McpServerToolType]
public static class TestTools
{
    [McpServerTool, Description("Echoes the message back to the client.")]
    public static string Echo(string message) => $"hello {message}";

    [McpServerTool(Name = "add"), Description("Adds two numbers.")]
    public static string Add(int a, int b) => $"The sum of {a} and {b} is {a + b}";

    [McpServerTool(Name = "randomPersonaRewrite"), Description("Get a rewrite from a random persona.")]
    public static async Task<string> RandomPersonaRewrite(
       IMcpServer server,
       [Description("The message to rewrite")] string message,
       CancellationToken cancellationToken)
    {
        // Choose a random persona and instruct the model to answer in that style
        var personas = new (string Name, string Instruction)[]
        {
            ("pirate", "You are a salty sea pirate. Speak with nautical slang like 'Arrr', keep it playful and thematic."),
            ("shakespearean bard", "You are an Elizabethan bard. Use archaic diction and poetic flourish."),
            ("robot", "You are a helpful robot. Be precise, concise, and technical; use bullet points when useful. And end message with Beeep!"),
            ("noir detective", "You are a 1940s noir detective. Be gritty, metaphorical, and moody."),
            ("surfer", "You are a laid-back surfer. Use surfer slang and keep the vibe chill."),
            ("professor", "You are a wise professor. Provide clear, structured, and instructive explanations."),
            ("toddler", "You are a curious toddler. Keep sentences short, simple, and playful."),
            ("motivational coach", "You are a motivational coach. Be encouraging, energetic, and action-oriented.")
        };

        var (personaName, instruction) = personas[Random.Shared.Next(personas.Length)];

        ChatMessage[] messages =
        [
            new(ChatRole.System, instruction),
            new(ChatRole.User, message),
        ];

        ChatOptions options = new()
        {
            MaxOutputTokens = 256,
            Temperature = 0.7f,
        };

        var response = await server.AsSamplingChatClient().GetResponseAsync(messages, options, cancellationToken);
        return $"Persona: {personaName}\n{response}";
    }
}
