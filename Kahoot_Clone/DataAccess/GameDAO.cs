using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
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
                    listGames.ForEach(game =>
                    {
                        game.User = context.Users.Find(game.UserId);
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listGames;
        }

        public static List<string> GetListCode()
        {
            List<string> listCode = new List<string>();
            try
            {
                using (var context = new CloneKahootContext())
                {
                    listCode = context.Games.Select(g => g.PinCode).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listCode;
        }

        public static Game GetGameByCodePin(string codePin)
        {
            Game game = new Game();
            try
            {
                using (var context = new CloneKahootContext())
                {
                    game = context.Games.SingleOrDefault(g => g.PinCode == codePin);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return game;
        }

        public static Game GetGameByGameID(int gameId)
        {
            Game game = new Game();
            try
            {
                using (var context = new CloneKahootContext())
                {
                    game = context.Games.Include(g => g.User).Where(g => g.GameId == gameId).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return game;
        }

        public static List<Game> GetGameByUserID(int userId)
        {
            var listGames = new List<Game>();
            try
            {
                using (var context = new CloneKahootContext())
                {
                    listGames = context.Games.Where(g => g.UserId == userId).ToList();
                    listGames.ForEach(game =>
                    {
                        game.User = context.Users.Find(game.UserId);
                    });
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
