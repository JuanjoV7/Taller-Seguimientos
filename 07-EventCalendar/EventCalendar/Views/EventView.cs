using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventCalendar.Models;

namespace EventCalendar.Views
{
    public class EventView
    {
        public int ShowMenu()
        {
            Console.WriteLine();
            Console.WriteLine("===== CALENDARIO DE EVENTOS =====");
            Console.WriteLine("1. Ver calendario del mes");
            Console.WriteLine("2. Ver todos los eventos");
            Console.WriteLine("3. Agregar evento");
            Console.WriteLine("4. Editar evento");
            Console.WriteLine("5. Eliminar evento");
            Console.WriteLine("0. Salir");
            Console.WriteLine("Digite una opción: ");
            return int.Parse(Console.ReadLine());
        }

        public string ReadText(string label)
        {
            Console.WriteLine(label);
            return Console.ReadLine();
        }

        public int ReadNumber(string label)
        {
            Console.WriteLine(label);
            return int.Parse(Console.ReadLine());
        }

        public void ShowMonth(int month, int year, List<int> eventDays)
        {
            Console.WriteLine();
            Console.WriteLine($"========= {month.ToString("00")}/{year} =========");
            Console.WriteLine(" Do  Lu  Ma  Mi  Ju  Vi  Sa ");

            DateTime firstDay = new DateTime(year, month, 1);
            int startColumn = (int)firstDay.DayOfWeek;
            int daysInMonth = DateTime.DaysInMonth(year, month);

            for (int i = 0; i < startColumn; i++)
            {
                Console.Write("    ");
            }

            for (int day = 1; day <= daysInMonth; day++)
            {
                string mark = " ";

                if (eventDays.Contains(day))
                {
                    mark = "*";
                }

                Console.Write(day.ToString().PadLeft(3) + mark);

                if ((startColumn + day) % 7 == 0)
                {
                    Console.WriteLine();
                }
            }

            Console.WriteLine();
            Console.WriteLine("* = día con eventos");
        }

        public void ShowEvents(List<CalendarEvent> events)
        {
            if (events.Count == 0)
            {
                Console.WriteLine("No hay eventos para mostrar.");
                return;
            }

            foreach (CalendarEvent calendarEvent in events)
            {
                string reminder = "Sin recordatorio";

                if (calendarEvent.HasReminder())
                {
                    reminder = $"Recordatorio {calendarEvent.GetReminderMinutes()} min antes";
                }

                Console.WriteLine($"#{calendarEvent.GetId()} - {calendarEvent.GetDateTime().ToString("dd/MM/yyyy HH:mm")} - {calendarEvent.GetTitle()} ({reminder})");

                if (calendarEvent.GetDescription() != "")
                {
                    Console.WriteLine($"   {calendarEvent.GetDescription()}");
                }
            }
        }

        public void ShowNotification(CalendarEvent calendarEvent)
        {
            Console.Beep();
            Console.WriteLine();
            Console.WriteLine("**************************************************");
            Console.WriteLine($"RECORDATORIO: {calendarEvent.GetTitle()}");
            Console.WriteLine($"Empieza el {calendarEvent.GetDateTime().ToString("dd/MM/yyyy")} a las {calendarEvent.GetDateTime().ToString("HH:mm")}");
            Console.WriteLine("**************************************************");
        }

        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
