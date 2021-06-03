using System.Drawing;
using System.Windows.Forms;
using System;

namespace Universe_invaders
{
    public class UpgradeButton
    {
        public Button button = new Button();

        public UpgradeButton(GameUpgrade gameUpgrade, Label increaseValueDamagePerClick, Label increaseValueAutoDamage)
        {
            var colorBlue = ColorTranslator.FromHtml("#D3E0EA");
            var colorGreen = ColorTranslator.FromHtml("#276678");
            var colorGreenDark = ColorTranslator.FromHtml("#02475e");
            
            button.BackColor = colorBlue;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderColor = Color.Teal;
            button.Size = new Size(215, 85);
            button.ForeColor = Color.Teal;
            button.FlatAppearance.MouseOverBackColor = button.BackColor;
            button.BackColorChanged +=
                (s, e) => button.FlatAppearance.MouseOverBackColor = button.BackColor;
            button.MouseHover += (s, e) =>
            {
                button.BackColor = Color.LimeGreen;
                button.ForeColor = Color.White;
                
                increaseValueDamagePerClick.Text = "+ " + gameUpgrade.IncreaseClickDamage;
                increaseValueAutoDamage.Text = "+ " + gameUpgrade.IncreaseAutoDamage;
            };
            button.MouseLeave += (s, e) =>
            {
                button.BackColor = colorBlue;
                button.ForeColor = Color.Teal;
                increaseValueDamagePerClick.Text = "";
                increaseValueAutoDamage.Text = "";
            };
            button.Click += (s, e) =>
            {
                button.BackColor = Color.DarkGreen;
            };
            button.TabStop = false;
            button.Font = new Font("PlayMeGames", 35, FontStyle.Italic);
            
            button.MouseHover += (s, e) => Cursor.Current = Cursors.Hand;
        }
        
    }
}