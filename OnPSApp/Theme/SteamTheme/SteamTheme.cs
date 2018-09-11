using System;
using System.Drawing;
using System.Windows.Forms;

namespace SteamTheme
{
	internal class SteamTheme : ThemeContainer153
	{
		public SteamTheme()
		{
			this.ForeColor = Color.FromArgb(226, 226, 226);
			this.Font = new System.Drawing.Font("Segoe UI", 7f);
		}

		protected override void ColorHook()
		{
		}

		protected override void PaintHook()
		{
			base.DrawGradient(Color.FromArgb(25, 54, 82), Color.FromArgb(29, 30, 31), base.ClientRectangle, 43f);
			base.DrawGradient(Color.FromArgb(25, 54, 82), Color.Transparent, base.ClientRectangle, -100f);
			this.G.FillRectangle(new SolidBrush(Color.FromArgb(38, 38, 38)), new Rectangle(1, 1, checked(base.Width - 2), checked(base.Height - 2)));
			base.DrawGradient(Color.FromArgb(30, 36, 44), Color.FromArgb(38, 38, 38), new Rectangle(1, 1, checked(base.Width - 2), 35), 90f);
			base.DrawText(new SolidBrush(Color.FromArgb(195, 193, 191)), HorizontalAlignment.Left, 7, 2);
		}
	}
}