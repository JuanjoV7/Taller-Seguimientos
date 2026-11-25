using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Models
{
    public class Reservation
    {
        private int _id;
        private string _clientName;
        private string _service;
        private DateTime _dateTime;
        private bool _isConfirmed;

        public Reservation(int id, string clientName, string service, DateTime dateTime)
        {
            _id = id;
            _clientName = clientName;
            _service = service;
            _dateTime = dateTime;
            _isConfirmed = false;
        }

        public int GetId()
        {
            return _id;
        }

        public string GetClientName()
        {
            return _clientName;
        }

        public string GetService()
        {
            return _service;
        }

        public DateTime GetDateTime()
        {
            return _dateTime;
        }

        public bool IsConfirmed()
        {
            return _isConfirmed;
        }

        public void Confirm()
        {
            _isConfirmed = true;
        }
    }
}
