using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame.Models
{
    public class Board
    {
        private List<Card> _cards;

        public Board(int pairs, string[] symbols)
        {
            _cards = new List<Card>();

            for (int i = 0; i < pairs; i++)
            {
                _cards.Add(new Card(symbols[i]));
                _cards.Add(new Card(symbols[i]));
            }

            Shuffle();
        }

        private void Shuffle()
        {
            Random random = new Random();

            for (int i = _cards.Count - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                Card temp = _cards[i];
                _cards[i] = _cards[j];
                _cards[j] = temp;
            }
        }

        public List<Card> GetCards()
        {
            return _cards;
        }

        public Card GetCard(int index)
        {
            return _cards[index];
        }

        public bool IsValidPosition(int index)
        {
            if (index < 0 || index >= _cards.Count)
            {
                return false;
            }

            if (_cards[index].IsMatched())
            {
                return false;
            }

            return true;
        }

        public bool IsFinished()
        {
            foreach (Card card in _cards)
            {
                if (!card.IsMatched())
                {
                    return false;
                }
            }

            return true;
        }
    }
}
