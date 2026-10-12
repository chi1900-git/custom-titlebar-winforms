using System;
using System.Drawing;
using System.Windows.Forms;

namespace CustomTitleBarWinForms
{
    public class CustomTitleBar : Panel
    {
        private Label _titleLabel;
        private Button _btnMinimize;
        private Button _btnMaximize;
        private Button _btnClose;
        private Form _parentForm;
        private Point _dragStartPoint;
        private bool _isDragging = false;

        // Properties
        private int _titleBarHeight = 40;
        private Color _titleBarBackColor = Color.FromArgb(33, 37, 41);
        private Color _titleFontColor = Color.White;
        private Font _titleFont = new Font("Segoe UI", 11, FontStyle.Bold);
        private Color _buttonHoverColor = Color.FromArgb(60, 60, 60);
        private Color _buttonPressColor = Color.FromArgb(45, 45, 45);
        private Color _closeButtonHoverColor = Color.FromArgb(232, 17, 35);
        private Color _closeButtonPressColor = Color.FromArgb(204, 9, 47);

        public int TitleBarHeight
        {
            get => _titleBarHeight;
            set
            {
                _titleBarHeight = value;
                this.Height = value;
                RefreshLayout();
            }
        }

        public Color TitleBarBackColor
        {
            get => _titleBarBackColor;
            set
            {
                _titleBarBackColor = value;
                this.BackColor = value;
            }
        }

        public Color TitleFontColor
        {
            get => _titleFontColor;
            set
            {
                _titleFontColor = value;
                if (_titleLabel != null)
                    _titleLabel.ForeColor = value;
            }
        }

        public Font TitleFont
        {
            get => _titleFont;
            set
            {
                _titleFont = value;
                if (_titleLabel != null)
                    _titleLabel.Font = value;
            }
        }

        public Color ButtonHoverColor
        {
            get => _buttonHoverColor;
            set => _buttonHoverColor = value;
        }

        public Color ButtonPressColor
        {
            get => _buttonPressColor;
            set => _buttonPressColor = value;
        }

        public Color CloseButtonHoverColor
        {
            get => _closeButtonHoverColor;
            set => _closeButtonHoverColor = value;
        }

        public Color CloseButtonPressColor
        {
            get => _closeButtonPressColor;
            set => _closeButtonPressColor = value;
        }

        public CustomTitleBar(Form parentForm)
        {
            _parentForm = parentForm;
            this.Dock = DockStyle.Top;
            this.Height = _titleBarHeight;
            this.BackColor = _titleBarBackColor;
            this.Cursor = Cursors.Default;

            InitializeControls();
            SetupEvents();
        }

        private void InitializeControls()
        {
            // Title Label
            _titleLabel = new Label
            {
                Text = _parentForm.Text,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                ForeColor = _titleFontColor,
                Font = _titleFont,
                Padding = new Padding(15, 0, 0, 0)
            };
            this.Controls.Add(_titleLabel);

            // Close Button
            _btnClose = CreateButton("✕", 0);
            _btnClose.Click += (s, e) => _parentForm.Close();
            _btnClose.MouseEnter += (s, e) => _btnClose.BackColor = _closeButtonHoverColor;
            _btnClose.MouseLeave += (s, e) => _btnClose.BackColor = _titleBarBackColor;
            _btnClose.MouseDown += (s, e) => _btnClose.BackColor = _closeButtonPressColor;
            _btnClose.MouseUp += (s, e) => _btnClose.BackColor = _closeButtonHoverColor;

            // Maximize Button
            _btnMaximize = CreateButton("□", 50);
            _btnMaximize.Click += (s, e) => ToggleMaximize();
            this.Controls.Add(_btnMaximize);

            // Minimize Button
            _btnMinimize = CreateButton("_", 100);
            _btnMinimize.Click += (s, e) => _parentForm.WindowState = FormWindowState.Minimized;
            this.Controls.Add(_btnMinimize);

            this.Controls.Add(_btnClose);
        }

        private Button CreateButton(string text, int rightOffset)
        {
            var btn = new Button
            {
                Text = text,
                Width = 50,
                Height = _titleBarHeight,
                Dock = DockStyle.Right,
                FlatStyle = FlatStyle.Flat,
                BackColor = _titleBarBackColor,
                ForeColor = _titleFontColor,
                Font = new Font("Segoe UI", 10),
                Cursor = Cursors.Hand,
                FlatAppearance = { BorderSize = 0 }
            };

            btn.MouseEnter += (s, e) => btn.BackColor = _buttonHoverColor;
            btn.MouseLeave += (s, e) => btn.BackColor = _titleBarBackColor;
            btn.MouseDown += (s, e) => btn.BackColor = _buttonPressColor;
            btn.MouseUp += (s, e) => btn.BackColor = _buttonHoverColor;

            return btn;
        }

        private void ToggleMaximize()
        {
            if (_parentForm.WindowState == FormWindowState.Normal)
            {
                _parentForm.WindowState = FormWindowState.Maximized;
                _btnMaximize.Text = "❑";
            }
            else
            {
                _parentForm.WindowState = FormWindowState.Normal;
                _btnMaximize.Text = "□";
            }
        }

        private void SetupEvents()
        {
            _titleLabel.MouseDown += TitleLabel_MouseDown;
            _titleLabel.MouseMove += TitleLabel_MouseMove;
            _titleLabel.MouseUp += TitleLabel_MouseUp;
            _titleLabel.DoubleClick += (s, e) => ToggleMaximize();
        }

        private void TitleLabel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && _parentForm.WindowState == FormWindowState.Normal)
            {
                _isDragging = true;
                _dragStartPoint = e.Location;
            }
        }

        private void TitleLabel_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isDragging && _parentForm.WindowState == FormWindowState.Normal)
            {
                Point diff = new Point(
                    e.Location.X - _dragStartPoint.X,
                    e.Location.Y - _dragStartPoint.Y
                );

                _parentForm.Location = new Point(
                    _parentForm.Location.X + diff.X,
                    _parentForm.Location.Y + diff.Y
                );
            }
        }

        private void TitleLabel_MouseUp(object sender, MouseEventArgs e)
        {
            _isDragging = false;
        }

        private void RefreshLayout()
        {
            _titleLabel.Height = _titleBarHeight;
            _btnMinimize.Height = _titleBarHeight;
            _btnMaximize.Height = _titleBarHeight;
            _btnClose.Height = _titleBarHeight;
            _titleLabel.Font = new Font(_titleFont.FontFamily, _titleFont.Size, _titleFont.Style);
        }
    }
}
