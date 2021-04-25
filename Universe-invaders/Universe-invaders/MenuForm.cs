﻿using System;
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
            
            var menuTitle = new Label();
            menuTitle.Text = "UNIVERSE\nINVADERS";
            menuTitle.Size = new Size(300, 100);
            menuTitle.Location = new Point(ClientSize.Width / 2 - 50, ClientSize.Height / 4);
            menuTitle.Font = new Font("PlayMeGames", 35);
            menuTitle.ForeColor = Color.Teal;
            
            var buttonStart = new Button();
            buttonStart.Text = "START";
            buttonStart.Location = new Point(ClientSize.Width / 2, ClientSize.Height / 2);
            
            var buttonExit = new Button();
            buttonExit.Text = "EXIT";
            buttonExit.Location = new Point(ClientSize.Width / 2, buttonStart.Bottom);
            buttonExit.Click += (sender, args) => Application.Exit();
            
            Controls.Add(menuTitle);
            Controls.Add(buttonStart);
            Controls.Add(buttonExit);
        }
    }
}