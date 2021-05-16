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
            GameUpgrades.Add(new GameUpgrade("Simple Soldier", 5, 1, 0));
            GameUpgrades.Add(new GameUpgrade("the Rifleman", 25, 10, 15));
            GameUpgrades.Add(new GameUpgrade("Robot", 100, 50, 75));
            GameUpgrades.Add(new GameUpgrade("Spaceship crew", 250, 150, 300));
            
        }
    }
}