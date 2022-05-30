using System;
using System.Collections.Generic;

// Класс представление отношения Лошадь-Жокей

namespace CursWorkAvalonia
{
    public partial class HorseHasJockey
    {
        public long? HorseId { get; set; }
        public long? JockeyId { get; set; }

        public virtual Horse? Horse { get; set; }
    }
}
