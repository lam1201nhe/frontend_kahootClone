using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class QuestionChoice
    {
        public int QuestionId { get; set; }
        public int ChoiceId { get; set; }
        public bool CorrectAnswer { get; set; }

        public virtual Choice Choice { get; set; } = null!;
        public virtual Question Question { get; set; } = null!;
    }
}
