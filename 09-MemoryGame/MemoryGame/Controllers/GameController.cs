using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemoryGame.Models;
using MemoryGame.Views;

namespace MemoryGame.Controllers
{
    public class GameController
    {
        private List<Score> _scores;
        private string[] _symbols;
        private GameView _view;

        public GameController()
        {
            _scores = new List<Score>();
            _symbols = new string[] { "@", "#", "$", "%", "&", "*", "+", "=" };
            _view = new GameView();
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
                        PlayGame();
                        break;
                    case 2:
                        _view.ShowScores(_scores);
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

        private void PlayGame()
        {
            string playerName = _view.ReadText("Digite su nombre: ");

            _view.ShowLevels();
            int level = _view.ReadNumber("Seleccione el nivel: ");

            int pairs = 0;
            string levelName = "";

            switch (level)
            {
                case 1:
                    pairs = 4;
                    levelName = "Fácil";
                    break;
                case 2:
                    pairs = 6;
                    levelName = "Medio";
                    break;
                case 3:
                    pairs = 8;
                    levelName = "Difícil";
                    break;
                default:
                    _view.ShowMessage("Nivel no válido.");
                    return;
            }

            Board board = new Board(pairs, _symbols);
            int pointsPerPair = level * 10;
            int points = 0;
            int attempts = 0;

            while (!board.IsFinished())
            {
                _view.ShowBoard(board.GetCards(), -1, -1, points, attempts);
                int first = _view.ReadNumber("Seleccione la primera carta: ") - 1;

                if (!board.IsValidPosition(first))
                {
                    _view.ShowMessage("Posición no válida.");
                    _view.WaitForKey();
                    continue;
                }

                _view.ShowBoard(board.GetCards(), first, -1, points, attempts);
                int second = _view.ReadNumber("Seleccione la segunda carta: ") - 1;

                if (!board.IsValidPosition(second) || second == first)
                {
                    _view.ShowMessage("Posición no válida.");
                    _view.WaitForKey();
                    continue;
                }

                attempts++;
                _view.ShowBoard(board.GetCards(), first, second, points, attempts);

                if (board.GetCard(first).GetSymbol() == board.GetCard(second).GetSymbol())
                {
                    board.GetCard(first).Match();
                    board.GetCard(second).Match();
                    points = points + pointsPerPair;
                    _view.ShowMessage($"¡Pareja encontrada! +{pointsPerPair} puntos");
                }
                else
                {
                    points = points - 2;

                    if (points < 0)
                    {
                        points = 0;
                    }

                    _view.ShowMessage("No son pareja. -2 puntos");
                }

                _view.WaitForKey();
            }

            _view.ShowBoard(board.GetCards(), -1, -1, points, attempts);
            _view.ShowMessage($"¡Felicitaciones {playerName}! Terminó el nivel {levelName} con {points} puntos en {attempts} intentos.");

            Score score = new Score(playerName, levelName, points, attempts);
            SaveScore(score);
        }

        private void SaveScore(Score score)
        {
            int position = 0;

            while (position < _scores.Count && _scores[position].GetPoints() >= score.GetPoints())
            {
                position++;
            }

            _scores.Insert(position, score);
        }
    }
}
