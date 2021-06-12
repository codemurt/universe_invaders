using System;
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
            game.clientSize = ClientSize;
            
            var sound = new SoundPlayer(@"..\..\Music\MenuMusic.wav");
            if (!game.IsMenuMusicOff)
                sound.PlayLooping();

            var menuTitle = new Label();
            menuTitle.Text = "UNIVERSE\nINVADERS";
            menuTitle.Size = new Size(900, 400);
            menuTitle.Location = new Point(ClientSize.Width / 2 - 350, ClientSize.Height / 4 - 100);
            menuTitle.Font = new Font("PlayMeGames", 135, FontStyle.Italic);
            menuTitle.ForeColor = Color.Teal;

            var buttonStart = new GameButton("start", ClientSize.Width / 2 - 175, ClientSize.Height / 2 + 150, 45);
            buttonStart.button.Click += (s, e) =>
            {
                sound.Stop();
                var gameForm = new GameForm(game);
                gameForm.Show();
                this.Hide();
            };

            var buttonExit = new GameButton("exit", ClientSize.Width / 2 - 175, buttonStart.button.Bottom + 10, 45);
            buttonExit.button.Click += (s, e) =>
            {
                sound.Stop();
                Application.Exit();
            };

            var buttonOfSound = new GameButton("sound off", ClientSize.Width - 320, ClientSize.Height - 55, 35);
            if(!game.IsMenuMusicOff)
                buttonOfSound.button.Text = "sound off";
            else
                buttonOfSound.button.Text = "sound on";
            buttonOfSound.button.Size = new Size(300, 75);

            buttonOfSound.button.Click += (s, e) =>
            {
                if (buttonOfSound.button.Text == "sound off")
                {
                    game.IsMenuMusicOff = true;
                    sound.Stop();
                    buttonOfSound.button.Text = "sound on";
                }
                else
                {
                    game.IsMenuMusicOff = false;
                    sound.PlayLooping();
                    buttonOfSound.button.Text = "sound off";
                }
            };

            Controls.Add(menuTitle);
            Controls.Add(buttonStart.button);
            Controls.Add(buttonExit.button);
            Controls.Add(buttonOfSound.button);
        }
    }
}