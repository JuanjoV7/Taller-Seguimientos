using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStopwatch.Models
{
    public class Lap
    {
        private int _number;
        private TimeSpan _lapTime;
        private TimeSpan _totalTime;

        public Lap(int number, TimeSpan lapTime, TimeSpan totalTime)
        {
            _number = number;
            _lapTime = lapTime;
            _totalTime = totalTime;
        }

        public int GetNumber()
        {
            return _number;
        }

        public TimeSpan GetLapTime()
        {
            return _lapTime;
        }

        public TimeSpan GetTotalTime()
        {
            return _totalTime;
        }
    }
}
