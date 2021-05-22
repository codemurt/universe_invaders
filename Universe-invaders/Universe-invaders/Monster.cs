namespace Universe_invaders
{
    public class Monster
    {
        public string Name;
        public int Health;
        public int MoneyWin;

        public Monster(string name, int health, int moneyWin)
        {
            Name = name;
            Health = health;
            MoneyWin = moneyWin;
        }
    }
}