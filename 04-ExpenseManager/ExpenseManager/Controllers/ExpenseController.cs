using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseManager.Models;
using ExpenseManager.Views;

namespace ExpenseManager.Controllers
{
    public class ExpenseController
    {
        private List<Expense> _expenses;
        private string[] _categories;
        private ExpenseView _view;

        public ExpenseController()
        {
            _expenses = new List<Expense>();
            _categories = new string[] { "Alimentación", "Transporte", "Servicios", "Entretenimiento", "Salud", "Otros" };
            _view = new ExpenseView();
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
                        AddExpense();
                        break;
                    case 2:
                        _view.ShowExpenses(_expenses);
                        break;
                    case 3:
                        ShowMonthlySummary();
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

        private void AddExpense()
        {
            string description = _view.ReadText("Digite la descripción del gasto: ");
            decimal amount = _view.ReadAmount("Digite el valor del gasto: ");

            if (amount <= 0)
            {
                _view.ShowMessage("El valor debe ser mayor a 0.");
                return;
            }

            _view.ShowCategories(_categories);
            int categoryOption = _view.ReadNumber("Seleccione la categoría: ");

            if (categoryOption < 1 || categoryOption > _categories.Length)
            {
                _view.ShowMessage("Categoría no válida.");
                return;
            }

            DateTime date = DateTime.Today;
            bool isToday = _view.ReadYesNo("¿El gasto es de hoy? (s/n): ");

            if (!isToday)
            {
                date = ReadDate();

                if (date == DateTime.MinValue)
                {
                    _view.ShowMessage("La fecha no es válida.");
                    return;
                }
            }

            Expense expense = new Expense(description, amount, _categories[categoryOption - 1], date);
            _expenses.Add(expense);

            _view.ShowMessage("Gasto registrado.");
        }

        private void ShowMonthlySummary()
        {
            int month = _view.ReadNumber("Digite el mes (1-12): ");
            int year = _view.ReadNumber("Digite el año: ");

            if (month < 1 || month > 12)
            {
                _view.ShowMessage("El mes no es válido.");
                return;
            }

            decimal[] totals = new decimal[_categories.Length];
            decimal total = 0;

            foreach (Expense expense in _expenses)
            {
                if (expense.GetDate().Month == month && expense.GetDate().Year == year)
                {
                    for (int i = 0; i < _categories.Length; i++)
                    {
                        if (expense.GetCategory() == _categories[i])
                        {
                            totals[i] = totals[i] + expense.GetAmount();
                        }
                    }

                    total = total + expense.GetAmount();
                }
            }

            _view.ShowSummary(month, year, _categories, totals, total);
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
    }
}
