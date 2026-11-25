using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGenerator.Views
{
    public class PasswordView
    {
        public int ShowMenu()
        {
            Console.WriteLine();
            Console.WriteLine("===== GENERADOR DE CONTRASEÑAS SEGURAS =====");
            Console.WriteLine("1. Generar contraseña");
            Console.WriteLine("0. Salir");
            Console.WriteLine("Digite una opción: ");
            return int.Parse(Console.ReadLine());
        }

        public int ReadLength()
        {
            Console.WriteLine("Digite la longitud de la contraseña (entre 8 y 64): ");
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

        public void ShowPassword(string password)
        {
            Console.WriteLine();
            Console.WriteLine($"Contraseña generada: {password}");
        }

        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
