﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Universe_invaders
{
    public partial class MenuForm : Form
    {
        public MenuForm(Game game)
        {
            InitializeComponent();
            
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;

            ClientSize = Screen.FromControl(this).WorkingArea.Size;
            
            var sound = new SoundPlayer(@"..\..\Music\MenuMusic.wav");
            sound.PlayLooping();

            var menuTitle = new Label();
            menuTitle.Text = "UNIVERSE\nINVADERS";
            menuTitle.Size = new Size(900, 400);
            menuTitle.Location = new Point(ClientSize.Width / 2 - 350, ClientSize.Height / 4 - 100);
            menuTitle.Font = new Font("PlayMeGames", 135, FontStyle.Italic);
            menuTitle.ForeColor = Color.Teal;

            var buttonStart = new GameButton();
            buttonStart.button.Text = "start";
            buttonStart.button.Location = new Point(ClientSize.Width / 2 - 175, ClientSize.Height / 2 + 150);
            buttonStart.button.Font = new Font("PlayMeGames", 45, FontStyle.Italic);
            buttonStart.button.Click += (s, e) =>
            {
                sound.Stop();
                var gameForm = new GameForm(game);
                gameForm.Show();
                this.Hide();
            };

            var buttonExit = new GameButton();
            buttonExit.button.Text = "exit";
            buttonExit.button.Location = new Point(ClientSize.Width / 2 - 175, buttonStart.button.Bottom + 10);
            buttonExit.button.Click += (s, e) =>
            {
                sound.Stop();
                Application.Exit();
            };
            buttonExit.button.Font = new Font("PlayMeGames", 45, FontStyle.Italic);

            Controls.Add(menuTitle);
            Controls.Add(buttonStart.button);
            Controls.Add(buttonExit.button);
        }
    }
}