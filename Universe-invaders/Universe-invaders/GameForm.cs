using System;
using System.Windows.Forms;
using System.Drawing;

namespace Universe_invaders
{
    public partial class GameForm : Form
    {
        public GameForm(Game game)
        {
            InitializeComponent();
            TopMost = true;
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;

            ClientSize = Screen.FromControl(this).WorkingArea.Size;

            var buttonToMenu = new GameButton();
            buttonToMenu.button.Text = "menu";
            buttonToMenu.button.Location = new Point(ClientSize.Width - 375, ClientSize.Height - 55);
            buttonToMenu.button.Click += (s, e) =>
            {
                var menuForm = new MenuForm(game);
                menuForm.Show();
                this.Close();
            };
            buttonToMenu.button.Font = new Font("PlayMeGames", 45, FontStyle.Italic);

            var buttonToAchievements = new GameButton();
            buttonToAchievements.button.Text = "achievements";
            buttonToAchievements.button.Location = new Point(ClientSize.Width - 375 - 355, ClientSize.Height - 55);
            buttonToAchievements.button.Font = new Font("PlayMeGames", 35, FontStyle.Italic);

            Controls.Add(buttonToMenu.button);
            Controls.Add(buttonToAchievements.button);
            
            var money = new Label();
            money.Text = "Money: " + game.Player.Money.ToString() + " $";
            money.Size = new Size(240, 30);
            money.Location = new Point(50, 50);
            money.Font = new Font("PlayMeGames", 25, FontStyle.Italic);
            money.ForeColor = Color.Teal;
            Controls.Add(money);
            
            var damageClick = new Label();
            damageClick.Text = "Damage Per Click: " + game.Player.DamageClick.ToString() + " p.";
            damageClick.Size = new Size(350, 30);
            damageClick.Location = new Point(ClientSize.Width / 2 - 200, 50);
            damageClick.Font = new Font("PlayMeGames", 25, FontStyle.Italic);
            damageClick.ForeColor = Color.Teal;
            Controls.Add(damageClick);
            
            var autoDamage = new Label();
            autoDamage.Text = "Auto Damage: " + game.Player.AutoDamage.ToString() + " p/sec.";
            autoDamage.Size = new Size(400, 30);
            autoDamage.Location = new Point(ClientSize.Width - 400, 50);
            autoDamage.Font = new Font("PlayMeGames", 25, FontStyle.Italic);
            autoDamage.ForeColor = Color.Teal;
            Controls.Add(autoDamage);

            var picturePurpleSoldier = new PictureBox();
            picturePurpleSoldier.Image = Image.FromFile
                (@"..\..\Images\PurpleSoldier.png");
            picturePurpleSoldier.SizeMode = PictureBoxSizeMode.StretchImage;
            picturePurpleSoldier.Location = new Point(70, 120); 
            picturePurpleSoldier.Size = new Size(90, 88);
            Controls.Add(picturePurpleSoldier);
            
            var titleFirstUpgrade = new Label();
            titleFirstUpgrade.Text = "Simple\nsoldier";
            titleFirstUpgrade.Size = new Size(100, 70);
            titleFirstUpgrade.Location = new Point(165, 130);
            titleFirstUpgrade.Font = new Font("PlayMeGames", 22, FontStyle.Italic);
            titleFirstUpgrade.ForeColor = Color.Teal;
            Controls.Add(titleFirstUpgrade);
            
            var countFirstUpgrade = new Label();
            countFirstUpgrade.Text = game.GameUpgrades[0].CountUpgrades.ToString() + "x";
            countFirstUpgrade.Size = new Size(65, 30);
            countFirstUpgrade.Location = new Point(285, 150);
            countFirstUpgrade.Font = titleFirstUpgrade.Font;
            countFirstUpgrade.ForeColor = Color.Teal;
            Controls.Add(countFirstUpgrade);
            
            var buttonFirstUpgrade = new UpgradeButton();
            buttonFirstUpgrade.button.Text = game.GameUpgrades[0].Price + "$";
            buttonFirstUpgrade.button.Location = new Point(350, 120);
            buttonFirstUpgrade.button.Click += (s, e) =>
            {
                if (game.Player.Money >= game.GameUpgrades[0].Price)
                {
                    game.Player.Money -= game.GameUpgrades[0].Price;
                    ChangeMoneyStatus(money, game);
                    game.Player.DamageClick += game.GameUpgrades[0].IncreaseClickDamage;
                    ChangeDamageClick(damageClick, game);
                    game.GameUpgrades[0].CountUpgrades++;
                    ChangeCountUpgrades(countFirstUpgrade, game, 0);
                    game.GameUpgrades[0].Price += Convert.ToInt32(game.GameUpgrades[0].MainPrice * 1.1);
                    ChangeUpgradePrice(buttonFirstUpgrade, game, 0);
                }
            };
            
            Controls.Add(buttonFirstUpgrade.button);
            
            var pictureTheRifleman = new PictureBox();
            pictureTheRifleman.Image = Image.FromFile
                (@"..\..\Images\TheRifleman.png");
            pictureTheRifleman.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureTheRifleman.Location = new Point(70, 230);
            pictureTheRifleman.Size = new Size(90, 88);
            Controls.Add(pictureTheRifleman);
            
            var titleSecondUpgrade = new Label();
            titleSecondUpgrade.Text = "The\nRifleman";
            titleSecondUpgrade.Size = new Size(120, 65);
            titleSecondUpgrade.Location = new Point(170, 250);
            titleSecondUpgrade.Font = new Font("PlayMeGames", 18, FontStyle.Italic);
            titleSecondUpgrade.ForeColor = Color.Teal;
            Controls.Add(titleSecondUpgrade);

            var countSecondUpgrade = new Label();
            countSecondUpgrade.Text = game.GameUpgrades[1].CountUpgrades + "x";
            countSecondUpgrade.Size = new Size(65, 30);
            countSecondUpgrade.Location = new Point(285, 260);
            countSecondUpgrade.Font = titleFirstUpgrade.Font;
            countSecondUpgrade.ForeColor = Color.Teal;
            Controls.Add(countSecondUpgrade);
            
            var buttonSecondUpgrade = new UpgradeButton();
            buttonSecondUpgrade.button.Text = game.GameUpgrades[1].Price + "$";
            buttonSecondUpgrade.button.Location = new Point(350, 230);
            buttonSecondUpgrade.button.Click += (s, e) =>
            {
                if (game.Player.Money >= game.GameUpgrades[1].Price)
                {
                    game.Player.Money -= game.GameUpgrades[1].Price;
                    ChangeMoneyStatus(money, game);
                    game.Player.DamageClick += game.GameUpgrades[1].IncreaseClickDamage;
                    ChangeDamageClick(damageClick, game);
                    game.Player.AutoDamage += game.GameUpgrades[1].IncreaseAutoDamage;
                    ChangeAutoDamage(autoDamage, game);
                    game.GameUpgrades[1].CountUpgrades++;
                    ChangeCountUpgrades(countSecondUpgrade, game, 1);
                    game.GameUpgrades[1].Price += Convert.ToInt32(game.GameUpgrades[1].MainPrice * 1.2);
                    ChangeUpgradePrice(buttonSecondUpgrade, game, 1);
                }
            };
            Controls.Add(buttonSecondUpgrade.button);
            
            var pictureRobot = new PictureBox();
            pictureRobot.Image = Image.FromFile
                (@"..\..\Images\Robot.png");
            pictureRobot.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureRobot.Location = new Point(70, 340);
            pictureRobot.Size = new Size(90, 88);
            Controls.Add(pictureRobot);
            
            var titleThirdUpgrade = new Label();
            titleThirdUpgrade.Text = "Robot";
            titleThirdUpgrade.Size = new Size(120, 30);
            titleThirdUpgrade.Location = new Point(170, 375);
            titleThirdUpgrade.Font = new Font("PlayMeGames", 25, FontStyle.Italic);
            titleThirdUpgrade.ForeColor = Color.Teal;
            Controls.Add(titleThirdUpgrade);
            
            var countThirdUpgrade = new Label();
            countThirdUpgrade.Text = game.GameUpgrades[2].CountUpgrades + "x";
            countThirdUpgrade.Size = new Size(65, 30);
            countThirdUpgrade.Location = new Point(285, 380);
            countThirdUpgrade.Font = titleFirstUpgrade.Font;
            countThirdUpgrade.ForeColor = Color.Teal;
            Controls.Add(countThirdUpgrade);
            
            var buttonThirdUpgrade = new UpgradeButton();
            buttonThirdUpgrade.button.Text = game.GameUpgrades[2].Price + "$";
            buttonThirdUpgrade.button.Location = new Point(350, 340);
            buttonThirdUpgrade.button.Click += (s, e) =>
            {
                if (game.Player.Money >= game.GameUpgrades[2].Price)
                {
                    game.Player.Money -= game.GameUpgrades[2].Price;
                    ChangeMoneyStatus(money, game);
                    game.Player.DamageClick += game.GameUpgrades[2].IncreaseClickDamage;
                    ChangeDamageClick(damageClick, game);
                    game.Player.AutoDamage += game.GameUpgrades[2].IncreaseAutoDamage;
                    ChangeAutoDamage(autoDamage, game);
                    game.GameUpgrades[2].CountUpgrades++;
                    ChangeCountUpgrades(countThirdUpgrade, game, 2);
                    game.GameUpgrades[2].Price += Convert.ToInt32(game.GameUpgrades[2].MainPrice * 1.3);
                    ChangeUpgradePrice(buttonThirdUpgrade, game, 2);
                }
            };
            Controls.Add(buttonThirdUpgrade.button);
            
            var pictureSpaceshipCrew = new PictureBox();
            pictureSpaceshipCrew.Image = Image.FromFile
                (@"..\..\Images\SpaceshipCrew.png");
            pictureSpaceshipCrew.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureSpaceshipCrew.Location = new Point(70, 450);
            pictureSpaceshipCrew.Size = new Size(90, 88);
            Controls.Add(pictureSpaceshipCrew);
            
            var titleFourthUpgrade = new Label();
            titleFourthUpgrade.Text = "Spaceship\ncrew";
            titleFourthUpgrade.Size = new Size(120, 55);
            titleFourthUpgrade.Location = new Point(170, 475);
            titleFourthUpgrade.Font = new Font("PlayMeGames", 18, FontStyle.Italic);
            titleFourthUpgrade.ForeColor = Color.Teal;
            Controls.Add(titleFourthUpgrade);
            
            var countFourthUpgrade = new Label();
            countFourthUpgrade.Text = game.GameUpgrades[3].CountUpgrades + "x";
            countFourthUpgrade.Size = new Size(65, 30);
            countFourthUpgrade.Location = new Point(285, 485);
            countFourthUpgrade.Font = titleFirstUpgrade.Font;
            countFourthUpgrade.ForeColor = Color.Teal;
            Controls.Add(countFourthUpgrade);
            
            var buttonFourthUpgrade = new UpgradeButton();
            buttonFourthUpgrade.button.Text = game.GameUpgrades[3].Price + "$";
            buttonFourthUpgrade.button.Location = new Point(350, 450);
            buttonFourthUpgrade.button.Click += (s, e) =>
            {
                if (game.Player.Money >= game.GameUpgrades[3].Price)
                {
                    game.Player.Money -= game.GameUpgrades[3].Price;
                    ChangeMoneyStatus(money, game);
                    game.Player.DamageClick += game.GameUpgrades[3].IncreaseClickDamage;
                    ChangeDamageClick(damageClick, game);
                    game.Player.AutoDamage += game.GameUpgrades[3].IncreaseAutoDamage;
                    ChangeAutoDamage(autoDamage, game);
                    game.GameUpgrades[3].CountUpgrades++;
                    ChangeCountUpgrades(countFourthUpgrade, game, 3);
                    game.GameUpgrades[3].Price += Convert.ToInt32(game.GameUpgrades[3].MainPrice * 1.4);
                    ChangeUpgradePrice(buttonFourthUpgrade, game, 3);
                }
            };
            Controls.Add(buttonFourthUpgrade.button);
            
            var pictureSpaceExplorers = new PictureBox();
            pictureSpaceExplorers.Image = Image.FromFile
                (@"..\..\Images\SpaceExplorers.png");
            pictureSpaceExplorers.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureSpaceExplorers.Location = new Point(70, 560);
            pictureSpaceExplorers.Size = new Size(90, 88);
            Controls.Add(pictureSpaceExplorers);
            
            var titleFifthUpgrade = new Label();
            titleFifthUpgrade.Text = "Space\nexplorers";
            titleFifthUpgrade.Size = new Size(120, 55);
            titleFifthUpgrade.Location = new Point(170, 580);
            titleFifthUpgrade.Font = new Font("PlayMeGames", 20, FontStyle.Italic);
            titleFifthUpgrade.ForeColor = Color.Teal;
            Controls.Add(titleFifthUpgrade);
            
            var countFifthUpgrade = new Label();
            countFifthUpgrade.Text = game.GameUpgrades[4].CountUpgrades + "x";
            countFifthUpgrade.Size = new Size(65, 30);
            countFifthUpgrade.Location = new Point(285, 590);
            countFifthUpgrade.Font = titleFirstUpgrade.Font;
            countFifthUpgrade.ForeColor = Color.Teal;
            Controls.Add(countFifthUpgrade);
            
            var buttonFifthUpgrade = new UpgradeButton();
            buttonFifthUpgrade.button.Text = game.GameUpgrades[4].Price + "$";
            buttonFifthUpgrade.button.Location = new Point(350, 560);
            buttonFifthUpgrade.button.Click += (s, e) =>
            {
                if (game.Player.Money >= game.GameUpgrades[4].Price)
                {
                    game.Player.Money -= game.GameUpgrades[4].Price;
                    ChangeMoneyStatus(money, game);
                    game.Player.DamageClick += game.GameUpgrades[4].IncreaseClickDamage;
                    ChangeDamageClick(damageClick, game);
                    game.Player.AutoDamage += game.GameUpgrades[4].IncreaseAutoDamage;
                    ChangeAutoDamage(autoDamage, game);
                    game.GameUpgrades[4].CountUpgrades++;
                    ChangeCountUpgrades(countFifthUpgrade, game, 4);
                    game.GameUpgrades[4].Price += Convert.ToInt32(game.GameUpgrades[4].MainPrice * 1.5);
                    ChangeUpgradePrice(buttonFifthUpgrade, game, 4);
                }
            };
            Controls.Add(buttonFifthUpgrade.button);
            
            var titleCurrentLevel = new Label();
            titleCurrentLevel.Text = "Level: " + game.CurrentLevel;
            titleCurrentLevel.Size = new Size(230, 55);
            titleCurrentLevel.Location = new Point(ClientSize.Width - 500, 100);
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
            {
                if (game.CurrentMonster.Health - game.Player.DamageClick > 0)
                    game.CurrentMonster.Health -= game.Player.DamageClick;
                else
                {
                    game.Player.Money += game.CurrentMonster.MoneyWin;
                    money.Text = "Money: " + game.Player.Money + " $";
                    game.CurrentLevel++;
                    titleCurrentLevel.Text = "Level: " + game.CurrentLevel;
                    game.HealthMin = Convert.ToInt32(game.HealthMin * 1.4);
                    game.MoneyWinMin = Convert.ToInt32(game.MoneyWinMin * 1.3);
                    game.CurrentMonster = new Monster("OrangeMonster", game.HealthMin, game.MoneyWinMin);
                    progressBarMonsterHealth.Maximum = game.CurrentMonster.Health;
                }
                
                progressBarMonsterHealth.Value = game.CurrentMonster.Health;
            };
            
            var timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += (s, e) =>
            {
                if (game.CurrentMonster.Health - game.Player.AutoDamage > 0)
                    game.CurrentMonster.Health -= game.Player.AutoDamage;
                else
                {
                    game.Player.Money += game.CurrentMonster.MoneyWin;
                    money.Text = "Money: " + game.Player.Money + " $";
                    game.CurrentLevel++;
                    titleCurrentLevel.Text = "Level: " + game.CurrentLevel;
                    game.HealthMin = Convert.ToInt32(game.HealthMin * 1.4);
                    game.MoneyWinMin = Convert.ToInt32(game.MoneyWinMin * 1.3);
                    game.CurrentMonster = new Monster("OrangeMonster", game.HealthMin, game.MoneyWinMin);
                    progressBarMonsterHealth.Maximum = game.CurrentMonster.Health;
                }
                
                progressBarMonsterHealth.Value = game.CurrentMonster.Health;
            };
            timer.Start();
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
    }
}