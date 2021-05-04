using System.Windows.Forms;
using System.Drawing;

namespace Universe_invaders
{
    public partial class GameForm : Form
    {
        public GameForm(Player player)
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
            money.Text = "Money: " + player.Money.ToString() + " $";
            money.Size = new Size(200, 30);
            money.Location = new Point(50, 50);
            money.Font = new Font("PlayMeGames", 25, FontStyle.Italic);
            money.ForeColor = Color.Teal;
            Controls.Add(money);
            
            var damageClick = new Label();
            damageClick.Text = "Damage Per Click: " + player.DamageClick.ToString() + " p.";
            damageClick.Size = new Size(350, 30);
            damageClick.Location = new Point(ClientSize.Width / 2 - 200, 50);
            damageClick.Font = new Font("PlayMeGames", 25, FontStyle.Italic);
            damageClick.ForeColor = Color.Teal;
            Controls.Add(damageClick);
            
            var autoDamage = new Label();
            autoDamage.Text = "Auto Damage: " + player.AutoDamage.ToString() + " p/sec.";
            autoDamage.Size = new Size(350, 30);
            autoDamage.Location = new Point(ClientSize.Width - 355, 50);
            autoDamage.Font = new Font("PlayMeGames", 25, FontStyle.Italic);
            autoDamage.ForeColor = Color.Teal;
            Controls.Add(autoDamage);
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