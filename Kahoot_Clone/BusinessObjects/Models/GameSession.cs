using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class GameSession
    {
        public int GameSessionId { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public int GameId { get; set; }
        public int? PlayerId { get; set; }

        public virtual Game Game { get; set; } = null!;
        public virtual Player? Player { get; set; }
    }
}
