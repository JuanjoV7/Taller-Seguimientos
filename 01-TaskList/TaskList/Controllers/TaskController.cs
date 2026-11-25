using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskList.Models;
using TaskList.Views;

namespace TaskList.Controllers
{
    public class TaskController
    {
        private List<TaskItem> _tasks;
        private TaskView _view;
        private int _nextId;

        public TaskController()
        {
            _tasks = new List<TaskItem>();
            _view = new TaskView();
            _nextId = 1;
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
                        AddTask();
                        break;
                    case 2:
                        _view.ShowTasks(_tasks);
                        break;
                    case 3:
                        CompleteTask();
                        break;
                    case 4:
                        RemoveTask();
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

        private void AddTask()
        {
            string title = _view.ReadTitle();

            if (title == "")
            {
                _view.ShowMessage("El nombre de la tarea no puede estar vacío.");
                return;
            }

            TaskItem task = new TaskItem(_nextId, title);
            _tasks.Add(task);
            _nextId++;

            _view.ShowMessage("Tarea agregada.");
        }

        private void CompleteTask()
        {
            if (_tasks.Count == 0)
            {
                _view.ShowMessage("No hay tareas registradas.");
                return;
            }

            _view.ShowTasks(_tasks);
            int id = _view.ReadId();
            int index = FindTaskIndex(id);

            if (index == -1)
            {
                _view.ShowMessage("La tarea no existe.");
                return;
            }

            if (_tasks[index].IsCompleted())
            {
                _view.ShowMessage("La tarea ya estaba completada.");
                return;
            }

            _tasks[index].Complete();
            _view.ShowMessage("Tarea marcada como completada.");
        }

        private void RemoveTask()
        {
            if (_tasks.Count == 0)
            {
                _view.ShowMessage("No hay tareas registradas.");
                return;
            }

            _view.ShowTasks(_tasks);
            int id = _view.ReadId();
            int index = FindTaskIndex(id);

            if (index == -1)
            {
                _view.ShowMessage("La tarea no existe.");
                return;
            }

            _tasks.RemoveAt(index);
            _view.ShowMessage("Tarea eliminada.");
        }

        private int FindTaskIndex(int id)
        {
            for (int i = 0; i < _tasks.Count; i++)
            {
                if (_tasks[i].GetId() == id)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
