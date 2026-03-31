using System;
using System.Threading.Tasks;

namespace CybersecurityChatbot
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Title = "Cybersecurity Awareness Bot";

            // Initialize the chatbot
            Chatbot chatbot = new Chatbot();

            // Start the chatbot
            await chatbot.StartAsync();
        }
    }
}