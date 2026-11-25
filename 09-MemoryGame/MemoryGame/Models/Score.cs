using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame.Models
{
    public class Score
    {
        private string _playerName;
        private string _level;
        private int _points;
        private int _attempts;

        public Score(string playerName, string level, int points, int attempts)
        {
            _playerName = playerName;
            _level = level;
            _points = points;
            _attempts = attempts;
        }

        public string GetPlayerName()
        {
            return _playerName;
        }

        public string GetLevel()
        {
            return _level;
        }

        public int GetPoints()
        {
            return _points;
        }

        public int GetAttempts()
        {
            return _attempts;
        }
    }
}
