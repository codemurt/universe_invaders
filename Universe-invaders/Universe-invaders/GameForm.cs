using System;
using System.Windows.Forms;
using System.Drawing;
using System.Media;

namespace Universe_invaders
{
    public partial class GameForm : Form
    {
        public GameForm(Game game)
        {
            InitializeComponent();
            
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;

            ClientSize = Screen.FromControl(this).WorkingArea.Size;
            
            var sound = new SoundPlayer(@"..\..\Music\GameMusic2.wav");
            if (!game.IsGameMusicOff)
                sound.PlayLooping();

            var buttonToMenu = new GameButton("menu", ClientSize.Width - 375, ClientSize.Height - 55, 45);
            buttonToMenu.button.Click += (s, e) =>
            {
                sound.Stop();
                var menuForm = new MenuForm(game);
                menuForm.Show();
                this.Close();
            };

            var buttonHowToPlay = new GameButton("How to play", ClientSize.Width - 375 - 355, ClientSize.Height - 55, 35);
            buttonHowToPlay.button.Click += (s, e) =>
            {
                MessageBox.Show("Твоя цель пройти 50 уровней. Для этого тебе нужно прокачивать свою армию. " +
                                "Чтобы получить деньги нужно кликать по монстру, после его смерти, ты получишь монеты. Их ты можешь потратить слева, в окне улучшений." +
                                " И уже со второго улучшения, тебе будет доступен Автоурон.");
            };

            Controls.Add(buttonToMenu.button);
            Controls.Add(buttonHowToPlay.button);

            var buttonOfSound = new GameButton("sound off", 50, ClientSize.Height - 50, 35);
            if(!game.IsGameMusicOff)
                buttonOfSound.button.Text = "sound off";
            else
                buttonOfSound.button.Text = "sound on";
            buttonOfSound.button.Size = new Size(300, 75);
            buttonOfSound.button.Click += (s, e) =>
            {
                if (buttonOfSound.button.Text == "sound off")
                {
                    game.IsGameMusicOff = true;
                    sound.Stop();
                    buttonOfSound.button.Text = "sound on";
                }
                else
                {
                    game.IsGameMusicOff = false;
                    sound.PlayLooping();
                    buttonOfSound.button.Text = "sound off";
                }
            };
            
            Controls.Add(buttonOfSound.button);
            
            var money = new Label();
            money.Text = "Money: " + game.Player.Money.ToString() + " $";
            money.Size = new Size(260, 30);
            money.Location = new Point(50, 50);
            money.Font = new Font("PlayMeGames", 25, FontStyle.Italic);
            money.ForeColor = Color.Teal;
            Controls.Add(money);
            
            var damageClick = new Label();
            damageClick.Text = "Damage Per Click: " + game.Player.DamageClick.ToString() + " p.";
            damageClick.Size = new Size(420, 30);
            damageClick.Location = new Point(ClientSize.Width / 2 - 200, 50);
            damageClick.Font = new Font("PlayMeGames", 25, FontStyle.Italic);
            damageClick.ForeColor = Color.Teal;
            Controls.Add(damageClick);
            
            var increaseValueDamagePerClick = new Label();
            increaseValueDamagePerClick.Size = new Size(140, 30);
            increaseValueDamagePerClick.Location = new Point(ClientSize.Width / 2 + 30, 25);
            increaseValueDamagePerClick.Font = new Font("PlayMeGames", 20, FontStyle.Italic);
            increaseValueDamagePerClick.ForeColor = Color.Green;
            Controls.Add(increaseValueDamagePerClick);
            
            var autoDamage = new Label();
            autoDamage.Text = "Auto Damage: " + game.Player.AutoDamage.ToString() + " p/sec.";
            autoDamage.Size = new Size(450, 30);
            autoDamage.Location = new Point(ClientSize.Width - 400, 50);
            autoDamage.Font = new Font("PlayMeGames", 25, FontStyle.Italic);
            autoDamage.ForeColor = Color.Teal;
            Controls.Add(autoDamage);
            
            var increaseValueAutoDamage = new Label();
            increaseValueAutoDamage.Size = new Size(140, 30);
            increaseValueAutoDamage.Location = new Point(ClientSize.Width - 200, 25);
            increaseValueAutoDamage.Font = new Font("PlayMeGames", 20, FontStyle.Italic);
            increaseValueAutoDamage.ForeColor = Color.Green;
            Controls.Add(increaseValueAutoDamage);

            var picturePurpleSoldier = GetUpgradePicture(@"..\..\Images\PurpleSoldier.png", 70, 120);
            Controls.Add(picturePurpleSoldier);
            
            var titleFirstUpgrade = GetTitleUpgrade("Simple\nsoldier", 100, 70, 165, 130, 22);
            Controls.Add(titleFirstUpgrade);
            
            var countFirstUpgrade = GetCountUpgrade(game, 0,  150);
            Controls.Add(countFirstUpgrade);
            
            var buttonFirstUpgrade = GetButtonUpgrade(game, 0, increaseValueDamagePerClick, increaseValueAutoDamage, 120);
            buttonFirstUpgrade.button.Click += (s, e) =>
                TryUpgrade(game, money, damageClick, autoDamage, countFirstUpgrade, buttonFirstUpgrade, 0, 1.1, 1.1);
            Controls.Add(buttonFirstUpgrade.button);
            
            var pictureTheRifleman = GetUpgradePicture(@"..\..\Images\TheRifleman.png", 70, 230);
            Controls.Add(pictureTheRifleman);

            var titleSecondUpgrade = GetTitleUpgrade("The\nRifleman", 120, 65, 170, 250, 18);
            Controls.Add(titleSecondUpgrade);

            var countSecondUpgrade = GetCountUpgrade(game, 1,  260);
            Controls.Add(countSecondUpgrade);
            
            var buttonSecondUpgrade = GetButtonUpgrade(game, 1, increaseValueDamagePerClick, increaseValueAutoDamage, 230);
            buttonSecondUpgrade.button.Click += (sender, args) => 
                TryUpgrade(game, money, damageClick, autoDamage, countSecondUpgrade, buttonSecondUpgrade, 1, 1.2, 1.05);
            Controls.Add(buttonSecondUpgrade.button);
            
            var pictureRobot = GetUpgradePicture(@"..\..\Images\Robot.png", 70, 340);
            Controls.Add(pictureRobot);
            
            var titleThirdUpgrade = GetTitleUpgrade("Robot", 120, 30, 170, 375, 25);
            Controls.Add(titleThirdUpgrade);
            
            var countThirdUpgrade = GetCountUpgrade(game, 2, 380);
            Controls.Add(countThirdUpgrade);
            
            var buttonThirdUpgrade = GetButtonUpgrade(game, 2, increaseValueDamagePerClick, increaseValueAutoDamage, 340);
            buttonThirdUpgrade.button.Click += (s, e) =>
                TryUpgrade(game, money, damageClick, autoDamage, countThirdUpgrade, buttonThirdUpgrade, 2, 1.3, 1.02);
            Controls.Add(buttonThirdUpgrade.button);
            
            var pictureSpaceshipCrew = GetUpgradePicture(@"..\..\Images\SpaceshipCrew.png", 70, 450);
            Controls.Add(pictureSpaceshipCrew);
            
            var titleFourthUpgrade = GetTitleUpgrade("Spaceship\ncrew", 120, 55, 170, 475, 18);
            Controls.Add(titleFourthUpgrade);
            
            var countFourthUpgrade = GetCountUpgrade(game, 3, 485);
            Controls.Add(countFourthUpgrade);
            
            var buttonFourthUpgrade = GetButtonUpgrade(game, 3, increaseValueDamagePerClick, increaseValueAutoDamage, 450);
            buttonFourthUpgrade.button.Click += (s, e) =>
                TryUpgrade(game, money, damageClick, autoDamage, countFourthUpgrade, buttonFourthUpgrade, 3, 1.4, 1.02);
            Controls.Add(buttonFourthUpgrade.button);
            
            var pictureSpaceExplorers = GetUpgradePicture(@"..\..\Images\SpaceExplorers.png", 70, 560);
            Controls.Add(pictureSpaceExplorers);
            
            var titleFifthUpgrade = GetTitleUpgrade("Space\nexplorers", 120, 55, 170, 580, 20);
            Controls.Add(titleFifthUpgrade);
            
            var countFifthUpgrade = GetCountUpgrade(game, 4,  590);
            Controls.Add(countFifthUpgrade);
            
            var buttonFifthUpgrade = GetButtonUpgrade(game, 4, increaseValueDamagePerClick, increaseValueAutoDamage, 560);
            buttonFifthUpgrade.button.Click += (s, e) =>
                TryUpgrade(game, money, damageClick, autoDamage, countFifthUpgrade, buttonFifthUpgrade, 4, 1.6, 1.02);
            Controls.Add(buttonFifthUpgrade.button);
            
            var titleCurrentLevel = new Label();
            titleCurrentLevel.Text = "Level: " + game.CurrentLevel + "/50";
            titleCurrentLevel.Size = new Size(320, 55);
            titleCurrentLevel.Location = new Point(ClientSize.Width - 550, 100);
            titleCurrentLevel.Font = new Font("PlayMeGames", 40, FontStyle.Italic);
            titleCurrentLevel.ForeColor = Color.Teal;
            Controls.Add(titleCurrentLevel);
            
            var pictureMonster = new PictureBox();
            pictureMonster.Image = Image.FromFile
                ("..\\..\\Images\\" + game.CurrentMonster.Name + ".gif");
            pictureMonster.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureMonster.Location = new Point(ClientSize.Width - 550, titleCurrentLevel.Bottom);
            pictureMonster.Size = new Size(270, 350);
            Controls.Add(pictureMonster);
            
            var progressBarMonsterHealth = new ProgressBar();
            progressBarMonsterHealth.Size = new Size(400, 40);
            progressBarMonsterHealth.Location = new Point(ClientSize.Width - 620, pictureMonster.Bottom + 20);
            progressBarMonsterHealth.Minimum = 0;
            progressBarMonsterHealth.Maximum = game.HealthMin;
            progressBarMonsterHealth.Value = game.CurrentMonster.Health;
            Controls.Add(progressBarMonsterHealth);

            pictureMonster.Click += (s, e) =>
                BitCurrentMonster(game, money, titleCurrentLevel, pictureMonster, progressBarMonsterHealth);

            var timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += (s, e) =>
            {
                BitCurrentMonster(game, money, titleCurrentLevel, pictureMonster, progressBarMonsterHealth);
                
                if (game.CurrentLevel >= 50)
                {
                    timer.Stop();
                    MessageBox.Show("Поздравляем, вы победили! Вашей армии удалось победить всех монстров!");
                    sound.Stop();
                    var newGame = new Game();
                    newGame.IsMenuMusicOff = game.IsMenuMusicOff;
                    newGame.IsGameMusicOff = game.IsGameMusicOff;
                    var menuForm = new MenuForm(newGame);
                    menuForm.Show();
                    this.Close();
                }
            };
            timer.Start();
        }

