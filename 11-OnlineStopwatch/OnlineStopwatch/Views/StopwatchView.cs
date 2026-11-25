using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStopwatch.Models;

namespace OnlineStopwatch.Views
{
    public class StopwatchView
    {
        public void ShowInstructions()
        {
            Console.Clear();
            Console.CursorVisible = false;
            Console.WriteLine("===== CRONÓMETRO ONLINE =====");
            Console.WriteLine("[I] Iniciar / Reanudar   [P] Pausar   [R] Reiniciar");
            Console.WriteLine("[V] Registrar vuelta     [S] Salir");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Vueltas:");
        }

        public void ShowTime(TimeSpan time, bool isRunning)
        {
            string status = "Detenido";

            if (isRunning)
            {
                status = "En marcha";
            }
            else if (time > TimeSpan.Zero)
            {
                status = "Pausado";
            }

            Console.SetCursorPosition(0, 4);
            Console.Write($"Tiempo: {FormatTime(time)}   Estado: {status}          ");
        }

        public void ShowLap(Lap lap)
        {
            Console.SetCursorPosition(0, 6 + lap.GetNumber());
            Console.Write($"Vuelta {lap.GetNumber()}: {FormatTime(lap.GetLapTime())}   Total: {FormatTime(lap.GetTotalTime())}");
        }

        public void ShowExit(int lapCount)
        {
            Console.SetCursorPosition(0, 8 + lapCount);
            Console.CursorVisible = true;
            Console.WriteLine("Cronómetro cerrado.");
        }

        public bool KeyWasPressed()
        {
            return Console.KeyAvailable;
        }

        public ConsoleKey ReadKey()
        {
            return Console.ReadKey(true).Key;
        }

        private string FormatTime(TimeSpan time)
        {
            string hours = ((int)time.TotalHours).ToString("00");
            string minutes = time.Minutes.ToString("00");
            string seconds = time.Seconds.ToString("00");
            string hundredths = (time.Milliseconds / 10).ToString("00");

            return hours + ":" + minutes + ":" + seconds + "." + hundredths;
        }
    }
}
