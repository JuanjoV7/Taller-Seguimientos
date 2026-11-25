using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventCalendar.Models;
using EventCalendar.Views;

namespace EventCalendar.Controllers
{
    public class EventController
    {
        private List<CalendarEvent> _events;
        private EventView _view;
        private int _nextId;

        public EventController()
        {
            _events = new List<CalendarEvent>();
            _view = new EventView();
            _nextId = 1;
        }

        public void Run()
        {
            int option = -1;

            while (option != 0)
            {
                CheckReminders();
                option = _view.ShowMenu();

                switch (option)
                {
                    case 1:
                        ShowCalendar();
                        break;
                    case 2:
                        _view.ShowEvents(_events);
                        break;
                    case 3:
                        AddEvent();
                        break;
                    case 4:
                        EditEvent();
                        break;
                    case 5:
                        RemoveEvent();
                        break;
                    case 0:
                        _view.ShowMessage("Hasta luego.");
                        break;
                    default:
                        _view.ShowMessage("Opción no válida.");
                        break;
                }
            }
        }

        private void ShowCalendar()
        {
            int month = _view.ReadNumber("Digite el mes (1-12): ");
            int year = _view.ReadNumber("Digite el año: ");

            if (month < 1 || month > 12 || year < 1 || year > 9999)
            {
                _view.ShowMessage("El mes o el año no son válidos.");
                return;
            }

            List<int> eventDays = new List<int>();
            List<CalendarEvent> eventsInMonth = new List<CalendarEvent>();

            foreach (CalendarEvent calendarEvent in _events)
            {
                DateTime dateTime = calendarEvent.GetDateTime();

                if (dateTime.Month == month && dateTime.Year == year)
                {
                    eventsInMonth.Add(calendarEvent);

                    if (!eventDays.Contains(dateTime.Day))
                    {
                        eventDays.Add(dateTime.Day);
                    }
                }
            }

            _view.ShowMonth(month, year, eventDays);
            _view.ShowEvents(eventsInMonth);
        }

        private void AddEvent()
        {
            string title = _view.ReadText("Digite el título del evento: ");

            if (title == "")
            {
                _view.ShowMessage("El título no puede estar vacío.");
                return;
            }

            string description = _view.ReadText("Digite la descripción del evento (opcional): ");
            DateTime dateTime = ReadDateTime();

            if (dateTime == DateTime.MinValue)
            {
                _view.ShowMessage("La fecha o la hora no son válidas.");
                return;
            }

            int reminderMinutes = _view.ReadNumber("¿Cuántos minutos antes quiere el recordatorio? (0 = sin recordatorio): ");

            if (reminderMinutes < 0)
            {
                _view.ShowMessage("Los minutos no pueden ser negativos.");
                return;
            }

            CalendarEvent calendarEvent = new CalendarEvent(_nextId, title, description, dateTime, reminderMinutes);
            InsertSorted(calendarEvent);
            _nextId++;

            _view.ShowMessage("Evento agregado.");
        }

        private void EditEvent()
        {
            if (_events.Count == 0)
            {
                _view.ShowMessage("No hay eventos registrados.");
                return;
            }

            _view.ShowEvents(_events);
            int id = _view.ReadNumber("Digite el número del evento a editar: ");
            int index = FindEventIndex(id);

            if (index == -1)
            {
                _view.ShowMessage("El evento no existe.");
                return;
            }

            string title = _view.ReadText("Digite el nuevo título: ");

            if (title == "")
            {
                _view.ShowMessage("El título no puede estar vacío.");
                return;
            }

            string description = _view.ReadText("Digite la nueva descripción (opcional): ");
            DateTime dateTime = ReadDateTime();

            if (dateTime == DateTime.MinValue)
            {
                _view.ShowMessage("La fecha o la hora no son válidas.");
                return;
            }

            int reminderMinutes = _view.ReadNumber("¿Cuántos minutos antes quiere el recordatorio? (0 = sin recordatorio): ");

            if (reminderMinutes < 0)
            {
                _view.ShowMessage("Los minutos no pueden ser negativos.");
                return;
            }

            CalendarEvent calendarEvent = _events[index];
            _events.RemoveAt(index);
            calendarEvent.Update(title, description, dateTime, reminderMinutes);
            InsertSorted(calendarEvent);

            _view.ShowMessage("Evento actualizado.");
        }

        private void RemoveEvent()
        {
            if (_events.Count == 0)
            {
                _view.ShowMessage("No hay eventos registrados.");
                return;
            }

            _view.ShowEvents(_events);
            int id = _view.ReadNumber("Digite el número del evento a eliminar: ");
            int index = FindEventIndex(id);

            if (index == -1)
            {
                _view.ShowMessage("El evento no existe.");
                return;
            }

            _events.RemoveAt(index);
            _view.ShowMessage("Evento eliminado.");
        }

        private void CheckReminders()
        {
            DateTime now = DateTime.Now;

            foreach (CalendarEvent calendarEvent in _events)
            {
                if (calendarEvent.HasReminder() && !calendarEvent.IsNotified() && now >= calendarEvent.GetReminderTime() && now < calendarEvent.GetDateTime())
                {
                    _view.ShowNotification(calendarEvent);
                    calendarEvent.MarkAsNotified();
                }
            }
        }

        private void InsertSorted(CalendarEvent calendarEvent)
        {
            int position = 0;

            while (position < _events.Count && _events[position].GetDateTime() <= calendarEvent.GetDateTime())
            {
                position++;
            }

            _events.Insert(position, calendarEvent);
        }

        private int FindEventIndex(int id)
        {
            for (int i = 0; i < _events.Count; i++)
            {
                if (_events[i].GetId() == id)
                {
                    return i;
                }
            }

            return -1;
        }

        private DateTime ReadDateTime()
        {
            int day = _view.ReadNumber("Digite el día: ");
            int month = _view.ReadNumber("Digite el mes: ");
            int year = _view.ReadNumber("Digite el año: ");
            int hour = _view.ReadNumber("Digite la hora (0-23): ");
            int minute = _view.ReadNumber("Digite los minutos (0-59): ");

            if (year < 1 || year > 9999 || month < 1 || month > 12)
            {
                return DateTime.MinValue;
            }

            if (day < 1 || day > DateTime.DaysInMonth(year, month))
            {
                return DateTime.MinValue;
            }

            if (hour < 0 || hour > 23 || minute < 0 || minute > 59)
            {
                return DateTime.MinValue;
            }

            return new DateTime(year, month, day, hour, minute, 0);
        }
    }
}
