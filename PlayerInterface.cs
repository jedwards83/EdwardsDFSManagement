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
                //list contacts
                Console.WriteLine("1. List all players");
                //search contacts
                Console.WriteLine("2. Search by name");
                //view contact
                Console.WriteLine("3. Search by Salary");
                //add contact
                Console.WriteLine("4. Find all Below Salary");

                var action = Console.ReadLine();
            }
        }
    }
}