        private static UpgradeButton GetButtonUpgrade(Game game, int index, Label increaseValueDamagePerClick, Label increaseValueAutoDamage, int y)
        {
            var buttonUpgrade = new UpgradeButton(game.GameUpgrades[index], increaseValueDamagePerClick, increaseValueAutoDamage);
            buttonUpgrade.button.Text = game.GameUpgrades[index].Price + "$";
            buttonUpgrade.button.Location = new Point(350, y);

            return buttonUpgrade;
        }

        private static Label GetCountUpgrade(Game game, int index, int y)
        {
            var countUpgrade = new Label();
            countUpgrade.Text = game.GameUpgrades[index].CountUpgrades + "x";
            countUpgrade.Size = new Size(65, 30);
            countUpgrade.Location = new Point(285, y);
            countUpgrade.Font = new Font("PlayMeGames", 22, FontStyle.Italic);
            countUpgrade.ForeColor = Color.Teal;

            return countUpgrade;
        }

        private static Label GetTitleUpgrade(string text, int width, int height, int x, int y, int emSize)
        {
            var titleUpgrade = new Label(); 
            titleUpgrade.Text = text;
            titleUpgrade.Size = new Size(width, height);
            titleUpgrade.Location = new Point(x, y);
            titleUpgrade.Font = new Font("PlayMeGames", emSize, FontStyle.Italic);
            titleUpgrade.ForeColor = Color.Teal;

            return titleUpgrade;
        }

