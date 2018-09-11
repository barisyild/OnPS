using System;
using System.Drawing;
using System.Windows.Forms;

namespace SteamTheme
{
	internal class SteamSeparator : ThemeControl153
	{
		public SteamSeparator()
		{
		}

		protected override void ColorHook()
		{
		}

		protected override void PaintHook()
		{
			this.G.FillRectangle(new SolidBrush(Color.FromArgb(38, 38, 38)), base.ClientRectangle);
			base.DrawGradient(Color.FromArgb(107, 104, 101), Color.FromArgb(74, 72, 70), new Rectangle(0, checked((int)Math.Round((double)base.Height / 2)), base.Width, 1), 45f);
		}
	}
}