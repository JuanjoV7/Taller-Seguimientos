using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStopwatch.Models
{
    public class Chronometer
    {
        private Stopwatch _stopwatch;
        private List<Lap> _laps;

        public Chronometer()
        {
            _stopwatch = new Stopwatch();
            _laps = new List<Lap>();
        }

        public void Start()
        {
            _stopwatch.Start();
        }

        public void Pause()
        {
            _stopwatch.Stop();
        }

        public void Reset()
        {
            _stopwatch.Reset();
            _laps.Clear();
        }

        public bool IsRunning()
        {
            return _stopwatch.IsRunning;
        }

        public TimeSpan GetElapsedTime()
        {
            return _stopwatch.Elapsed;
        }

        public List<Lap> GetLaps()
        {
            return _laps;
        }

        public Lap RecordLap()
        {
            TimeSpan totalTime = _stopwatch.Elapsed;
            TimeSpan lapTime = totalTime;

            if (_laps.Count > 0)
            {
                lapTime = totalTime - _laps[_laps.Count - 1].GetTotalTime();
            }

            Lap lap = new Lap(_laps.Count + 1, lapTime, totalTime);
            _laps.Add(lap);

            return lap;
        }
    }
}
