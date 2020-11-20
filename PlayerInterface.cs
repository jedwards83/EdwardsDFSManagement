using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EdwardsManagement
{
    class PlayerInterface
    {
        const string path = "PlayerDB.json";
        private EdwardsManager _edwardsManager = new EdwardsManager();

        public PlayerInterface()
        {
            _edwardsManager.LoadPlayers(path);
        }
        //build loop interface
        internal void StartPlayerInterface()
        {
            var shouldExit = false;
            while (!shouldExit)
            {
                Console.WriteLine("What player are you looking for?");
                //menu options
                //exit
                Console.WriteLine("0. Exit Player Manager");
                //list all active players
                Console.WriteLine("1. List all players");
                //search players by name
                Console.WriteLine("2. Search by name");
                //view player by salary
                Console.WriteLine("3. Search by Salary");
                //add players to the list
                Console.WriteLine("4. Add new Player");
                //Find By Max Salary so that when building lineups people can filter out players that exceed salary limitations
                Console.WriteLine("5. Find all Below Salary");

                var action = Console.ReadLine();
                switch (action)
                {
                    case "0":
                        {
                            shouldExit = true;
                            break;
                        }
                    case "1":
                        {
                            ListAllPlayers();
                            break;
                        }
                    case "2":
                        {
                            StartSearchPlayerUserInterface();
                            break;
                        }
                    case "3":
                        {
                            StartPlayerLoadInterface();
                            break;
                        }
                    case "4":
                        {
                            StartAddPlayerInterface();
                            break;
                        }
                    case "5":
                        {
                            StartSearchSalaryMax();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine($"Invalid Entry {action}");
                            break;
                        }
                }
            }
            //end loop

            _edwardsManager.SavePlayers(path);
        }
        private void ListAllPlayers()
        {
            foreach (var player in _edwardsManager.GetAllPlayers())
            {
                Console.WriteLine(player.ToString());
            }
        }
        private void StartSearchInterface()
        {
            Console.WriteLine("What name do you want to search for?");
            var nameToSearch = Console.ReadLine();

            var foundPlayers = _edwardsManager.FindByName(nameToSearch);

            Console.WriteLine($"{foundPlayers.Count()} player(s) found");
            foreach (var player in foundPlayers)
            {
                Console.WriteLine(player.ToString());
            }
        }
        private bool LastNameIsValid(string lastName)
        {
            if (string.IsNullOrWhiteSpace(lastName))
                return false;

            if (lastName.Contains(" "))
                return false;

            return true;
        }
        private bool FirstNameIsValid(string firstName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                return false;

            if (firstName.Contains(" "))
                return false;

            return true;
        }
        private void StartAddPlayerInterface()
        {
            string firstName = null;
            string lastName = null;

            while (!FirstNameIsValid(firstName))
            {
                Console.WriteLine("Enter a valid first name:");
                firstName = Console.ReadLine();
            }

            while (!LastNameIsValid(lastName))
            {
                Console.WriteLine("Enter a valid last name:");
                lastName = Console.ReadLine();
            }

            var newPlayerSalary = _edwardsManager.GetNextPlayerSalary();

            var playerToAdd = new Player
            {
                FirstName = firstName,
                LastName = lastName,
                Salary = newPlayerSalary
            };

            _edwardsManager.AddNewPlayer(playerToAdd);
        }


        private void StartPlayerLoadInterface()
        {
            Console.WriteLine("What is the Salary of the user to load?");

            if (!int.TryParse(Console.ReadLine(), out int playerSalary))
            {
                Console.WriteLine("Invalid Salary");
                return;
            }

            var playerToLoad = _edwardsManager.LoadPlayerBySalary(playerSalary);

            if (playerToLoad != null)
            {
                playerToLoad.ToString();

                Console.WriteLine("What would you like to do?");
                Console.WriteLine("0. Exit player menu");
                Console.WriteLine("1. Edit this player");
                Console.WriteLine("2. Remove this player");

                throw new NotImplementedException();
            }
            else
            {
                Console.WriteLine($"Invalid player Salary {playerSalary}");
            }
        }
        private void StartSearchPlayerUserInterface()
        {
            Console.WriteLine("What Player do you want to search for?");
            var nameToSearch = Console.ReadLine();

            var foundPlayers = _edwardsManager.FindByName(nameToSearch);

            Console.WriteLine($"{foundPlayers.Count()} players(s) found");
            foreach (var player in foundPlayers)
            {
                Console.WriteLine(player.ToString());
            }
        }
        private void StartSearchSalaryMax()
        {
            Console.WriteLine("What is the max Salary you are able to use?");
            var playerMaxSalary = Convert.ToInt32(Console.ReadLine());

            var salaryCap = _edwardsManager.FindByMaxSalary(playerMaxSalary);

            Console.WriteLine($"{salaryCap.Count()} players(s) found");
            foreach (var player in salaryCap)
            {
                Console.WriteLine(player.ToString());
            }

        }
    }
}