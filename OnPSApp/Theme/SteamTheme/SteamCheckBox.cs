using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

namespace SteamTheme
{
	[DefaultEvent("CheckedChanged")]
	internal class SteamCheckBox : Control
	{
		private int W;

		private int H;

		private MouseState State;

		private SteamCheckBox._Options O;

		private bool _Checked;

		internal Graphics G;

		internal Bitmap B;

		internal Color _FlatColor;

		internal StringFormat NearSF;

		internal StringFormat CenterSF;

		private Color _BaseColor;

		private Color _BorderColor;

		private Color _TextColor;

		private Color checkcolor;

		[Category("Colors")]
		public Color BaseColor
		{
			get
			{
				return this._BaseColor;
			}
			set
			{
				this._BaseColor = value;
			}
		}

		[Category("Colors")]
		public Color BorderColor
		{
			get
			{
				return this._BorderColor;
			}
			set
			{
				this._BorderColor = value;
			}
		}

		public bool Checked
		{
			get
			{
				return this._Checked;
			}
			set
			{
				this._Checked = value;
				base.Invalidate();
			}
		}

		[Category("Options")]
		public SteamCheckBox._Options Options
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

        public MouseState State1;

        public SteamCheckBox()
		{
			this.State = MouseState.None;
			this._FlatColor = Color.FromArgb(103, 103, 103);
			this.NearSF = new StringFormat()
			{
				Alignment = StringAlignment.Near,
				LineAlignment = StringAlignment.Near
			};
			this.CenterSF = new StringFormat()
			{
				Alignment = StringAlignment.Center,
				LineAlignment = StringAlignment.Center
			};
			this._BaseColor = Color.FromArgb(38, 38, 38);
			this._BorderColor = Color.FromArgb(103, 103, 103);
			this._TextColor = Color.FromArgb(226, 226, 226);
			this.checkcolor = Color.FromArgb(226, 226, 226);
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			this.BackColor = Color.FromArgb(38, 38, 38);
			this.Cursor = Cursors.Hand;
			this.Font = new System.Drawing.Font("Segoe UI", 8f);
			base.Size = new System.Drawing.Size(112, 22);
		}

		protected override void OnClick(EventArgs e)
		{
			this._Checked = !this._Checked;
			SteamCheckBox.CheckedChangedEventHandler checkedChangedEventHandler = this.CheckedChanged;
			if (checkedChangedEventHandler != null)
			{
				checkedChangedEventHandler(this);
			}
			base.OnClick(e);
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			this.State = MouseState.Down;
			base.Invalidate();
		}

		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseEnter(e);
			this.State = MouseState.Over;
			base.Invalidate();
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			this.State = MouseState.None;
			base.Invalidate();
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			this.State = MouseState.Over;
			base.Invalidate();
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			this.B = new Bitmap(base.Width, base.Height);
			this.G = Graphics.FromImage(this.B);
			this.W = checked(base.Width - 1);
			this.H = checked(base.Height - 1);
			Rectangle rectangle = new Rectangle(0, 2, checked(base.Height - 5), checked(base.Height - 5));
			Graphics g = this.G;
			g.SmoothingMode = SmoothingMode.HighQuality;
			g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			g.Clear(this.BackColor);
			g.FillRectangle(new SolidBrush(this._BaseColor), rectangle);
			g.DrawRectangle(new Pen(this._BorderColor), rectangle);
			if (this.Checked)
			{
				g.DrawString("", new System.Drawing.Font("Segoe UI Symbol", 10f), new SolidBrush(this.checkcolor), new Rectangle(4, 6, checked(this.H - 9), checked(this.H - 10)), this.CenterSF);
			}
			g.DrawString(this.Text, this.Font, new SolidBrush(this._TextColor), new Rectangle(25, 4, this.W, this.H), this.NearSF);
			g = null;
			base.OnPaint(e);
			this.G.Dispose();
			e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			e.Graphics.DrawImageUnscaled(this.B, 0, 0);
			this.B.Dispose();
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			base.Height = 22;
		}

		protected override void OnTextChanged(EventArgs e)
		{
			base.OnTextChanged(e);
			base.Invalidate();
		}

		public event SteamCheckBox.CheckedChangedEventHandler CheckedChanged;

		[Flags]
		public enum _Options
		{
			Style1,
			Style2
		}

		public delegate void CheckedChangedEventHandler(object sender);
	}
}