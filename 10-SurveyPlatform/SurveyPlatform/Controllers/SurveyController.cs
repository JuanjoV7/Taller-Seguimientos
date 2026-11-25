using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SurveyPlatform.Models;
using SurveyPlatform.Views;

namespace SurveyPlatform.Controllers
{
    public class SurveyController
    {
        private List<Survey> _surveys;
        private SurveyView _view;
        private int _nextId;

        public SurveyController()
        {
            _surveys = new List<Survey>();
            _view = new SurveyView();
            _nextId = 1;

            LoadInitialSurvey();
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
                        CreateSurvey();
                        break;
                    case 2:
                        AnswerSurvey();
                        break;
                    case 3:
                        ShowResults();
                        break;
                    case 4:
                        _view.ShowSurveys(_surveys);
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

        private void LoadInitialSurvey()
        {
            Survey survey = new Survey(_nextId, "Satisfacción con el curso");

            List<string> ratingOptions = new List<string>();
            ratingOptions.Add("Excelente");
            ratingOptions.Add("Bueno");
            ratingOptions.Add("Regular");
            ratingOptions.Add("Malo");
            survey.AddQuestion(new Question("¿Cómo califica el curso?", ratingOptions));

            List<string> recommendOptions = new List<string>();
            recommendOptions.Add("Sí");
            recommendOptions.Add("No");
            survey.AddQuestion(new Question("¿Recomendaría el curso?", recommendOptions));

            _surveys.Add(survey);
            _nextId++;
        }

        private void CreateSurvey()
        {
            string title = _view.ReadText("Digite el título de la encuesta: ");

            if (title == "")
            {
                _view.ShowMessage("El título no puede estar vacío.");
                return;
            }

            int questionCount = _view.ReadNumber("¿Cuántas preguntas tendrá la encuesta? ");

            if (questionCount < 1)
            {
                _view.ShowMessage("La encuesta debe tener al menos 1 pregunta.");
                return;
            }

            Survey survey = new Survey(_nextId, title);

            for (int i = 1; i <= questionCount; i++)
            {
                string text = _view.ReadText($"Digite la pregunta {i}: ");
                int optionCount = _view.ReadNumber("¿Cuántas opciones de respuesta tendrá? (mínimo 2): ");

                while (optionCount < 2)
                {
                    _view.ShowMessage("La pregunta debe tener al menos 2 opciones.");
                    optionCount = _view.ReadNumber("¿Cuántas opciones de respuesta tendrá? (mínimo 2): ");
                }

                List<string> options = new List<string>();

                for (int j = 1; j <= optionCount; j++)
                {
                    options.Add(_view.ReadText($"Digite la opción {j}: "));
                }

                survey.AddQuestion(new Question(text, options));
            }

            _surveys.Add(survey);
            _nextId++;

            _view.ShowMessage("Encuesta creada.");
        }

        private void AnswerSurvey()
        {
            if (_surveys.Count == 0)
            {
                _view.ShowMessage("No hay encuestas creadas.");
                return;
            }

            _view.ShowSurveys(_surveys);
            int id = _view.ReadNumber("Digite el número de la encuesta que quiere responder: ");
            int index = FindSurveyIndex(id);

            if (index == -1)
            {
                _view.ShowMessage("La encuesta no existe.");
                return;
            }

            Survey survey = _surveys[index];
            List<Question> questions = survey.GetQuestions();

            for (int i = 0; i < questions.Count; i++)
            {
                _view.ShowQuestion(questions[i], i + 1);
                int answer = _view.ReadNumber("Digite su respuesta: ");

                while (answer < 1 || answer > questions[i].GetOptions().Count)
                {
                    _view.ShowMessage("Respuesta no válida.");
                    answer = _view.ReadNumber("Digite su respuesta: ");
                }

                questions[i].AddVote(answer - 1);
            }

            survey.AddResponse();
            _view.ShowMessage("¡Gracias por responder la encuesta!");
        }

        private void ShowResults()
        {
            if (_surveys.Count == 0)
            {
                _view.ShowMessage("No hay encuestas creadas.");
                return;
            }

            _view.ShowSurveys(_surveys);
            int id = _view.ReadNumber("Digite el número de la encuesta: ");
            int index = FindSurveyIndex(id);

            if (index == -1)
            {
                _view.ShowMessage("La encuesta no existe.");
                return;
            }

            _view.ShowReport(_surveys[index]);
        }

        private int FindSurveyIndex(int id)
        {
            for (int i = 0; i < _surveys.Count; i++)
            {
                if (_surveys[i].GetId() == id)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
