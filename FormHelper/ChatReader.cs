using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;


namespace FormHelper
{
    public class ChatMessageEventArgs
    {
        public ChatMessageEventArgs(ChatMessage message)
        {
            Message = message;
        }

        public ChatMessage Message { get; }

    }

    public class ChatReader
    {
        private string _gameLogPath = "";
        private List<string> _chatList;
        private readonly Timer _readTimer;
        private string _lastLine;
        public delegate void ChatMessageEventHandler(object sender, ChatMessageEventArgs args);
        public static ChatMessageEventHandler ChatMessageDetected;

        public ChatReader()
        {
            _chatList = new List<string>();
            _readTimer = new Timer {Interval = 1000};
            _readTimer.Elapsed += ReadTimerOnElapsed;
        }

        private void ReadTimerOnElapsed(object sender, ElapsedEventArgs elapsedEventArgs)
        {
                var reverseReader = new ReverseLineReader(_gameLogPath);
                var lastLine = reverseReader.First();
                var chatMessage = ParseLastLine(lastLine);
                if (chatMessage != null && chatMessage.Type != ChatMessage.MessageType.Other)
                {
                    ChatMessageDetected(null, new ChatMessageEventArgs(chatMessage));
                }
        }
        
        public void SetLogPath(string path)
        {
            _gameLogPath = path;
        }
        
        public void ToggleTimer()
        {
            if (_readTimer.Enabled)
            {
                _readTimer.Stop();
            }
            else
            {
                _readTimer.Start();
            }
        }

        public ChatMessage ParseLastLine(string line)
        {
            if (_lastLine != null && _lastLine == line)
                return null;

            _lastLine = line;
            ChatMessage message = new ChatMessage(line);
            return message;
        }
    }
}
