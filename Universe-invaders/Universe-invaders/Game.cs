using System.Collections.Generic;

namespace Universe_invaders
{
    public class Game
    {
        public Player Player;
        public List<GameUpgrade> GameUpgrades;

        public Game()
        {
            this.Player = new Player();
            GameUpgrades = new List<GameUpgrade>();
        }
    }
}