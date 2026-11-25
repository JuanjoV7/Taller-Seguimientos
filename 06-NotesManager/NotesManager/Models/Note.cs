using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesManager.Models
{
    public class Note
    {
        private int _id;
        private string _title;
        private string _content;
        private string _category;
        private DateTime _createdAt;

        public Note(int id, string title, string content, string category)
        {
            _id = id;
            _title = title;
            _content = content;
            _category = category;
            _createdAt = DateTime.Now;
        }

        public int GetId()
        {
            return _id;
        }

        public string GetTitle()
        {
            return _title;
        }

        public string GetContent()
        {
            return _content;
        }

        public string GetCategory()
        {
            return _category;
        }

        public DateTime GetCreatedAt()
        {
            return _createdAt;
        }

        public bool ContainsText(string text)
        {
            string searchText = text.ToLower();

            if (_title.ToLower().Contains(searchText) || _content.ToLower().Contains(searchText))
            {
                return true;
            }

            return false;
        }
    }
}
