using System;
using System.Drawing;
using System.Windows.Forms;

namespace CustomTitleBarWinForms
{
    public class MainForm : CustomForm
    {
        private GroupBox _groupProperties;
        private Label _lblHeight;
        private NumericUpDown _numHeight;
        private Label _lblFontSize;
        private NumericUpDown _numFontSize;
        private Label _lblBackColor;
        private Button _btnBackColor;
        private Label _lblFontColor;
        private Button _btnFontColor;
        private Label _lblButtonHover;
        private Button _btnButtonHover;
        private Label _lblCloseHover;
        private Button _btnCloseHover;
        private TextBox _txtTitle;
        private Label _lblTitle;
        private Button _btnReset;
        private ColorDialog _colorDialog;

        public MainForm()
        {
            this.Text = "Custom Title Bar - WinForms Demo";
            this.Size = new Size(900, 700);

            InitializeComponents();
            LoadDefaultValues();
        }

        private void InitializeComponents()
        {
            _colorDialog = new ColorDialog();

            // Panel Properties
            _groupProperties = new GroupBox
            {
                Text = "Title Bar Properties",
                Location = new Point(20, 70),
                Size = new Size(840, 600),
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };

            // Title
            _lblTitle = new Label
            {
                Text = "Title Text:",
                Location = new Point(20, 40),
                Size = new Size(120, 30),
                TextAlign = ContentAlignment.MiddleLeft
            };

            _txtTitle = new TextBox
            {
                Location = new Point(150, 40),
                Size = new Size(300, 30),
                Font = new Font("Segoe UI", 10)
            };
            _txtTitle.TextChanged += (s, e) => {
                this.Text = _txtTitle.Text;
                _customTitleBar.Text = _txtTitle.Text;
            };

            // Height
            _lblHeight = new Label
            {
                Text = "Title Bar Height:",
                Location = new Point(20, 90),
                Size = new Size(120, 30),
                TextAlign = ContentAlignment.MiddleLeft
            };

            _numHeight = new NumericUpDown
            {
                Location = new Point(150, 90),
                Size = new Size(100, 30),
                Minimum = 30,
                Maximum = 80,
                Value = 45,
                Font = new Font("Segoe UI", 10)
            };
            _numHeight.ValueChanged += (s, e) => _customTitleBar.TitleBarHeight = (int)_numHeight.Value;

            // Font Size
            _lblFontSize = new Label
            {
                Text = "Font Size:",
                Location = new Point(20, 140),
                Size = new Size(120, 30),
                TextAlign = ContentAlignment.MiddleLeft
            };

            _numFontSize = new NumericUpDown
            {
                Location = new Point(150, 140),
                Size = new Size(100, 30),
                Minimum = 8,
                Maximum = 24,
                Value = 12,
                Font = new Font("Segoe UI", 10)
            };
            _numFontSize.ValueChanged += (s, e) => {
                var currentFont = _customTitleBar.TitleFont;
                _customTitleBar.TitleFont = new Font(currentFont.FontFamily, (float)_numFontSize.Value, currentFont.Style);
            };

            // Back Color
            _lblBackColor = new Label
            {
                Text = "Title Bar Color:",
                Location = new Point(20, 190),
                Size = new Size(120, 30),
                TextAlign = ContentAlignment.MiddleLeft
            };

            _btnBackColor = new Button
            {
                Location = new Point(150, 190),
                Size = new Size(100, 30),
                BackColor = Color.FromArgb(33, 37, 41),
                ForeColor = Color.White,
                Text = "Choose Color",
                FlatStyle = FlatStyle.Flat
            };
            _btnBackColor.Click += (s, e) => {
                _colorDialog.Color = _customTitleBar.TitleBarBackColor;
                if (_colorDialog.ShowDialog() == DialogResult.OK)
                {
                    _customTitleBar.TitleBarBackColor = _colorDialog.Color;
                    _btnBackColor.BackColor = _colorDialog.Color;
                }
            };

            // Font Color
            _lblFontColor = new Label
            {
                Text = "Font Color:",
                Location = new Point(20, 240),
                Size = new Size(120, 30),
                TextAlign = ContentAlignment.MiddleLeft
            };

            _btnFontColor = new Button
            {
                Location = new Point(150, 240),
                Size = new Size(100, 30),
                BackColor = Color.White,
                ForeColor = Color.Black,
                Text = "Choose Color",
                FlatStyle = FlatStyle.Flat
            };
            _btnFontColor.Click += (s, e) => {
                _colorDialog.Color = _customTitleBar.TitleFontColor;
                if (_colorDialog.ShowDialog() == DialogResult.OK)
                {
                    _customTitleBar.TitleFontColor = _colorDialog.Color;
                    _btnFontColor.BackColor = _colorDialog.Color;
                }
            };

            // Button Hover Color
            _lblButtonHover = new Label
            {
                Text = "Button Hover Color:",
                Location = new Point(20, 290),
                Size = new Size(120, 30),
                TextAlign = ContentAlignment.MiddleLeft
            };

            _btnButtonHover = new Button
            {
                Location = new Point(150, 290),
                Size = new Size(100, 30),
                BackColor = Color.FromArgb(60, 60, 60),
                ForeColor = Color.White,
                Text = "Choose Color",
                FlatStyle = FlatStyle.Flat
            };
            _btnButtonHover.Click += (s, e) => {
                _colorDialog.Color = _customTitleBar.ButtonHoverColor;
                if (_colorDialog.ShowDialog() == DialogResult.OK)
                {
                    _customTitleBar.ButtonHoverColor = _colorDialog.Color;
                    _btnButtonHover.BackColor = _colorDialog.Color;
                }
            };

            // Close Button Hover Color
            _lblCloseHover = new Label
            {
                Text = "Close Btn Hover:",
                Location = new Point(20, 340),
                Size = new Size(120, 30),
                TextAlign = ContentAlignment.MiddleLeft
            };

            _btnCloseHover = new Button
            {
                Location = new Point(150, 340),
                Size = new Size(100, 30),
                BackColor = Color.FromArgb(232, 17, 35),
                ForeColor = Color.White,
                Text = "Choose Color",
                FlatStyle = FlatStyle.Flat
            };
            _btnCloseHover.Click += (s, e) => {
                _colorDialog.Color = _customTitleBar.CloseButtonHoverColor;
                if (_colorDialog.ShowDialog() == DialogResult.OK)
                {
                    _customTitleBar.CloseButtonHoverColor = _colorDialog.Color;
                    _btnCloseHover.BackColor = _colorDialog.Color;
                }
            };

            // Reset Button
            _btnReset = new Button
            {
                Text = "Reset to Default",
                Location = new Point(20, 390),
                Size = new Size(230, 35),
                BackColor = Color.FromArgb(79, 70, 229),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            _btnReset.Click += (s, e) => ResetToDefault();

            // Add controls to group
            _groupProperties.Controls.Add(_lblTitle);
            _groupProperties.Controls.Add(_txtTitle);
            _groupProperties.Controls.Add(_lblHeight);
            _groupProperties.Controls.Add(_numHeight);
            _groupProperties.Controls.Add(_lblFontSize);
            _groupProperties.Controls.Add(_numFontSize);
            _groupProperties.Controls.Add(_lblBackColor);
            _groupProperties.Controls.Add(_btnBackColor);
            _groupProperties.Controls.Add(_lblFontColor);
            _groupProperties.Controls.Add(_btnFontColor);
            _groupProperties.Controls.Add(_lblButtonHover);
            _groupProperties.Controls.Add(_btnButtonHover);
            _groupProperties.Controls.Add(_lblCloseHover);
            _groupProperties.Controls.Add(_btnCloseHover);
            _groupProperties.Controls.Add(_btnReset);

            this.Controls.Add(_groupProperties);
        }

        private void LoadDefaultValues()
        {
            _txtTitle.Text = this.Text;
            _numHeight.Value = _customTitleBar.TitleBarHeight;
            _numFontSize.Value = (decimal)_customTitleBar.TitleFont.Size;
            _btnBackColor.BackColor = _customTitleBar.TitleBarBackColor;
            _btnFontColor.BackColor = _customTitleBar.TitleFontColor;
            _btnButtonHover.BackColor = _customTitleBar.ButtonHoverColor;
            _btnCloseHover.BackColor = _customTitleBar.CloseButtonHoverColor;
        }

        private void ResetToDefault()
        {
            _customTitleBar.TitleBarHeight = 45;
            _customTitleBar.TitleBarBackColor = Color.FromArgb(33, 37, 41);
            _customTitleBar.TitleFontColor = Color.White;
            _customTitleBar.TitleFont = new Font("Segoe UI", 12, FontStyle.Bold);
            _customTitleBar.ButtonHoverColor = Color.FromArgb(60, 60, 60);
            _customTitleBar.CloseButtonHoverColor = Color.FromArgb(232, 17, 35);

            LoadDefaultValues();
        }
    }
}
