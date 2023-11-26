using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class Game
    {
        public Game()
        {
            GameSessions = new HashSet<GameSession>();
            Questions = new HashSet<Question>();
        }

        public int GameId { get; set; }
        public string Name { get; set; } = null!;
        public string PinCode { get; set; }
        public int UserId { get; set; }
        public int? Publish { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual ICollection<GameSession> GameSessions { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}