        private static PictureBox GetUpgradePicture(string path, int x, int y)
        {
            var pictureUpgrade = new PictureBox();
            pictureUpgrade.Image = Image.FromFile(path);
            pictureUpgrade.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureUpgrade.Location = new Point(x, y); 
            pictureUpgrade.Size = new Size(90, 88);

            return pictureUpgrade;
        }

        private void BitCurrentMonster(Game game, Label money, Label titleCurrentLevel, PictureBox pictureMonster,
            ProgressBar progressBarMonsterHealth)
        {
            if (game.CurrentMonster.Health - game.Player.DamageClick > 0)
                game.CurrentMonster.Health -= game.Player.DamageClick;
            else
            {
                game.Player.Money += game.CurrentMonster.MoneyWin;
                money.Text = "Money: " + game.Player.Money + " $";
                game.CurrentLevel++;
                titleCurrentLevel.Text = "Level: " + game.CurrentLevel + "/50";
                game.HealthMin = Convert.ToInt32(game.HealthMin * 1.45);
                game.MoneyWinMin = Convert.ToInt32(game.MoneyWinMin * 1.3);

                game.CurrentMonster = new Monster(Game.GetNextMonsterName(), game.HealthMin, game.MoneyWinMin);
                ChangePictureMonster(game, pictureMonster);
                progressBarMonsterHealth.Maximum = game.CurrentMonster.Health;
            }

            if (game.CurrentMonster.Health <= progressBarMonsterHealth.Maximum &&
                game.CurrentMonster.Health >= progressBarMonsterHealth.Minimum)
                progressBarMonsterHealth.Value = game.CurrentMonster.Health;
        }

