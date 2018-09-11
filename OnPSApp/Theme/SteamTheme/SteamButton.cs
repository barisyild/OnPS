using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SteamTheme
{
	internal class SteamButton : ThemeControl153
	{
		private SteamButton._Options O;

		[Category("Activated")]
		public SteamButton._Options Activated
		{
			get
			{
				return this.O;
			}
			set
			{
				this.O = value;
			}
		}

		public SteamButton()
		{
			this.Font = new System.Drawing.Font("Verdana", 7.25f);
		}

		protected override void ColorHook()
		{
		}

		protected override void PaintHook()
		{
			this.G.Clear(Color.FromArgb(38, 38, 38));
			SteamButton._Options o = this.O;
			if (o == SteamButton._Options._true)
			{
				switch (this.State)
				{
					case MouseState.None:
					{
						base.DrawGradient(Color.FromArgb(79, 79, 79), Color.FromArgb(58, 58, 58), base.ClientRectangle, 90f);
						break;
					}
					case MouseState.Over:
					{
						base.DrawGradient(Color.FromArgb(105, 105, 105), Color.FromArgb(61, 61, 61), base.ClientRectangle, 90f);
						break;
					}
					case MouseState.Down:
					{
						base.DrawGradient(Color.FromArgb(39, 39, 39), Color.FromArgb(57, 57, 57), base.ClientRectangle, 90f);
						break;
					}
				}
				base.DrawText(new SolidBrush(Color.FromArgb(195, 193, 191)), this.Text.ToUpper(), HorizontalAlignment.Left, 4, 0);
			}
			else if (o == SteamButton._Options._false)
			{
				switch (this.State)
				{
					case MouseState.None:
					{
						base.DrawGradient(Color.FromArgb(44, 44, 44), Color.FromArgb(44, 44, 44), base.ClientRectangle, 90f);
						break;
					}
					case MouseState.Over:
					{
						base.DrawGradient(Color.FromArgb(44, 44, 44), Color.FromArgb(44, 44, 44), base.ClientRectangle, 90f);
						break;
					}
					case MouseState.Down:
					{
						base.DrawGradient(Color.FromArgb(44, 44, 44), Color.FromArgb(44, 44, 44), base.ClientRectangle, 90f);
						break;
					}
				}
				base.DrawText(new SolidBrush(Color.FromArgb(115, 115, 115)), this.Text.ToUpper(), HorizontalAlignment.Left, 4, 0);
			}
		}

		[Flags]
		public enum _Options
		{
			_true,
			_false
		}
	}
}