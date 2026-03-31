using System;
using System.Collections.Generic;
using System.IO;

namespace CybersecurityChatbot
{
    public class ConversationLogger
    {
        private readonly List<string> _entries = new();

        public void LogEntry(string line)
        {
            if (string.IsNullOrWhiteSpace(line)) return;
            _entries.Add($"[{DateTime.UtcNow:yyyy-MM-dd HH:mm:ss}] {line}");
        }

        public string SaveTranscript()
        {
            try
            {
                var dir = Path.Combine(AppContext.BaseDirectory ?? Directory.GetCurrentDirectory(), "Transcripts");
                Directory.CreateDirectory(dir);
                var file = Path.Combine(dir, $"transcript_{DateTime.UtcNow:yyyyMMdd_HHmmss}.txt");
                File.WriteAllLines(file, _entries);
                return file;
            }
            catch (Exception)
            {
                return "(failed to save transcript)";
            }
        }

        public string GetTranscriptPreview(int maxLines = 20)
        {
            if (_entries.Count == 0) return "(no conversation yet)";
            int start = Math.Max(0, _entries.Count - maxLines);
            return string.Join(Environment.NewLine, _entries.GetRange(start, _entries.Count - start));
        }
    }
}
