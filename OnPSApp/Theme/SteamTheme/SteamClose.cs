using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SteamTheme
{
	internal class SteamClose : Control
	{
		private MouseState _State;

		public SteamClose()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			base.Size = new System.Drawing.Size(12, 12);
		}

		protected override void OnClick(EventArgs e)
		{
			base.OnClick(e);
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			this._State = MouseState.Down;
			base.Invalidate();
		}

		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseEnter(e);
			this._State = MouseState.Over;
			base.Invalidate();
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			this._State = MouseState.None;
			base.Invalidate();
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			this._State = MouseState.Over;
			base.Invalidate();
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			Graphics graphics = e.Graphics;
			this.BackColor = Color.Transparent;
			StringFormat stringFormat = new StringFormat()
			{
				Alignment = StringAlignment.Center,
				LineAlignment = StringAlignment.Center
			};
			graphics.DrawString("✕", new System.Drawing.Font("Segoe UI Symbol", 10.03f, FontStyle.Bold), new LinearGradientBrush(new Point(0, 0), new Point(0, base.Height), Color.FromArgb(175, 175, 175), Color.FromArgb(175, 175, 175)), new RectangleF(0f, 0f, (float)base.Width, (float)base.Height), stringFormat);
			MouseState mouseState = this._State;
			if (mouseState == MouseState.Over)
			{
				graphics.DrawString("✕", new System.Drawing.Font("Segoe UI Symbol", 10.03f, FontStyle.Bold), new LinearGradientBrush(new Point(0, 0), new Point(0, base.Height), Color.FromArgb(226, 226, 226), Color.FromArgb(226, 226, 226)), new RectangleF(0f, 0f, (float)base.Width, (float)base.Height), stringFormat);
			}
			else if (mouseState == MouseState.Down)
			{
				graphics.DrawString("✕", new System.Drawing.Font("Segoe UI Symbol", 10.03f, FontStyle.Bold), new SolidBrush(Color.FromArgb(40, Color.Black)), new RectangleF(0f, 0f, (float)base.Width, (float)base.Height), stringFormat);
			}
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			base.Size = new System.Drawing.Size(12, 12);
		}
	}
}