using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemoryGame.Models;

namespace MemoryGame.Views
{
    public class GameView
    {
        public int ShowMenu()
        {
            Console.WriteLine();
            Console.WriteLine("===== JUEGO DE MEMORIA =====");
            Console.WriteLine("1. Jugar");
            Console.WriteLine("2. Ver mejores puntajes");
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

        public void ShowLevels()
        {
            Console.WriteLine("1. Fácil (4 parejas)");
            Console.WriteLine("2. Medio (6 parejas)");
            Console.WriteLine("3. Difícil (8 parejas)");
        }

        public void ShowBoard(List<Card> cards, int firstIndex, int secondIndex, int points, int attempts)
        {
            Console.Clear();
            Console.WriteLine("===== JUEGO DE MEMORIA =====");
            Console.WriteLine($"Puntaje: {points}   Intentos: {attempts}");
            Console.WriteLine();

            for (int i = 0; i < cards.Count; i++)
            {
                string symbol = "?";

                if (cards[i].IsMatched() || i == firstIndex || i == secondIndex)
                {
                    symbol = cards[i].GetSymbol();
                }

                Console.Write((i + 1).ToString().PadLeft(2) + ":[" + symbol + "]   ");

                if ((i + 1) % 4 == 0)
                {
                    Console.WriteLine();
                }
            }

            Console.WriteLine();
        }

        public void ShowScores(List<Score> scores)
        {
            if (scores.Count == 0)
            {
                Console.WriteLine("Aún no hay puntajes registrados.");
                return;
            }

            Console.WriteLine();
            Console.WriteLine("===== MEJORES PUNTAJES =====");

            for (int i = 0; i < scores.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {scores[i].GetPlayerName()} - Nivel {scores[i].GetLevel()} - {scores[i].GetPoints()} puntos ({scores[i].GetAttempts()} intentos)");
            }
        }

        public void WaitForKey()
        {
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey(true);
        }

        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
