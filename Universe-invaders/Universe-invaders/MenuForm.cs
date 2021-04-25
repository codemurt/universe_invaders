using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Universe_invaders
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
            
            TopMost = true;
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;

            ClientSize = Screen.FromControl(this).WorkingArea.Size;

            var colorBlue = ColorTranslator.FromHtml("#D3E0EA");
            var colorGreen = ColorTranslator.FromHtml("#276678");
            var colorGreenDark = ColorTranslator.FromHtml("#02475e");
            
            var menuTitle = new Label();
            menuTitle.Text = "UNIVERSE\nINVADERS";
            menuTitle.Size = new Size(900, 400);
            menuTitle.Location = new Point(ClientSize.Width / 2 - 350, ClientSize.Height / 4 - 100);
            menuTitle.Font = new Font("PlayMeGames", 135, FontStyle.Italic);
            menuTitle.ForeColor = Color.Teal;

            var buttonStart = new Button();
            buttonStart.Text = "start";
            buttonStart.Location = new Point(ClientSize.Width / 2 - 175, ClientSize.Height / 2 + 150);
            buttonStart.BackColor = colorBlue;
            buttonStart.FlatStyle = FlatStyle.Flat;
            buttonStart.FlatAppearance.BorderColor = Color.Teal;
            buttonStart.Size = new Size(350, 75);
            buttonStart.Font = new Font("PlayMeGames", 45, FontStyle.Italic);
            buttonStart.ForeColor = Color.Teal;
            buttonStart.FlatAppearance.MouseOverBackColor = buttonStart.BackColor;
            buttonStart.BackColorChanged +=
                (s, e) => buttonStart.FlatAppearance.MouseOverBackColor = buttonStart.BackColor;
            buttonStart.MouseHover += (s, e) =>
            {
                buttonStart.BackColor = colorGreenDark;
                buttonStart.ForeColor = Color.White;
            };
            buttonStart.MouseLeave += (s, e) =>
            {
                buttonStart.BackColor = colorBlue;
                buttonStart.ForeColor = Color.Teal;
            };
            buttonStart.Click += (s, e) =>
            {
                buttonStart.BackColor = colorGreen;
            };
            
            var buttonExit = new Button();
            buttonExit.Text = "exit";
            buttonExit.Location = new Point(ClientSize.Width / 2 - 175, buttonStart.Bottom + 10);
            buttonExit.Click += (s, e) => Application.Exit();
            buttonExit.BackColor = colorBlue;
            buttonExit.FlatStyle = FlatStyle.Flat;
            buttonExit.FlatAppearance.BorderColor = Color.Teal;
            buttonExit.Size = new Size(350, 75);
            buttonExit.Font = new Font("PlayMeGames", 45, FontStyle.Italic);
            buttonExit.ForeColor = Color.Teal;
            buttonExit.FlatAppearance.MouseOverBackColor = buttonExit.BackColor;
            buttonExit.BackColorChanged +=
                (s, e) => buttonExit.FlatAppearance.MouseOverBackColor = buttonExit.BackColor;
            buttonExit.MouseHover += (s, e) =>
            {
                buttonExit.BackColor = colorGreenDark;
                buttonExit.ForeColor = Color.White;
            };
            buttonExit.MouseLeave += (s, e) =>
            {
                buttonExit.BackColor = colorBlue;
                buttonExit.ForeColor = Color.Teal;
            };
            buttonExit.Click += (s, e) =>
            {
                buttonExit.BackColor = colorGreen;
            };
            
            Controls.Add(menuTitle);
            Controls.Add(buttonStart);
            Controls.Add(buttonExit);
        }
    }
}