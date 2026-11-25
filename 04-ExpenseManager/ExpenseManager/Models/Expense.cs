using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManager.Models
{
    public class Expense
    {
        private string _description;
        private decimal _amount;
        private string _category;
        private DateTime _date;

        public Expense(string description, decimal amount, string category, DateTime date)
        {
            _description = description;
            _amount = amount;
            _category = category;
            _date = date;
        }

        public string GetDescription()
        {
            return _description;
        }

        public decimal GetAmount()
        {
            return _amount;
        }

        public string GetCategory()
        {
            return _category;
        }

        public DateTime GetDate()
        {
            return _date;
        }
    }
}
