using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class GameSessionDAO
    {
        public static List<GameSession> GetGameSessions()
        {
            var listGameSessions = new List<GameSession>();
            try
            {
                using (var context = new CloneKahootContext())
                {
                    listGameSessions = context.GameSessions.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listGameSessions;
        }

        public static void SaveGameSession(GameSession gameSession)
        {
            try
            {
                using (var context = new CloneKahootContext())
                {
                    context.GameSessions.Add(gameSession);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateGameSession(GameSession gameSession)
        {
            try
            {
                using (var context = new CloneKahootContext())
                {
                    context.Entry(gameSession).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteGameSession(int gameSessionID)
        {
            try
            {
                using (var context = new CloneKahootContext())
                {
                    var gameSessionToDelete = context.GameSessions.SingleOrDefault(g => g.GameSessionId == gameSessionID);
                    context.GameSessions.Remove(gameSessionToDelete);
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
