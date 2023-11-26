using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IQuestionRepository
    {
        List<Question> GetQuestions();
        Question GetQuestion(int questionId);
        List<Question> GetQuestionsByGameID(int gameId);
        void SaveQuestion(Question question);
        void UpdateQuestion(Question question);
        void DeleteQuestion(int questionID);
    }
}
