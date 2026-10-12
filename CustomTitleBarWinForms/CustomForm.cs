using System;
using System.Drawing;
using System.Windows.Forms;

namespace CustomTitleBarWinForms
{
    public class CustomForm : Form
    {
        protected CustomTitleBar _customTitleBar;

        public CustomForm()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.FromArgb(245, 247, 250);
            this.Font = new Font("Segoe UI", 10);
            this.Size = new Size(1000, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.DoubleBuffered = true;

            InitializeCustomTitleBar();
        }

        private void InitializeCustomTitleBar()
        {
            _customTitleBar = new CustomTitleBar(this)
            {
                TitleBarHeight = 45,
                TitleBarBackColor = Color.FromArgb(33, 37, 41),
                TitleFontColor = Color.White,
                TitleFont = new Font("Segoe UI", 12, FontStyle.Bold)
            };
        }

        public CustomTitleBar TitleBar => _customTitleBar;
    }
}
