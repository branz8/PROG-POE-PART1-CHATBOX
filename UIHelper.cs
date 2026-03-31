using System;
using System.Threading;

namespace CybersecurityChatbot
{
    public static class UIHelper
    {
        public enum Theme { Default, Dark }
        private static Theme _currentTheme = Theme.Default;

        public static void SetTheme(Theme theme)
        {
            _currentTheme = theme;
            switch (theme)
            {
                case Theme.Dark:
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                default:
                    Console.ResetColor();
                    break;
            }
        }

        public static void DisplayAsciiLogo()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            string logo = @"
    ╔═══════════════════════════════════════════════════════════════╗
    ║                                                               ║
    ║    ██████╗██╗   ██╗██████╗ ███████╗██████╗                     ║
    ║   ██╔════╝╚██╗ ██╔╝██╔══██╗██╔════╝██╔══██╗                    ║
    ║   ██║      ╚████╔╝ ██████╔╝█████╗  ██████╔╝                    ║
    ║   ██║       ╚██╔╝  ██╔══██╗██╔══╝  ██╔══██╗                    ║
    ║   ╚██████╗   ██║   ██████╔╝███████╗██║  ██║                    ║
    ║    ╚═════╝   ╚═╝   ╚═════╝ ╚══════╝╚═╝  ╚═╝                    ║
    ║                                                               ║
    ║           █████╗ ██╗    ██╗ █████╗ ██████╗ ███████╗           ║
    ║          ██╔══██╗██║    ██║██╔══██╗██╔══██╗██╔════╝           ║
    ║          ███████║██║ █╗ ██║███████║██████╔╝███████╗           ║
    ║          ██╔══██║██║███╗██║██╔══██║██╔══██╗╚════██║           ║
    ║          ██║  ██║╚███╔███╔╝██║  ██║██║  ██║███████║           ║
    ║          ╚═╝  ╚═╝ ╚══╝╚══╝ ╚═╝  ╚═╝╚═╝  ╚═╝╚══════╝           ║
    ║                                                               ║
    ║             E M E R I S  C Y B E R S E C U R I T Y   B O T    ║
    ║                                                               ║
    ╚═══════════════════════════════════════════════════════════════╝";

            Console.WriteLine(logo);
            Console.ResetColor();
            Thread.Sleep(1500);
        }

        public static void DisplayWelcomeMessage()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n" + new string('═', 60));
            Console.WriteLine("          WELCOME TO CYBERSECURITY AWARENESS BOT");
            Console.WriteLine(new string('═', 60));
            Console.ResetColor();
            Console.WriteLine();
            TypeWriterEffect("I'm your personal cybersecurity assistant, here to help you stay safe online!", 30);
            Console.WriteLine();
        }

        public static void DisplayBotMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\n🤖 BOT: ");
            Console.ResetColor();
            TypeWriterEffect(message, 20);
            Console.WriteLine();
        }

        public static void DisplayPrompt(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"\n👤 YOU: ");
            Console.ResetColor();
            Console.Write($"{message} ");
        }

        public static void DisplayWarning(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\n⚠️  ");
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void DisplayError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n❌ ERROR: {message}");
            Console.ResetColor();
        }

        public static void DisplayHelpMessage()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n" + new string('─', 60));
            Console.WriteLine("💡 TIP: Type 'help' to see what I can do, or 'exit' to quit");
            Console.WriteLine(new string('─', 60));
            Console.ResetColor();
        }

        public static void DisplayGoodbyeMessage(string userName)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n" + new string('═', 60));
            Console.WriteLine($"          Thank you for chatting, {userName}!");
            Console.WriteLine("          Stay safe online! 👋");
            Console.WriteLine(new string('═', 60));
            Console.ResetColor();
        }

        public static void TypeWriterEffect(string text, int delayMilliseconds)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delayMilliseconds);
            }
            Console.WriteLine();
        }

        public static void PauseBeforeExit()
        {
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}