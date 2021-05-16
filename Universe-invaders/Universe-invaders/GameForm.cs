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
                var menuForm = new MenuForm();
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
            money.Size = new Size(200, 30);
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
            autoDamage.Size = new Size(350, 30);
            autoDamage.Location = new Point(ClientSize.Width - 355, 50);
            autoDamage.Font = new Font("PlayMeGames", 25, FontStyle.Italic);
            autoDamage.ForeColor = Color.Teal;
            Controls.Add(autoDamage);
            
            var picturePurpleSoldier = new PictureBox();
            picturePurpleSoldier.Image = Image.FromFile
                (@"C:\Programming\git\universe-invaders\Universe-invaders\Universe-invaders\Images\PurpleSoldier.png");
            picturePurpleSoldier.SizeMode = PictureBoxSizeMode.StretchImage;
            picturePurpleSoldier.Location = new Point(70, 120); // y + 110
            picturePurpleSoldier.Size = new Size(90, 88);
            Controls.Add(picturePurpleSoldier);
            
            var titleFirstUpgrade = new Label();
            titleFirstUpgrade.Text = "Simple\nsoldier";
            titleFirstUpgrade.Size = new Size(110, 70);
            titleFirstUpgrade.Location = new Point(165, 130);
            titleFirstUpgrade.Font = new Font("PlayMeGames", 25, FontStyle.Italic);
            titleFirstUpgrade.ForeColor = Color.Teal;
            Controls.Add(titleFirstUpgrade);
            
            var countFirstUpgrade = new Label();
            countFirstUpgrade.Text = game.GameUpgrades[0].CountUpgrades.ToString() + "x";
            countFirstUpgrade.Size = new Size(50, 30);
            countFirstUpgrade.Location = new Point(295, 150);
            countFirstUpgrade.Font = titleFirstUpgrade.Font;
            countFirstUpgrade.ForeColor = Color.Teal;
            Controls.Add(countFirstUpgrade);
            
            var buttonFirstUpgrade = new UpgradeButton();
            buttonFirstUpgrade.button.Text = game.GameUpgrades[0].Price + "$";
            buttonFirstUpgrade.button.Location = new Point(350, 120);
            Controls.Add(buttonFirstUpgrade.button);
            
            var pictureTheRifleman = new PictureBox();
            pictureTheRifleman.Image = Image.FromFile
                (@"C:\Programming\git\universe-invaders\Universe-invaders\Universe-invaders\Images\TheRifleman.png");
            pictureTheRifleman.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureTheRifleman.Location = new Point(70, 230);
            pictureTheRifleman.Size = new Size(90, 88);
            Controls.Add(pictureTheRifleman);
            
            var titleSecondUpgrade = new Label();
            titleSecondUpgrade.Text = "The\nRifleman";
            titleSecondUpgrade.Size = new Size(130, 65);
            titleSecondUpgrade.Location = new Point(170, 250);
            titleSecondUpgrade.Font = new Font("PlayMeGames", 25, FontStyle.Italic);
            titleSecondUpgrade.ForeColor = Color.Teal;
            Controls.Add(titleSecondUpgrade);

            var countSecondUpgrade = new Label();
            countSecondUpgrade.Text = game.GameUpgrades[1].CountUpgrades + "x";
            countSecondUpgrade.Size = new Size(50, 30);
            countSecondUpgrade.Location = new Point(295, 260);
            countSecondUpgrade.Font = titleFirstUpgrade.Font;
            countSecondUpgrade.ForeColor = Color.Teal;
            Controls.Add(countSecondUpgrade);
            
            var buttonSecondUpgrade = new UpgradeButton();
            buttonSecondUpgrade.button.Text = game.GameUpgrades[1].Price + "$";
            buttonSecondUpgrade.button.Location = new Point(350, 230);
            Controls.Add(buttonSecondUpgrade.button);
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
    }
}