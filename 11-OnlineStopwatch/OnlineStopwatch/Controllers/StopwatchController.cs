using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OnlineStopwatch.Models;
using OnlineStopwatch.Views;

namespace OnlineStopwatch.Controllers
{
    public class StopwatchController
    {
        private Chronometer _chronometer;
        private StopwatchView _view;

        public StopwatchController()
        {
            _chronometer = new Chronometer();
            _view = new StopwatchView();
        }

        public void Run()
        {
            bool exit = false;

            _view.ShowInstructions();

            while (!exit)
            {
                _view.ShowTime(_chronometer.GetElapsedTime(), _chronometer.IsRunning());

                if (_view.KeyWasPressed())
                {
                    ConsoleKey key = _view.ReadKey();

                    switch (key)
                    {
                        case ConsoleKey.I:
                            _chronometer.Start();
                            break;
                        case ConsoleKey.P:
                            _chronometer.Pause();
                            break;
                        case ConsoleKey.R:
                            _chronometer.Reset();
                            _view.ShowInstructions();
                            break;
                        case ConsoleKey.V:
                            if (_chronometer.IsRunning())
                            {
                                Lap lap = _chronometer.RecordLap();
                                _view.ShowLap(lap);
                            }
                            break;
                        case ConsoleKey.S:
                            exit = true;
                            break;
                    }
                }

                Thread.Sleep(50);
            }

            _view.ShowExit(_chronometer.GetLaps().Count);
        }
    }
}
