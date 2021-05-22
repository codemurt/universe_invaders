namespace Universe_invaders
{
    public class GameUpgrade
    {
        public int Price;
        public int CountUpgrades;
        public int IncreaseClickDamage;
        public int IncreaseAutoDamage;
        public string Name;
        public int MainPrice;

        public GameUpgrade(string name, int price, int increaseClickDamage, int increaseAutoDamage)
        {
            Name = name;
            Price = price;
            IncreaseClickDamage = increaseClickDamage;
            IncreaseAutoDamage = increaseAutoDamage;
            CountUpgrades = 0;
            MainPrice = price;
        }
    }
}