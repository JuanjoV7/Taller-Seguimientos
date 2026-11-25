using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame.Models
{
    public class Card
    {
        private string _symbol;
        private bool _isMatched;

        public Card(string symbol)
        {
            _symbol = symbol;
            _isMatched = false;
        }

        public string GetSymbol()
        {
            return _symbol;
        }

        public bool IsMatched()
        {
            return _isMatched;
        }

        public void Match()
        {
            _isMatched = true;
        }
    }
}
