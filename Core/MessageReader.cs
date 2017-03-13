using Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Core
{
    public class MessageReader
    {
        private List<string> _lastLines;
        private string _clientLogPath;
        private FileSystemWatcher _fileWatcher;
        private Timer _fileTimer;
        public delegate void MessageEventHandler(object sender, MessageEventArgs args);
        public MessageEventHandler NewMessage;

        public MessageReader(string path)
        {
            var folderPath = path.Replace("Client.txt", "");

            _clientLogPath = path;
            _fileWatcher = new FileSystemWatcher();
            _fileWatcher.NotifyFilter = NotifyFilters.Attributes | NotifyFilters.CreationTime | NotifyFilters.DirectoryName | NotifyFilters.FileName | NotifyFilters.LastWrite | NotifyFilters.LastAccess | NotifyFilters.Security | NotifyFilters.Size;
            _fileWatcher.Path = folderPath;
            _fileWatcher.Filter = "Client.txt";
            _fileWatcher.Changed += _fileWatcher_Changed;
            _fileWatcher.EnableRaisingEvents = true;

            _fileTimer = new Timer(250);
            _fileTimer.Elapsed += _fileTimer_Elapsed;
            _fileTimer.Start();
        }

        private void _fileTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            checkForUpdates();
        }

        private void _fileWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            checkForUpdates();
        }

        public void DebugMessage(string message)
        {
            checkForUpdates(message);
        }

        private void checkForUpdates(string debug = null)
        {
            var reverseReader = new ReverseLineReader(_clientLogPath);
            var lines = reverseReader.Take(10).ToList();

            if (debug == null)
            {
                if (_lastLines == null)
                {
                    _lastLines = lines;
                }
                else if (_lastLines != lines)
                {
                    var newLines = lines.Except(_lastLines);

                    foreach (var line in newLines)
                    {
                        Message message = new Message(line);
                        NewMessage(null, new MessageEventArgs(message));
                    }

                    _lastLines = lines;
                }
            }
            else
            {
                Message message = new Message(debug);
                NewMessage(null, new MessageEventArgs(message));
            }
        }        
    }
}
