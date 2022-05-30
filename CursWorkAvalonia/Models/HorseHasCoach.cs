using System;
using System.Collections.Generic;

// Класс представление отношения Лошадь-Коуч

namespace CursWorkAvalonia
{
    public partial class HorseHasCoach
    {
        public long? HorseId { get; set; }
        public long? CoachId { get; set; }

        public virtual Coach? Coach { get; set; }
        public virtual Horse? Horse { get; set; }
    }
}
