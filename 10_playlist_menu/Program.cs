// ============================================================
// Assignment 10: Menu-driven Playlist of Songs
//   - Add song (with auto index)
//   - Remove song by index
//   - Display playlist (index + title)
//   - Play next / previous
// ============================================================
using System;
using System.Collections.Generic;

namespace PlaylistApp
{
    class Program
    {
        // List<(int index, string title)>
        private static readonly List<string> _songs = new();
        private static int _currentIndex = -1;  // index of the "now playing" song

        static void Main()
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("\n========= PLAYLIST MENU =========");
                Console.WriteLine(" 1. Add song");
                Console.WriteLine(" 2. Remove song by index");
                Console.WriteLine(" 3. Show playlist");
                Console.WriteLine(" 4. Play next");
                Console.WriteLine(" 5. Play previous");
                Console.WriteLine(" 6. Show currently playing");
                Console.WriteLine(" 7. Exit");
                Console.Write("Choice: ");

                switch (Console.ReadLine())
                {
                    case "1": AddSong();          break;
                    case "2": RemoveSong();        break;
                    case "3": ShowPlaylist();      break;
                    case "4": PlayNext();           break;
                    case "5": PlayPrevious();       break;
                    case "6": ShowCurrent();        break;
                    case "7": running = false;      break;
                    default:  Console.WriteLine("Invalid choice."); break;
                }
            }
        }

        static void AddSong()
        {
            Console.Write("Enter song title: ");
            string title = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(title))
            {
                Console.WriteLine("Title cannot be empty.");
                return;
            }
            _songs.Add(title);
            Console.WriteLine($"Added at index {_songs.Count - 1}: \"{title}\"");
        }

        static void RemoveSong()
        {
            Console.Write("Enter index to remove: ");
            if (int.TryParse(Console.ReadLine(), out int idx)
                && idx >= 0 && idx < _songs.Count)
            {
                Console.WriteLine($"Removed \"{_songs[idx]}\".");
                _songs.RemoveAt(idx);
                if (_currentIndex >= _songs.Count) _currentIndex = _songs.Count - 1;
            }
            else
                Console.WriteLine("Invalid index.");
        }

        static void ShowPlaylist()
        {
            if (_songs.Count == 0)
            {
                Console.WriteLine("(playlist is empty)");
                return;
            }
            Console.WriteLine("\nIndex | Title");
            Console.WriteLine(new string('-', 30));
            for (int i = 0; i < _songs.Count; i++)
            {
                string marker = (i == _currentIndex) ? " > " : "   ";
                Console.WriteLine($"{marker}{i,-5}| {_songs[i]}");
            }
        }

        static void PlayNext()
        {
            if (_songs.Count == 0) { Console.WriteLine("Playlist empty."); return; }
            _currentIndex = (_currentIndex + 1) % _songs.Count;
            Console.WriteLine($"Now playing [#{_currentIndex}]: \"{_songs[_currentIndex]}\"");
        }

        static void PlayPrevious()
        {
            if (_songs.Count == 0) { Console.WriteLine("Playlist empty."); return; }
            _currentIndex = _currentIndex <= 0 ? _songs.Count - 1 : _currentIndex - 1;
            Console.WriteLine($"Now playing [#{_currentIndex}]: \"{_songs[_currentIndex]}\"");
        }

        static void ShowCurrent()
        {
            if (_currentIndex < 0 || _currentIndex >= _songs.Count)
                Console.WriteLine("No song is currently playing.");
            else
                Console.WriteLine($"Now playing [#{_currentIndex}]: \"{_songs[_currentIndex]}\"");
        }
    }
}
