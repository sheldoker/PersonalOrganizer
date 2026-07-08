using System;

namespace PersonalOrganizer.Domain.Entities
{
    public class Category
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Color { get; private set; }
        public string Icon { get; private set; }

        public Category(string name, string description, string color, string icon)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Название не может быть пустым", nameof(name));
            }

            if (string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentException("Описание не может быть пустым", nameof(description));
            }

            if (string.IsNullOrWhiteSpace(color))
            {
                throw new ArgumentException("Цвет не может быть пустым", nameof(color));
            }

            if (string.IsNullOrWhiteSpace(icon))
            {
                throw new ArgumentException("Иконка не может быть пустой", nameof(icon));
            }

            Name = name;
            Description = description;
            Color = color;
            Icon = icon;
        }

        public void Rename(string name)
        {
            if (Name == name)
            {
                return;
            }
                
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Название не может быть пустым", nameof(name));
            }

            Name = name;
        }

        public void ChangeDescription(string description)
        {
            if (Description == description)
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentException("Описание не может быть пустым", nameof(description));
            }

            Description = description;
        }
        public void ChangeColor(string color)
        {
            if (Color == color)
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(color))
            {
                throw new ArgumentException("Цвет не может быть пустым", nameof(color));
            }

            Color = color;
        }

        public void ChangeIcon(string icon)
        {
            if (Icon == icon)
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(icon))
            {
                throw new ArgumentException("Иконка не может быть пустой", nameof(icon));
            }

            Icon = icon;
        }
    }
}
