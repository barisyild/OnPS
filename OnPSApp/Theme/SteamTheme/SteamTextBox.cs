using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace SteamTheme
{
	internal class SteamTextBox : ThemeControl153
	{
		private bool _PassMask;

		private int _maxchars;

        //private Pen P1;
        private TextBox _txtbox;

        public int MaxCharacters
		{
			get
			{
				return this._maxchars;
			}
			set
			{
				this._maxchars = value;
			}
		}

		private TextBox txtbox
		{
			get
			{
				TextBox stackVariable1 = _txtbox;
				return stackVariable1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				EventHandler eventHandler = (object a0, EventArgs a1) => this.TextChngTxtBox();
				TextBox textBox = this._txtbox;
				if (textBox != null)
				{
					textBox.TextChanged -= eventHandler;
				}
				this._txtbox = value;
				textBox = this._txtbox;
				if (textBox != null)
				{
					textBox.TextChanged += eventHandler;
				}
			}
		}

		public bool UsePasswordMask
		{
			get
			{
				return this._PassMask;
			}
			set
			{
				this._PassMask = value;
				base.Invalidate();
			}
		}

		public SteamTextBox()
		{
			base.TextChanged += new EventHandler((object a0, EventArgs a1) => this.TextChng());
			this.txtbox = new TextBox()
			{
				TextAlign = HorizontalAlignment.Left,
				BorderStyle = BorderStyle.None,
				Location = new Point(4, 4),
				Font = new System.Drawing.Font("Segoe UI", 8f)
			};
			base.Controls.Add(this.txtbox);
			this.Text = "";
			this.txtbox.Text = "";
			base.Size = new System.Drawing.Size(135, 22);
			base.Transparent = true;
			this.BackColor = Color.Transparent;
		}

		protected override void ColorHook()
		{
		}

		protected override void PaintHook()
		{
			this.G.Clear(Color.FromArgb(38, 38, 38));
			bool usePasswordMask = this.UsePasswordMask;
			if (!usePasswordMask)
			{
				this.txtbox.UseSystemPasswordChar = false;
			}
			else if (usePasswordMask)
			{
				this.txtbox.UseSystemPasswordChar = true;
			}
			base.Size = new System.Drawing.Size(base.Width, 22);
			this.txtbox.BackColor = Color.FromArgb(38, 38, 38);
			this.txtbox.ForeColor = Color.FromArgb(195, 193, 191);
			this.txtbox.Font = this.Font;
			this.txtbox.Size = new System.Drawing.Size(checked(base.Width - 10), checked(this.txtbox.Height - 10));
			this.txtbox.MaxLength = this.MaxCharacters;
			base.DrawBorders(new Pen(new SolidBrush(Color.FromArgb(137, 137, 137))));
			base.DrawCorners(this.BackColor);
		}

		public void TextChng()
		{
			this.txtbox.Text = this.Text;
		}

		public void TextChngTxtBox()
		{
			this.Text = this.txtbox.Text;
		}
	}
}