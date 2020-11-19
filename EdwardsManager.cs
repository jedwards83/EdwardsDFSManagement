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
                    _players = JsonConvert.DeserializeObject<List<Players>>(json);
                }
                catch
                {
                }
            }
        }
        private List<Players> _players = new List<Players>();

        public void SavePlayers(string path)
        {
            //save the players list to a file
            var playersJson = JsonConvert.SerializeObject(_players);
            File.WriteAllText(path, playersJson);
        }
        public int GetNextPlayerSalary()
        {
        var lastPlayerSalary = 0;
            if (_players.Any())
                lastPlayerSalary = _players.Max(p => p.Salary);

            return lastPlayerSalary;
        }

        public void AddNewPlayer(Players contactToAdd)
        {
            _players.Add(contactToAdd);
        }

        public Players LoadPlayerBySalary(int playerSalary)
        {
            return _players.Where(p => p.Salary == playerSalary).SingleOrDefault();
        }

        public List<Players> FindByName(string nameToSearch)
        {
            return _players.Where(p => p.FirstName.Contains(nameToSearch) || p.LastName.Contains(nameToSearch)).ToList();
        }

        public List<Players> GetAllContacts()
        {
            return _players.ToList();
        }

    }
}
