using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TipCalculator.Models
{
    public class Bill
    {
        private decimal _total;
        private decimal _tipPercentage;

        public Bill(decimal total, decimal tipPercentage)
        {
            _total = total;
            _tipPercentage = tipPercentage;
        }

        public decimal GetTotal()
        {
            return _total;
        }

        public decimal GetTipPercentage()
        {
            return _tipPercentage;
        }

        public decimal CalculateTip()
        {
            return Math.Round(_total * _tipPercentage / 100, 2);
        }

        public decimal CalculateTotalWithTip()
        {
            return _total + CalculateTip();
        }
    }
}
