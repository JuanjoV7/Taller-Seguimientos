using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyPlatform.Models
{
    public class Question
    {
        private string _text;
        private List<string> _options;
        private int[] _votes;

        public Question(string text, List<string> options)
        {
            _text = text;
            _options = options;
            _votes = new int[options.Count];
        }

        public string GetText()
        {
            return _text;
        }

        public List<string> GetOptions()
        {
            return _options;
        }

        public int GetVotes(int index)
        {
            return _votes[index];
        }

        public void AddVote(int index)
        {
            _votes[index]++;
        }

        public int GetTotalVotes()
        {
            int total = 0;

            for (int i = 0; i < _votes.Length; i++)
            {
                total = total + _votes[i];
            }

            return total;
        }

        public int GetMostVotedIndex()
        {
            int mostVoted = 0;

            for (int i = 1; i < _votes.Length; i++)
            {
                if (_votes[i] > _votes[mostVoted])
                {
                    mostVoted = i;
                }
            }

            return mostVoted;
        }
    }
}
