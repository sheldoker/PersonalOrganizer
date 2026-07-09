using System;

namespace PersonalOrganizer.Domain.Entities
{
    public class Tag
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public Tag(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Название не должно быть пустым", nameof(name));
            }
            Name = name;
        }

        public void Rename(string name)
        {
            if (Name == name)
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Название не должно быть пустым", nameof(name));
            }

            Name = name;
        }
    }
}
