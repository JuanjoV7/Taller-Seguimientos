using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskList.Models
{
    public class TaskItem
    {
        private int _id;
        private string _title;
        private bool _isCompleted;

        public TaskItem(int id, string title)
        {
            _id = id;
            _title = title;
            _isCompleted = false;
        }

        public int GetId()
        {
            return _id;
        }

        public string GetTitle()
        {
            return _title;
        }

        public bool IsCompleted()
        {
            return _isCompleted;
        }

        public void Complete()
        {
            _isCompleted = true;
        }
    }
}
