using System;
using System.Collections.Generic;

// Класс представление отношения Владелец

namespace CursWorkAvalonia
{
    public partial class Owner
    {
        public Owner()
        {
            Horses = new HashSet<Horse>();
        }

        public long OwnerId { get; set; }
        public string? Title { get; set; }
        public long? Income { get; set; }

        public virtual ICollection<Horse> Horses { get; set; }
    }
}
