﻿using System.Windows.Forms;
using System.Drawing;

namespace Universe_invaders
{
    public partial class GameForm : Form
    {
        public GameForm()
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
            
            var currentPlayer = new Player();
            var money = new Label();
            money.Text = "Money: " + currentPlayer.Money.ToString() + " $";
            money.Size = new Size(200, 100);
            money.Location = new Point(50, 50);
            money.Font = new Font("PlayMeGames", 25, FontStyle.Italic);
            money.ForeColor = Color.Teal;
            Controls.Add(money);
            
        }
    }
}