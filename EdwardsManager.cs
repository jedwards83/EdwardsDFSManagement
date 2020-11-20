using System.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;


namespace EdwardsManagement
{
    public class EdwardsManager
    {
        public void LoadPlayers(string path)
        {
            if (File.Exists(path))
            {
                var json = File.ReadAllText(path);
                try
                {
                    _players = JsonConvert.DeserializeObject<List<Player>>(json);
                }
                catch
                {
                }
            }
        }
        private List<Player> _players = new List<Player>();

        public void SavePlayers(string path)
        {
            //save the players list to a file
            var playersJson = JsonConvert.SerializeObject(_players);
            File.WriteAllText(path, playersJson);
        }
        public int GetNextPlayerSalary()
        {
            Console.WriteLine("How much does the player cost?");
            var playerSalary = Convert.ToInt32(Console.ReadLine());
            
            return playerSalary;
        }

        public void AddNewPlayer(Player playerToAdd)
        {
            if (playerToAdd is null)
            {
                throw new ArgumentNullException(nameof(playerToAdd));
            }

            _players.Add(playerToAdd);
        }

        public Player LoadPlayerBySalary(int playerSalary)
        {
            return _players.Where(p => p.Salary == playerSalary).SingleOrDefault();
        }

        public List<Player> FindByName(string nameToSearch)
        {
            return _players.Where(p => p.FirstName.Contains(nameToSearch) || p.LastName.Contains(nameToSearch)).ToList();
        }

        public List<Player> GetAllPlayers()
        {
            return _players.ToList();
        }
        public List<Player> FindByMaxSalary(int playerMaxSalary)
        {
            return _players.Where(p => p.Salary <= (playerMaxSalary)).ToList();
        }

    }
}
