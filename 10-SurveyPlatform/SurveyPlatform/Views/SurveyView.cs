using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SurveyPlatform.Models;

namespace SurveyPlatform.Views
{
    public class SurveyView
    {
        public int ShowMenu()
        {
            Console.WriteLine();
            Console.WriteLine("===== PLATAFORMA DE ENCUESTAS =====");
            Console.WriteLine("1. Crear encuesta");
            Console.WriteLine("2. Responder encuesta");
            Console.WriteLine("3. Ver resultados (informe)");
            Console.WriteLine("4. Ver encuestas");
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

        public void ShowSurveys(List<Survey> surveys)
        {
            if (surveys.Count == 0)
            {
                Console.WriteLine("No hay encuestas creadas.");
                return;
            }

            foreach (Survey survey in surveys)
            {
                Console.WriteLine($"#{survey.GetId()} - {survey.GetTitle()} ({survey.GetQuestions().Count} preguntas, {survey.GetResponses()} respuestas)");
            }
        }

        public void ShowQuestion(Question question, int number)
        {
            Console.WriteLine();
            Console.WriteLine($"{number}. {question.GetText()}");

            List<string> options = question.GetOptions();

            for (int i = 0; i < options.Count; i++)
            {
                Console.WriteLine($"   {i + 1}) {options[i]}");
            }
        }

        public void ShowReport(Survey survey)
        {
            Console.WriteLine();
            Console.WriteLine($"===== INFORME: {survey.GetTitle()} =====");
            Console.WriteLine($"Total de respuestas: {survey.GetResponses()}");

            List<Question> questions = survey.GetQuestions();

            for (int i = 0; i < questions.Count; i++)
            {
                Question question = questions[i];
                List<string> options = question.GetOptions();
                int total = question.GetTotalVotes();

                Console.WriteLine();
                Console.WriteLine($"{i + 1}. {question.GetText()}");

                for (int j = 0; j < options.Count; j++)
                {
                    int votes = question.GetVotes(j);
                    double percentage = 0;

                    if (total > 0)
                    {
                        percentage = votes * 100.0 / total;
                    }

                    string bar = "";
                    int barLength = (int)(percentage / 5);

                    for (int k = 0; k < barLength; k++)
                    {
                        bar = bar + "#";
                    }

                    Console.WriteLine($"   {options[j].PadRight(20)} | {bar.PadRight(20)} | {votes} votos ({Math.Round(percentage, 1)}%)");
                }

                if (total > 0)
                {
                    Console.WriteLine($"   Opción más votada: {options[question.GetMostVotedIndex()]}");
                }
                else
                {
                    Console.WriteLine("   Esta pregunta aún no tiene respuestas.");
                }
            }
        }

        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
