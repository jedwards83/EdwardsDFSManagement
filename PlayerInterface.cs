using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EdwardsManagement
{
    class PlayerInterface
    {
        const string path = "PlayerDB.json";
        private PlayerManager _playerManager = new PlayerManager();

        public PlayerInterface()
        {
            _playerManager.LoadContacts(path);
        }
    }
}
