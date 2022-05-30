using System;
using System.Collections.Generic;

// Класс представление отношения Гонка

namespace CursWorkAvalonia
{
    public partial class Race
    {
        public Race()
        {
            Horses = new HashSet<Horse>();
        }

        public long RaceId { get; set; }
        public string? Data { get; set; }
        public string? Winner { get; set; }

        public virtual ICollection<Horse> Horses { get; set; }
    }
}
