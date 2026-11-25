using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotesManager.Models;
using NotesManager.Views;

namespace NotesManager.Controllers
{
    public class NoteController
    {
        private List<Note> _notes;
        private string[] _categories;
        private NoteView _view;
        private int _nextId;

        public NoteController()
        {
            _notes = new List<Note>();
            _categories = new string[] { "Personal", "Trabajo", "Estudio", "Ideas", "Otros" };
            _view = new NoteView();
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
                        AddNote();
                        break;
                    case 2:
                        _view.ShowNotes(_notes);
                        break;
                    case 3:
                        ShowNotesByCategory();
                        break;
                    case 4:
                        SearchNotes();
                        break;
                    case 5:
                        RemoveNote();
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

        private void AddNote()
        {
            string title = _view.ReadText("Digite el título de la nota: ");

            if (title == "")
            {
                _view.ShowMessage("El título no puede estar vacío.");
                return;
            }

            string content = _view.ReadText("Escriba el contenido de la nota: ");

            _view.ShowCategories(_categories);
            int categoryOption = _view.ReadNumber("Seleccione la categoría: ");

            if (categoryOption < 1 || categoryOption > _categories.Length)
            {
                _view.ShowMessage("Categoría no válida.");
                return;
            }

            Note note = new Note(_nextId, title, content, _categories[categoryOption - 1]);
            _notes.Add(note);
            _nextId++;

            _view.ShowMessage("Nota guardada.");
        }

        private void ShowNotesByCategory()
        {
            _view.ShowCategories(_categories);
            int categoryOption = _view.ReadNumber("Seleccione la categoría: ");

            if (categoryOption < 1 || categoryOption > _categories.Length)
            {
                _view.ShowMessage("Categoría no válida.");
                return;
            }

            string category = _categories[categoryOption - 1];
            List<Note> notesInCategory = new List<Note>();

            foreach (Note note in _notes)
            {
                if (note.GetCategory() == category)
                {
                    notesInCategory.Add(note);
                }
            }

            _view.ShowNotes(notesInCategory);
        }

        private void SearchNotes()
        {
            string text = _view.ReadText("Digite la palabra a buscar: ");

            if (text == "")
            {
                _view.ShowMessage("Debe escribir algo para buscar.");
                return;
            }

            List<Note> results = new List<Note>();

            foreach (Note note in _notes)
            {
                if (note.ContainsText(text))
                {
                    results.Add(note);
                }
            }

            _view.ShowMessage($"Se encontraron {results.Count} nota(s).");
            _view.ShowNotes(results);
        }

        private void RemoveNote()
        {
            if (_notes.Count == 0)
            {
                _view.ShowMessage("No hay notas registradas.");
                return;
            }

            _view.ShowNotes(_notes);
            int id = _view.ReadNumber("Digite el número de la nota a eliminar: ");
            int index = FindNoteIndex(id);

            if (index == -1)
            {
                _view.ShowMessage("La nota no existe.");
                return;
            }

            _notes.RemoveAt(index);
            _view.ShowMessage("Nota eliminada.");
        }

        private int FindNoteIndex(int id)
        {
            for (int i = 0; i < _notes.Count; i++)
            {
                if (_notes[i].GetId() == id)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
