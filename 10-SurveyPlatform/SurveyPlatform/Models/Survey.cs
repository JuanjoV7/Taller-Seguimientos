using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyPlatform.Models
{
    public class Survey
    {
        private int _id;
        private string _title;
        private List<Question> _questions;
        private int _responses;

        public Survey(int id, string title)
        {
            _id = id;
            _title = title;
            _questions = new List<Question>();
            _responses = 0;
        }

        public int GetId()
        {
            return _id;
        }

        public string GetTitle()
        {
            return _title;
        }

        public List<Question> GetQuestions()
        {
            return _questions;
        }

        public int GetResponses()
        {
            return _responses;
        }

        public void AddQuestion(Question question)
        {
            _questions.Add(question);
        }

        public void AddResponse()
        {
            _responses++;
        }
    }
}
