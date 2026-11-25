using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseManager.Models;

namespace ExpenseManager.Views
{
    public class ExpenseView
    {
        public int ShowMenu()
        {
            Console.WriteLine();
            Console.WriteLine("===== GESTOR DE GASTOS =====");
            Console.WriteLine("1. Registrar gasto");
            Console.WriteLine("2. Ver gastos");
            Console.WriteLine("3. Ver resumen mensual");
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

        public decimal ReadAmount(string label)
        {
            Console.WriteLine(label);
            return decimal.Parse(Console.ReadLine());
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

        public void ShowCategories(string[] categories)
        {
            for (int i = 0; i < categories.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {categories[i]}");
            }
        }

        public void ShowExpenses(List<Expense> expenses)
        {
            if (expenses.Count == 0)
            {
                Console.WriteLine("No hay gastos registrados.");
                return;
            }

            foreach (Expense expense in expenses)
            {
                Console.WriteLine($"{expense.GetDate().ToString("dd/MM/yyyy")} - {expense.GetCategory()} - {expense.GetDescription()}: {expense.GetAmount()}");
            }
        }

        public void ShowSummary(int month, int year, string[] categories, decimal[] totals, decimal total)
        {
            Console.WriteLine();
            Console.WriteLine($"===== RESUMEN DE {month.ToString("00")}/{year} =====");

            if (total == 0)
            {
                Console.WriteLine("No hay gastos registrados en ese mes.");
                return;
            }

            for (int i = 0; i < categories.Length; i++)
            {
                if (totals[i] > 0)
                {
                    decimal percentage = Math.Round(totals[i] * 100 / total, 1);
                    Console.WriteLine($"{categories[i]}: {totals[i]} ({percentage}%)");
                }
            }

            Console.WriteLine($"Total del mes: {total}");
        }

        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
