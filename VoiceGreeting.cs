using System;
using System.IO;
using System.Media;
using System.Speech.Synthesis;

namespace CybersecurityChatbot
{
    public class VoiceGreeting
    {
        public void PlayGreeting()
        {
            try
            {
                string baseDir = AppContext.BaseDirectory ?? Directory.GetCurrentDirectory();
                string resourcesDir = Path.Combine(baseDir, "Resources");

                string greetingFileName = "greeting.wav";
                string foundWav = null;

                
                var resourcesGreeting = Path.Combine(resourcesDir, greetingFileName);
                if (File.Exists(resourcesGreeting))
                {
                    foundWav = resourcesGreeting;
                }
                else
                {
                    
                    var baseGreeting = Path.Combine(baseDir, greetingFileName);
                    if (File.Exists(baseGreeting))
                    {
                        foundWav = baseGreeting;
                    }
                }

                // If explicit greeting not found, fall back to any WAV in Resources
                if (string.IsNullOrEmpty(foundWav) && Directory.Exists(resourcesDir))
                {
                    var wavs = Directory.GetFiles(resourcesDir, "*.wav", SearchOption.TopDirectoryOnly);
                    if (wavs.Length > 0)
                    {
                        foundWav = wavs[0];
                    }
                }

                if (!string.IsNullOrEmpty(foundWav) && File.Exists(foundWav))
                {
                    try
                    {
                        using (var player = new SoundPlayer(foundWav))
                        {
                            player.Load();
                            player.PlaySync();
                            return;
                        }
                    }
                    catch
                    {
                        // If playback fails, fall through to TTS
                    }
                }

                // If no audio file was found, notify and use TTS
                if (string.IsNullOrEmpty(foundWav))
                {
                    Console.WriteLine("Voice greeting file not found. Continuing with text interface.");
                }

                // Fallback: speech synthesizer
                using (var synth = new SpeechSynthesizer())
                {
                    synth.Rate = 0;
                    synth.Volume = 100;
                    synth.Speak("Hello! Welcome to the Cybersecurity Awareness Bot. I'm here to help you stay safe online.");
                }
            }
            catch (Exception)
            {
                // Final fallback: text
                Console.WriteLine("Voice greeting unavailable. Here's the greeting in text:");
                Console.WriteLine("Hello! Welcome to the Cybersecurity Awareness Bot.");
                Console.WriteLine("I'm here to help you stay safe online.");
                Console.WriteLine();
            }
        }
    }
}
