using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReservationSystem.Models;

namespace ReservationSystem.Views
{
    public class ReservationView
    {
        public int ShowMenu()
        {
            Console.WriteLine();
            Console.WriteLine("===== SISTEMA DE RESERVAS =====");
            Console.WriteLine("1. Ver disponibilidad");
            Console.WriteLine("2. Hacer una reserva");
            Console.WriteLine("3. Confirmar una reserva");
            Console.WriteLine("4. Ver reservas");
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

        public bool ReadYesNo(string question)
        {
            Console.WriteLine(question);
            string answer = Console.ReadLine();

            if (answer == "s" || answer == "S")
            {
                return true;
            }

            return false;
        }

        public void ShowServices(string[] services)
        {
            for (int i = 0; i < services.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {services[i]}");
            }
        }

        public void ShowAvailableHours(DateTime date, List<int> hours)
        {
            Console.WriteLine();
            Console.WriteLine($"Horarios disponibles para el {date.ToString("dd/MM/yyyy")}:");

            if (hours.Count == 0)
            {
                Console.WriteLine("No hay horarios disponibles para esa fecha.");
                return;
            }

            foreach (int hour in hours)
            {
                Console.WriteLine($"- {hour.ToString("00")}:00");
            }
        }

        public void ShowReservations(List<Reservation> reservations)
        {
            if (reservations.Count == 0)
            {
                Console.WriteLine("No hay reservas registradas.");
                return;
            }

            foreach (Reservation reservation in reservations)
            {
                string status = "Pendiente";

                if (reservation.IsConfirmed())
                {
                    status = "Confirmada";
                }

                Console.WriteLine($"#{reservation.GetId()} - {reservation.GetClientName()} - {reservation.GetService()} - {reservation.GetDateTime().ToString("dd/MM/yyyy HH:mm")} - {status}");
            }
        }

        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
