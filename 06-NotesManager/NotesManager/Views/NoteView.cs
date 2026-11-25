using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotesManager.Models;

namespace NotesManager.Views
{
    public class NoteView
    {
        public int ShowMenu()
        {
            Console.WriteLine();
            Console.WriteLine("===== GESTOR DE NOTAS =====");
            Console.WriteLine("1. Escribir nota");
            Console.WriteLine("2. Ver todas las notas");
            Console.WriteLine("3. Ver notas por categoría");
            Console.WriteLine("4. Buscar nota");
            Console.WriteLine("5. Eliminar nota");
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

        public void ShowCategories(string[] categories)
        {
            for (int i = 0; i < categories.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {categories[i]}");
            }
        }

        public void ShowNotes(List<Note> notes)
        {
            if (notes.Count == 0)
            {
                Console.WriteLine("No hay notas para mostrar.");
                return;
            }

            foreach (Note note in notes)
            {
                Console.WriteLine();
                Console.WriteLine($"#{note.GetId()} [{note.GetCategory()}] {note.GetTitle()} - {note.GetCreatedAt().ToString("dd/MM/yyyy HH:mm")}");
                Console.WriteLine($"   {note.GetContent()}");
            }
        }

        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
