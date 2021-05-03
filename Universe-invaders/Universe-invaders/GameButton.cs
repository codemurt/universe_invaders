using System.Windows.Forms;
using System.Drawing;

namespace Universe_invaders
{
    public class GameButton
    {
        public Button button = new Button();
        public GameButton()
        {
            var colorBlue = ColorTranslator.FromHtml("#D3E0EA");
            var colorGreen = ColorTranslator.FromHtml("#276678");
            var colorGreenDark = ColorTranslator.FromHtml("#02475e");
            
            button.BackColor = colorBlue;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderColor = Color.Teal;
            button.Size = new Size(350, 75);
            button.ForeColor = Color.Teal;
            button.FlatAppearance.MouseOverBackColor = button.BackColor;
            button.BackColorChanged +=
                (s, e) => button.FlatAppearance.MouseOverBackColor = button.BackColor;
            button.MouseHover += (s, e) =>
            {
                button.BackColor = colorGreenDark;
                button.ForeColor = Color.White;
            };
            button.MouseLeave += (s, e) =>
            {
                button.BackColor = colorBlue;
                button.ForeColor = Color.Teal;
            };
            button.Click += (s, e) =>
            {
                button.BackColor = colorGreen;
            };
            button.TabStop = false;
        }
    }
}