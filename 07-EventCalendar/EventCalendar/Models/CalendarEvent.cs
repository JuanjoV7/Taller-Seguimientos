using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventCalendar.Models
{
    public class CalendarEvent
    {
        private int _id;
        private string _title;
        private string _description;
        private DateTime _dateTime;
        private int _reminderMinutes;
        private bool _isNotified;

        public CalendarEvent(int id, string title, string description, DateTime dateTime, int reminderMinutes)
        {
            _id = id;
            _title = title;
            _description = description;
            _dateTime = dateTime;
            _reminderMinutes = reminderMinutes;
            _isNotified = false;
        }

        public int GetId()
        {
            return _id;
        }

        public string GetTitle()
        {
            return _title;
        }

        public string GetDescription()
        {
            return _description;
        }

        public DateTime GetDateTime()
        {
            return _dateTime;
        }

        public int GetReminderMinutes()
        {
            return _reminderMinutes;
        }

        public bool HasReminder()
        {
            return _reminderMinutes > 0;
        }

        public DateTime GetReminderTime()
        {
            return _dateTime.AddMinutes(-_reminderMinutes);
        }

        public bool IsNotified()
        {
            return _isNotified;
        }

        public void MarkAsNotified()
        {
            _isNotified = true;
        }

        public void Update(string title, string description, DateTime dateTime, int reminderMinutes)
        {
            _title = title;
            _description = description;
            _dateTime = dateTime;
            _reminderMinutes = reminderMinutes;
            _isNotified = false;
        }
    }
}
