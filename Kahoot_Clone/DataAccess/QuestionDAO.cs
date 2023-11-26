using BusinessObjects.Models;

namespace DataAccess
{
    public class QuestionDAO
    {
        public static List<Question> GetQuestions()
        {
            var listQuestions = new List<Question>();
            try
            {
                using (var context = new CloneKahootContext())
                {
                    listQuestions = context.Questions.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listQuestions;
        }

        public static List<Question> GetQuestionsByGameID(int gameId)
        {
            var listQuestions = new List<Question>();
            try
            {
                using (var context = new CloneKahootContext())
                {
                    listQuestions = context.Questions.Where(q => q.GameId == gameId).ToList();
                    listQuestions.ForEach(question =>
                    {
                        question.Game = context.Games.Find(question.GameId);
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listQuestions;
        }


        public static Question GetQuestion(int questionId)
        {
            Question question = new Question();
            try
            {
                using (var context = new CloneKahootContext())
                {
                    question = context.Questions.Where(q => q.QuestionId == questionId).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return question;
        }

        public static void SaveQuestion(Question question)
        {
            try
            {
                using (var context = new CloneKahootContext())
                {
                    context.Questions.Add(question);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateQuestion(Question question)
        {
            try
            {
                using (var context = new CloneKahootContext())
                {
                    context.Entry(question).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteQuestion(int questionID)
        {
            try
            {
                using (var context = new CloneKahootContext())
                {
                    var questionToDelete = context.Questions.SingleOrDefault(g => g.QuestionId == questionID);
                    context.Questions.Remove(questionToDelete);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}