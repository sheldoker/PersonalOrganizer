using System;

namespace PersonalOrganizer.Domain.Entities
{
    public class Note
    {
        private readonly List<Tag> _tags = new();
        public IReadOnlyCollection<Tag> Tags => _tags.AsReadOnly();

        private readonly List<ToDo> _tasks = new();
        public IReadOnlyCollection<ToDo> Tasks => _tasks.AsReadOnly();

        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsFavorite { get; set; }
        public bool IsPinned { get; set; }
        public bool IsArchived { get; set; }
        public Category Category { get; set; } = null;
        public int CategoryId { get; set; }
        public Note() { }

        public Note(string title, string text, Category category)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Название не может быть пустым.", nameof(title));
            }

            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentException("Текст не может быть пустым.", nameof(text));
            }

            if (category is null)
            {
                throw new ArgumentNullException(nameof(category));
            }

            Title = title;
            Text = text;

            var now = DateTime.Now;
            CreatedAt = now;
            UpdatedAt = now;
            Category = category;
        }

        private void UpdateTime()
        {
            UpdatedAt = DateTime.Now;
        }

        public void Update(string title, string text)
        {
            if (Title == title && Text == text)
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Название не может быть пустым.", nameof(title));
            }

            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentException("Текст не может быть пустым.", nameof(text));
            }

            Title = title;
            Text = text;
            UpdateTime();
        }

        public void Pin()
        {
            if (IsPinned)
            {
                return;
            }

            IsPinned = true;
            UpdateTime();
        }

        public void Unpin()
        {
            if (!IsPinned)
            {
                return;
            }

            IsPinned = false;
            UpdateTime();
        }

        public void Archive()
        {
            if (IsArchived)
            {
                return;
            }

            IsArchived = true;
            UpdateTime();
        }

        public void Unarchive()
        {
            if (!IsArchived)
                return;
            IsArchived = false;
            UpdateTime();
        }

        public void AddToFavorites()
        {
            if (IsFavorite)
            {
                return;
            }

            IsFavorite = true;
            UpdateTime();
        }

        public void RemoveFromFavorites()
        {
            if (!IsFavorite)
            {
                return;
            }

            IsFavorite = false;
            UpdateTime();
        }

        public void ChangeCategory(Category category)
        {
            if (category is null)
            {
                throw new ArgumentNullException(nameof(category));
            }

            if (Category == category)
            {
                return;
            }

            Category = category;
            UpdateTime();
        }

        public void AddTag(Tag tag)
        {
            if (tag is null)
            {
                throw new ArgumentNullException(nameof(tag));
            }

            if (_tags.Count >= 10)
            {
                throw new InvalidOperationException("Нельзя добавить больше 10 тегов.");
            }

            foreach (Tag currentTag in _tags)
            {
                if (currentTag == tag)
                {
                    return;
                }
            }

            _tags.Add(tag);
            UpdateTime();
        }

        public void RemoveTag(Tag tag)
        {
            if (tag is null)
            {
                throw new ArgumentNullException(nameof(tag));
            }

            foreach (Tag currentTag in _tags)
            {
                if (currentTag == tag)
                {
                    _tags.Remove(tag);
                    UpdateTime();
                    return;
                }
            }
        }

        public void ClearTags()
        {
            if (_tags.Count == 0)
            {
                return;
            }

            _tags.Clear();
            UpdateTime();
        }

        public void AddTask(ToDo task)
        {
            if (task is null)
            {
                throw new ArgumentNullException(nameof(task));
            }

            foreach (ToDo currentTask in _tasks)
            {
                if (currentTask == task)
                {
                    return;
                }
            }

            _tasks.Add(task);
            UpdateTime();
        }

        public void RemoveTask(ToDo task)
        {
            if (task is null)
            {
                throw new ArgumentNullException(nameof(task));
            }

            foreach (ToDo currentTask in _tasks)
            {
                if (currentTask == task)
                {
                    _tasks.Remove(task);
                    UpdateTime();
                    return;
                }
            }
        }

        public void ClearTasks()
        {
            if (_tasks.Count == 0)
            {
                return;
            }

            _tasks.Clear();
            UpdateTime();
        }
    }
}

