using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class GameDAO
    {
        public static List<Game> GetGames()
        {
            var listGames = new List<Game>();
            try
            {
                using (var context = new CloneKahootContext())
                {
                    listGames = context.Games.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listGames;
        }

        public static void SaveGame(Game game)
        {
            try
            {
                using (var context = new CloneKahootContext())
                {
                    context.Games.Add(game);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateGame(Game game)
        {
            try
            {
                using (var context = new CloneKahootContext())
                {
                    context.Entry(game).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteGame(int gameID)
        {
            try
            {
                using (var context = new CloneKahootContext())
                {
                    var gameToDelete = context.Games.SingleOrDefault(g => g.GameId ==  gameID);
                    context.Games.Remove(gameToDelete);
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
