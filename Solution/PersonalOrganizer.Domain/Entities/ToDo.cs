using System;
using PersonalOrganizer.Domain.Enums;

namespace PersonalOrganizer.Domain.Entities
{
    public class ToDo
    {
        private readonly List<ToDo> _subTasks = new();

        public IReadOnlyCollection<ToDo> SubTasks => _subTasks.AsReadOnly();

        public int Id { get; private set; }
        public string Title { get; private set; } 
        public bool IsCompleted { get; private set; }
        public DateTime? DueDate { get; private set; }
        public Priority Priority { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        protected ToDo() { }
        public ToDo(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Название не может быть пустым.", nameof(title));
            }

            Title = title;

            var now = DateTime.Now;
            CreatedAt = now;
            UpdatedAt = now;
        }

        private void UpdateTime()
        {
            UpdatedAt = DateTime.Now;
        }
        public void Rename(string title)
        {
            if (Title == title)
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Название не может быть пустым.", nameof(title));
            }

            Title = title;
            UpdateTime();
        }

        public void Complete()
        {
            if (IsCompleted == true)
            {
                return;
            }

            IsCompleted = true;
            UpdateTime();
        }

        public void ChangeDueDate(DateTime? dueDate)
        {
            DueDate = dueDate;
            UpdateTime();
        }

        public void Reopen()
        {
            if (IsCompleted == false)
            {
                return;
            }

            IsCompleted = false;
            UpdateTime();
        }

        public void ChangePriority(Priority priority)
        {
            if (Priority == priority)
            {
                return;
            }

            Priority = priority;
            UpdateTime();
        }

        public void AddSubTask(ToDo subTask)
        {
            if (subTask is null)
            {
                throw new ArgumentNullException(nameof(subTask));
            }

            if (subTask == this)
            {
                throw new InvalidOperationException("Задача не может быть своей собственной подзадачей.");
            }

            foreach (ToDo currentToDo in _subTasks)
            {
                if (currentToDo == subTask)
                {
                    return;
                }
            }

            _subTasks.Add(subTask);
            UpdateTime();
        }

        public void RemoveSubTask(ToDo subTask)
        {
            if (subTask is null)
            {
                throw new ArgumentNullException(nameof(subTask));
            }

            foreach (ToDo currentToDo in _subTasks)
            {
                if (currentToDo == subTask)
                {
                    _subTasks.Remove(subTask);
                    UpdateTime();
                    return;
                }
            }
        }

        public void ClearSubTasks()
        {
            if (_subTasks.Count == 0)
            {
                return;
            }

            _subTasks.Clear();
            UpdateTime();
        }
    }
}

