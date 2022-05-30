using System;
using System.Collections.Generic;

// Класс представление отношения Лошадь

namespace CursWorkAvalonia
{
    public partial class Horse
    {
        public long HorseId { get; set; }
        public string? Name { get; set; }
        public double? Rating { get; set; }
        public string? Breed { get; set; }
        public long? OwnerId { get; set; }
        public long? RaceId { get; set; }

        public virtual Owner? Owner { get; set; }
        public virtual Race? Race { get; set; }
    }
}
