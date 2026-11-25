using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReservationSystem.Models;
using ReservationSystem.Views;

namespace ReservationSystem.Controllers
{
    public class ReservationController
    {
        private List<Reservation> _reservations;
        private string[] _services;
        private ReservationView _view;
        private int _nextId;
        private int _openingHour;
        private int _closingHour;

        public ReservationController()
        {
            _reservations = new List<Reservation>();
            _services = new string[] { "Consulta general", "Asesoría personalizada", "Revisión técnica" };
            _view = new ReservationView();
            _nextId = 1;
            _openingHour = 8;
            _closingHour = 17;
        }

        public void Run()
        {
            int option = -1;

            while (option != 0)
            {
                option = _view.ShowMenu();

                switch (option)
                {
                    case 1:
                        ShowAvailability();
                        break;
                    case 2:
                        MakeReservation();
                        break;
                    case 3:
                        ConfirmReservation();
                        break;
                    case 4:
                        _view.ShowReservations(_reservations);
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

        private void ShowAvailability()
        {
            DateTime date = ReadDate();

            if (!IsValidDate(date))
            {
                return;
            }

            _view.ShowAvailableHours(date, GetAvailableHours(date));
        }

        private void MakeReservation()
        {
            string clientName = _view.ReadText("Digite su nombre: ");

            _view.ShowServices(_services);
            int serviceOption = _view.ReadNumber("Seleccione el servicio: ");

            if (serviceOption < 1 || serviceOption > _services.Length)
            {
                _view.ShowMessage("Servicio no válido.");
                return;
            }

            DateTime date = ReadDate();

            if (!IsValidDate(date))
            {
                return;
            }

            List<int> availableHours = GetAvailableHours(date);
            _view.ShowAvailableHours(date, availableHours);

            if (availableHours.Count == 0)
            {
                return;
            }

            int hour = _view.ReadNumber("Digite la hora que desea (formato 24 horas, ej: 14): ");

            if (!availableHours.Contains(hour))
            {
                _view.ShowMessage("La hora seleccionada no está disponible.");
                return;
            }

            Reservation reservation = new Reservation(_nextId, clientName, _services[serviceOption - 1], date.AddHours(hour));
            _reservations.Add(reservation);
            _nextId++;

            _view.ShowMessage($"Reserva #{reservation.GetId()} creada. Estado: pendiente de confirmación.");

            bool confirmNow = _view.ReadYesNo("¿Desea confirmar la reserva ahora? (s/n): ");

            if (confirmNow)
            {
                reservation.Confirm();
                _view.ShowMessage("Reserva confirmada.");
            }
        }

        private void ConfirmReservation()
        {
            if (_reservations.Count == 0)
            {
                _view.ShowMessage("No hay reservas registradas.");
                return;
            }

            _view.ShowReservations(_reservations);
            int id = _view.ReadNumber("Digite el número de la reserva a confirmar: ");
            int index = FindReservationIndex(id);

            if (index == -1)
            {
                _view.ShowMessage("La reserva no existe.");
                return;
            }

            if (_reservations[index].IsConfirmed())
            {
                _view.ShowMessage("La reserva ya estaba confirmada.");
                return;
            }

            _reservations[index].Confirm();
            _view.ShowMessage("Reserva confirmada.");
        }

        private List<int> GetAvailableHours(DateTime date)
        {
            List<int> hours = new List<int>();

            for (int hour = _openingHour; hour <= _closingHour; hour++)
            {
                DateTime dateTime = date.AddHours(hour);

                if (dateTime > DateTime.Now && IsAvailable(dateTime))
                {
                    hours.Add(hour);
                }
            }

            return hours;
        }

        private bool IsAvailable(DateTime dateTime)
        {
            foreach (Reservation reservation in _reservations)
            {
                if (reservation.GetDateTime() == dateTime)
                {
                    return false;
                }
            }

            return true;
        }

        private int FindReservationIndex(int id)
        {
            for (int i = 0; i < _reservations.Count; i++)
            {
                if (_reservations[i].GetId() == id)
                {
                    return i;
                }
            }

            return -1;
        }

        private DateTime ReadDate()
        {
            int day = _view.ReadNumber("Digite el día: ");
            int month = _view.ReadNumber("Digite el mes: ");
            int year = _view.ReadNumber("Digite el año: ");

            if (year < 1 || year > 9999 || month < 1 || month > 12)
            {
                return DateTime.MinValue;
            }

            if (day < 1 || day > DateTime.DaysInMonth(year, month))
            {
                return DateTime.MinValue;
            }

            return new DateTime(year, month, day);
        }

        private bool IsValidDate(DateTime date)
        {
            if (date == DateTime.MinValue)
            {
                _view.ShowMessage("La fecha no es válida.");
                return false;
            }

            if (date < DateTime.Today)
            {
                _view.ShowMessage("No se pueden hacer reservas en fechas pasadas.");
                return false;
            }

            return true;
        }
    }
}
