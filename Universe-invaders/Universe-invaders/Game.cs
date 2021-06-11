using System;
using System.Collections.Generic;
using System.Drawing;
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
        public Size clientSize;
        public bool IsMenuMusicOff = false;
        public bool IsGameMusicOff = false;

        public Game()
        {
            this.Player = new Player();
            GameUpgrades = new List<GameUpgrade>();
            GameUpgrades.Add(new GameUpgrade("Simple Soldier", 5, 1, 0));
            GameUpgrades.Add(new GameUpgrade("the Rifleman", 25, 10, 15));
            GameUpgrades.Add(new GameUpgrade("Robot", 150, 50, 75));
            GameUpgrades.Add(new GameUpgrade("Spaceship crew", 1000, 150, 300));
            GameUpgrades.Add(new GameUpgrade("Space explorers", 5000, 500, 1000));

            CurrentLevel = 1;
            
            CurrentMonster = new Monster(GetNextMonsterName(), 10, 2);
        }

        public static string GetNextMonsterName()
        {
            string nextMonsterName = null;
            var rnd = new Random();
            var numberOfNextMonster = rnd.Next() % 3;

            switch (numberOfNextMonster)
            {
                case 0:
                    nextMonsterName = "OrangeMonster";
                    break;
                case 1:
                    nextMonsterName = "BlueMonster";
                    break;
                case 2:
                    nextMonsterName = "PurpleMonster";
                    break;
            }

            return nextMonsterName;
        }
    }
}