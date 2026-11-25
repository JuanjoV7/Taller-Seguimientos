using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TipCalculator.Models;

namespace TipCalculator.Views
{
    public class TipView
    {
        public int ShowMenu()
        {
            Console.WriteLine();
            Console.WriteLine("===== CALCULADORA DE PROPINAS =====");
            Console.WriteLine("1. Calcular propina");
            Console.WriteLine("0. Salir");
            Console.WriteLine("Digite una opción: ");
            return int.Parse(Console.ReadLine());
        }

        public decimal ReadTotal()
        {
            Console.WriteLine("Digite el monto total de la cuenta: ");
            return decimal.Parse(Console.ReadLine());
        }

        public int ReadPercentageOption()
        {
            Console.WriteLine("Seleccione el porcentaje de propina: ");
            Console.WriteLine("1. 10%");
            Console.WriteLine("2. 15%");
            Console.WriteLine("3. 20%");
            Console.WriteLine("4. Otro porcentaje");
            return int.Parse(Console.ReadLine());
        }

        public decimal ReadCustomPercentage()
        {
            Console.WriteLine("Digite el porcentaje de propina: ");
            return decimal.Parse(Console.ReadLine());
        }

        public void ShowResult(Bill bill)
        {
            Console.WriteLine();
            Console.WriteLine($"Monto de la cuenta: {bill.GetTotal()}");
            Console.WriteLine($"Propina ({bill.GetTipPercentage()}%): {bill.CalculateTip()}");
            Console.WriteLine($"Total a pagar: {bill.CalculateTotalWithTip()}");
        }

        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
