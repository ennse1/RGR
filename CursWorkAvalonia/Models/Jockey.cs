using System;
using System.Collections.Generic;

// Класс представление отношения Жокей

namespace CursWorkAvalonia
{
    public partial class Jockey
    {
        public long JockeyId { get; set; }
        public string? Name { get; set; }
        public string? Nationality { get; set; }
        public long? Income { get; set; }
    }
}
