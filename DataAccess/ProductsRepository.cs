﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace DataAccess
{
    public class ProductsRepository : MyConnectionClass
    {
        public ProductsRepository() : base() { }
        
        public IQueryable<Player> GetPlayers() 
        {
            return Context.Players.AsQueryable();
        }
        
        public void AddPlayer(string username, string password)
        {
            Player player = new Player
            {
                Username = username,
                Password = password
            };

            Context.Players.Add(player);
            Context.SaveChanges();
        }

        public void AddPlayerToGames(string creator, string opponent)
        {

            Game game = new Game
            {
                Title = $"{creator} vs {opponent}",
                CreatorFK = creator,
                OpponentFK = opponent,
                Complete = false
            };

            Context.Games.Add(game);
            Context.SaveChanges();
        }

        public void DeletePlayer(Player player)
        {
            Context.Players.Remove(player);
            Context.SaveChanges();
        }

        public Player GetPlayerById(int id)
        {
            return GetPlayers().SingleOrDefault(p => p.ID == id);
        }

        public string GetPlayerPassword(string username)
        {
             var pass = from player in Context.Players
                       where player.Username == username
                       select player.Password;
            
            return pass.FirstOrDefault();
        }

        public Player GetPlayerByUsername(string username)
        {
            return GetPlayers().SingleOrDefault(p => p.Username == username);
        }

        public IQueryable<Player> GetPlayers(string keyword)
        {
            return GetPlayers().Where(p => p.Username.Contains(keyword));
        }

        public List<Ship> ShowShips()
        {
            var ships = Context.Ships.ToList();

            return ships;
        }

        public Ship GetShipByID(int shipChosen)
        {
            return Context.Ships.FirstOrDefault(x => x.ID == shipChosen);
        }

        public int GetGame(string creator, string opponent)
        {
            var ongoingGame = from Game in Context.Games
                              where (Game.CreatorFK == creator) && (Game.OpponentFK == opponent)
                              select Game.ID;

            return ongoingGame.FirstOrDefault();
        }


        public int GetShipByIDSize(int shipChosen)
        {
            var shipSize = from Ship in Context.Ships
                           where Ship.ID == shipChosen
                           select Ship.Size;

            return shipSize.FirstOrDefault();
        }

       public void addShipToConfig(string ShipString, string player, int game, int ship)
        {
            GameShipConfiguration gsc = new GameShipConfiguration
            {
                PlayerFK = player,
                GameFK = game,
                Coordinate = ShipString,
                ShipFK = ship
            };
            Context.GameShipConfigurations.Add(gsc);
            Context.SaveChanges();
        }

        public List<string> checkCollision(string playerPlaying)
        {
            List<string> coordinatesInList = new List<string>(); 
            var shipCoordinates = Context.GameShipConfigurations.Where(x => x.PlayerFK == playerPlaying).Select(GameShipConfiguration => GameShipConfiguration.Coordinate).ToList();
                foreach (var coor in shipCoordinates)
                {
                    string[] stringArray = coor.Split(',');

                    foreach (var arr in stringArray)
                    {
                        coordinatesInList.Add(arr);
                    }
                }
            return coordinatesInList;
        }

    }
}
