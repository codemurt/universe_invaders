using System.Collections.Generic;
using System.Windows.Forms;

namespace Universe_invaders
{
    public class Game
    {
        public Player Player;
        public List<GameUpgrade> GameUpgrades;
        public int CurrentLevel;
        public Monster CurrentMonster;
        public int HealthMin = 10;
        public int MoneyWinMin = 2;
        public Timer timer;

        public Game()
        {
            this.Player = new Player();
            GameUpgrades = new List<GameUpgrade>();
            GameUpgrades.Add(new GameUpgrade("Simple Soldier", 5, 1, 0));
            GameUpgrades.Add(new GameUpgrade("the Rifleman", 25, 10, 15));
            GameUpgrades.Add(new GameUpgrade("Robot", 150, 50, 75));
            GameUpgrades.Add(new GameUpgrade("Spaceship crew", 500, 150, 300));
            GameUpgrades.Add(new GameUpgrade("Space explorers", 3000, 500, 850));

            CurrentLevel = 1;
            
            CurrentMonster = new Monster("OrangeMonster", 10, 2);
        }
    }
}