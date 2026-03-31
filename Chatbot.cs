using System;
using System.Threading.Tasks;

namespace CybersecurityChatbot
{
    public class Chatbot
    {
        private ResponseManager _responseManager;
        private VoiceGreeting _voiceGreeting;
        private ConversationLogger _logger;
        private string _userName;
        private bool _isRunning;

        public Chatbot()
        {
            _responseManager = new ResponseManager();
            _voiceGreeting = new VoiceGreeting();
            _logger = new ConversationLogger();
            _isRunning = true;
        }

        public async Task StartAsync()
        {
            try
            {
                // Display ASCII art logo
                UIHelper.DisplayAsciiLogo();

                // Play voice greeting
                _voiceGreeting.PlayGreeting();

                // Display welcome message
                UIHelper.DisplayWelcomeMessage();

                // Get user's name
                await GetUserNameAsync();

                // Main conversation loop
                await RunConversationLoopAsync();
            }
            catch (Exception ex)
            {
                UIHelper.DisplayError($"An error occurred: {ex.Message}");
            }
            finally
            {
                UIHelper.DisplayGoodbyeMessage(_userName);
                UIHelper.PauseBeforeExit();
            }
        }

        private async Task GetUserNameAsync()
        {
            while (string.IsNullOrWhiteSpace(_userName))
            {
                UIHelper.DisplayPrompt("May I have your name?");
                string input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input))
                {
                    _userName = input.Trim();
                    UIHelper.DisplayBotMessage($"Thank you, {_userName}! I'm excited to help you learn about cybersecurity.");
                    await Task.Delay(1000);
                }
                else
                {
                    UIHelper.DisplayWarning("I didn't catch that. Please tell me your name.");
                }
            }
        }

        private async Task RunConversationLoopAsync()
        {
            UIHelper.DisplayHelpMessage();

            while (_isRunning)
            {
                UIHelper.DisplayPrompt($"{_userName}, what would you like to know about?");
                string userInput = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(userInput))
                {
                    UIHelper.DisplayWarning("I didn't quite understand that. Could you rephrase?");
                    continue;
                }

                // Log user input
                _logger.LogEntry($"YOU: {userInput}");

                string response = await ProcessUserInputAsync(userInput);
                UIHelper.DisplayBotMessage(response);

                // Log bot response
                _logger.LogEntry($"BOT: {response}");

                // Check if user wants to exit
                if (userInput.Trim().ToLower() == "exit" || userInput.Trim().ToLower() == "quit")
                {
                    _isRunning = false;
                }
            }
        }

        private async Task<string> ProcessUserInputAsync(string input)
        {
            string lowerInput = input.ToLower().Trim();

            // Special local commands
            if (lowerInput == "save")
            {
                var path = _logger.SaveTranscript();
                return $"Conversation saved to: {path}";
            }

            if (lowerInput == "history")
            {
                return _logger.GetTranscriptPreview();
            }

            if (lowerInput.StartsWith("theme"))
            {
                var parts = lowerInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length > 1 && parts[1] == "dark")
                {
                    UIHelper.SetTheme(UIHelper.Theme.Dark);
                    return "Theme set to dark.";
                }
                UIHelper.SetTheme(UIHelper.Theme.Default);
                return "Theme set to default.";
            }

            // Check for exit commands
            if (lowerInput == "exit" || lowerInput == "quit")
            {
                return "It was great chatting with you! Stay safe online!";
            }

            // Check for help command
            if (lowerInput == "help" || lowerInput == "what can i ask")
            {
                return _responseManager.GetHelpResponse();
            }

            // Simulate typing effect for better UX
            await Task.Delay(500);

            // Get response based on input
            return _responseManager.GetResponse(input);
        }
    }
}