using BusinessObjects.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.impl
{
    public class QuestionRepository : IQuestionRepository
    {
        public void DeleteQuestion(int questionID) => QuestionDAO.DeleteQuestion(questionID);

        public List<Question> GetQuestions() => QuestionDAO.GetQuestions();

        public Question GetQuestion(int questionId) => QuestionDAO.GetQuestion(questionId);

        public List<Question> GetQuestionsByGameID(int gameId) => QuestionDAO.GetQuestionsByGameID(gameId);

        public void SaveQuestion(Question question) => QuestionDAO.SaveQuestion(question);

        public void UpdateQuestion(Question question) => QuestionDAO.UpdateQuestion(question);
    }
}
