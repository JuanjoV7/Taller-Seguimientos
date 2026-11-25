using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskList.Models;

namespace TaskList.Views
{
    public class TaskView
    {
        public int ShowMenu()
        {
            Console.WriteLine();
            Console.WriteLine("===== LISTA DE TAREAS =====");
            Console.WriteLine("1. Agregar tarea");
            Console.WriteLine("2. Ver tareas");
            Console.WriteLine("3. Marcar tarea como completada");
            Console.WriteLine("4. Eliminar tarea");
            Console.WriteLine("0. Salir");
            Console.WriteLine("Digite una opción: ");
            return int.Parse(Console.ReadLine());
        }

        public string ReadTitle()
        {
            Console.WriteLine("Digite el nombre de la tarea: ");
            return Console.ReadLine();
        }

        public int ReadId()
        {
            Console.WriteLine("Digite el número de la tarea: ");
            return int.Parse(Console.ReadLine());
        }

        public void ShowTasks(List<TaskItem> tasks)
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("No hay tareas registradas.");
                return;
            }

            foreach (TaskItem task in tasks)
            {
                string status = "Pendiente";

                if (task.IsCompleted())
                {
                    status = "Completada";
                }

                Console.WriteLine($"{task.GetId()}. {task.GetTitle()} - {status}");
            }
        }

        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
