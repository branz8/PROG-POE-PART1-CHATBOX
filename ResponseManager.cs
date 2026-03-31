using System;
using System.Collections.Generic;

namespace CybersecurityChatbot
{
    public class ResponseManager
    {
        private Dictionary<string, string> _keywordResponses;
        private Random _random;

        public ResponseManager()
        {
            _random = new Random();
            InitializeResponses();
        }

        private void InitializeResponses()
        {
            _keywordResponses = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                // Greetings
                { "how are you", "I'm functioning well, thank you for asking! How can I help you stay safe online today?" },
                { "what's your purpose", "My purpose is to educate and raise awareness about cybersecurity best practices to help protect you online!" },
                { "what can i ask", GetHelpResponse() },
                
                // Password safety
                { "password", "🔐 Password Safety Tips:\n   • Use strong passwords with at least 12 characters\n   • Include uppercase, lowercase, numbers, and symbols\n   • Never reuse passwords across different sites\n   • Use a password manager to store passwords securely\n   • Enable two-factor authentication whenever possible" },
                
                // Phishing
                { "phish", "🎣 Phishing Awareness:\n   • Never click suspicious links in emails or messages\n   • Verify sender email addresses carefully\n   • Look for spelling errors and urgent language\n   • Don't share personal information via email\n   • When in doubt, contact the organization directly through official channels" },
                
                // Safe browsing
                { "brows", "🌐 Safe Browsing Practices:\n   • Look for 'https://' in website URLs\n   • Avoid using public Wi-Fi for sensitive transactions\n   • Keep your browser updated\n   • Use ad-blockers and privacy extensions\n   • Clear cookies and cache regularly" },
                
                // General cybersecurity
                { "cyber", "🛡️ Cybersecurity Basics:\n   • Keep all software updated\n   • Use antivirus software\n   • Backup important data regularly\n   • Be cautious of what you share online\n   • Use unique passwords for each account" }
            };
        }

        public string GetResponse(string userInput)
        {
            string lowerInput = userInput.ToLower();

            // Check each keyword
            foreach (var keyword in _keywordResponses.Keys)
            {
                if (lowerInput.Contains(keyword.ToLower()))
                {
                    return _keywordResponses[keyword];
                }
            }

            // Check for questions about specific topics
            if (lowerInput.Contains("how") || lowerInput.Contains("what") || lowerInput.Contains("why"))
            {
                return GetGeneralCybersecurityTip();
            }

            // Default response for unrecognized input
            return GetDefaultResponse();
        }

        public string GetHelpResponse()
        {
            return "📚 I can help you with:\n" +
                   "   • Password safety tips\n" +
                   "   • Phishing awareness\n" +
                   "   • Safe browsing practices\n" +
                   "   • General cybersecurity advice\n\n" +
                   "You can ask questions like:\n" +
                   "   - 'Tell me about passwords'\n" +
                   "   - 'What is phishing?'\n" +
                   "   - 'How to browse safely?'\n" +
                   "   - 'What's your purpose?'\n\n" +
                   "Type 'exit' or 'quit' to leave the conversation.";
        }

        private string GetGeneralCybersecurityTip()
        {
            string[] tips = {
                "💡 Did you know? 81% of data breaches are caused by weak or stolen passwords. Always use strong, unique passwords!",
                "💡 Never share your passwords with anyone, even if they claim to be from IT support!",
                "💡 Enable two-factor authentication wherever possible - it adds an extra layer of security!",
                "💡 Always verify email senders before clicking links - phishing attacks are becoming increasingly sophisticated!",
                "💡 Keep your software updated - updates often include important security patches!"
            };

            return tips[_random.Next(tips.Length)];
        }

        private string GetDefaultResponse()
        {
            string[] defaultResponses = {
                "I'm not sure I understand. Could you ask about password safety, phishing, or safe browsing?",
                "That's a good question! I specialize in cybersecurity topics like passwords, phishing, and safe browsing.",
                "I'd love to help with that! Try asking me about password safety, phishing protection, or secure browsing tips.",
                "Let me help you with cybersecurity! You can ask me about passwords, phishing, or how to browse safely online."
            };

            return defaultResponses[_random.Next(defaultResponses.Length)];
        }
    }
}