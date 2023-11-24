using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class Player
    {
        public Player()
        {
            GameSessions = new HashSet<GameSession>();
        }

        public int PlayerId { get; set; }
        public string PlayerName { get; set; } = null!;
        public int? Score { get; set; }

        public virtual ICollection<GameSession> GameSessions { get; set; }
    }
}