        private void TryUpgrade(Game game, Label money, Label damageClick, Label autoDamage, Label countSecondUpgrade,
            UpgradeButton buttonSecondUpgrade, int index, double priceCoefficient, double damageCoefficient)
        {
            if (game.Player.Money >= game.GameUpgrades[index].Price)
            {
                game.Player.Money -= game.GameUpgrades[index].Price;
                ChangeMoneyStatus(money, game);
                game.Player.DamageClick += game.GameUpgrades[index].IncreaseClickDamage;
                ChangeDamageClick(damageClick, game);
                game.Player.AutoDamage += game.GameUpgrades[index].IncreaseAutoDamage;
                ChangeAutoDamage(autoDamage, game);
                game.GameUpgrades[index].CountUpgrades++;
                ChangeCountUpgrades(countSecondUpgrade, game, index);
                game.GameUpgrades[index].Price += Convert.ToInt32(game.GameUpgrades[index].MainPrice * priceCoefficient);
                ChangeUpgradePrice(buttonSecondUpgrade, game, index);
                game.GameUpgrades[index].IncreaseClickDamage +=
                    Convert.ToInt32(game.GameUpgrades[index].IncreaseClickDamage * damageCoefficient);
                if (index > 0)
                    game.GameUpgrades[index].IncreaseAutoDamage +=
                        Convert.ToInt32(game.GameUpgrades[index].IncreaseAutoDamage * damageCoefficient);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var graphics = e.Graphics;
            graphics.DrawRectangle(new Pen(Color.Teal, 10), 50, 100, 535, 565);
            graphics.DrawRectangle(new Pen(Color.Teal, 6), 60, 112, 515, 100);
            graphics.DrawRectangle(new Pen(Color.Teal, 6), 60, 222, 515, 100);
            graphics.DrawRectangle(new Pen(Color.Teal, 6), 60, 332, 515, 100);
            graphics.DrawRectangle(new Pen(Color.Teal, 6), 60, 442, 515, 100);
            graphics.DrawRectangle(new Pen(Color.Teal, 6), 60, 552, 515, 100);
        }

        private void ChangeMoneyStatus(Label money, Game game)
        {
            money.Text = "Money: " + game.Player.Money + " $";
        }

        private void ChangeDamageClick(Label damageClick, Game game)
        {
            damageClick.Text = "Damage Per Click: " + game.Player.DamageClick + " p.";
        }

        private void ChangeCountUpgrades(Label countUpgrade, Game game, int index)
        {
            countUpgrade.Text = game.GameUpgrades[index].CountUpgrades + "x";
        }

        private void ChangeUpgradePrice(UpgradeButton button, Game game, int index)
        {
            button.button.Text = game.GameUpgrades[index].Price + "$";
        }

        private void ChangeAutoDamage(Label autoDamage, Game game)
        {
            autoDamage.Text = "Auto Damage: " + game.Player.AutoDamage + " p/sec.";
        }

        private void ChangePictureMonster(Game game, PictureBox pictureMonster)
        {
            
            pictureMonster.Image = Image.FromFile
                ("..\\..\\Images\\" + game.CurrentMonster.Name + ".gif");
        }
    }
}