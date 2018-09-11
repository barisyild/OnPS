using System;
using System.Drawing;
using System.Windows.Forms;

namespace SteamTheme
{
	internal class SteamProgressBar : ThemeControl153
	{
		private int _Maximum;

		private int _Value;

		public int Maximum
		{
			get
			{
				return this._Maximum;
			}
			set
			{
				if (value < this._Value)
				{
					this._Value = value;
				}
				this._Maximum = value;
				base.Invalidate();
			}
		}

		public int Value
		{
			get
			{
				return (this._Value == 0 ? 1 : this._Value);
			}
			set
			{
				if (value > this._Maximum)
				{
					value = this._Maximum;
				}
				this._Value = value;
				base.Invalidate();
			}
		}

		public SteamProgressBar()
		{
			base.Transparent = true;
			this.BackColor = Color.Transparent;
			base.LockHeight = 18;
			this.Value = 0;
			this.Maximum = 100;
		}

		protected override void ColorHook()
		{
		}

		protected override void PaintHook()
		{
			this.G.Clear(this.BackColor);
			int ınt32 = this._Value;
			if (ınt32 > 2)
			{
				this.G.FillRectangle(new SolidBrush(Color.FromArgb(166, 164, 161)), new Rectangle(4, 4, checked(checked((int)Math.Round((double)this._Value / (double)this._Maximum * (double)base.Width)) - 8), checked(base.Height - 8)));
			}
			else if (ınt32 > 0)
			{
				this.G.FillRectangle(new SolidBrush(Color.FromArgb(166, 164, 161)), new Rectangle(4, 4, checked(checked((int)Math.Round((double)this._Value / (double)this._Maximum * (double)base.Width)) - 2), checked(base.Height - 8)));
			}
			base.DrawBorders(new Pen(new SolidBrush(Color.FromArgb(128, 124, 120))));
			base.DrawCorners(this.BackColor);
		}
	}
}