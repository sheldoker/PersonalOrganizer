using System;

namespace PersonalOrganizer.Domain.Entities
{
    public class Note
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Text { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public bool IsFavorite { get; private set; }
        public bool IsPinned { get; private set; }
        public bool IsArchived { get; private set; }

        public Note(string title, string text)
        {
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

            var now = DateTime.Now;
            CreatedAt = now;
            UpdatedAt = now;
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
            if(!IsPinned)
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
    }
}   

