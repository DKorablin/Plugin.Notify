using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Plugin.Notify
{
	internal partial class AlertDialog : Form
	{
		private const Int32 CS_DROPSHADOW = 0x00020000;

		internal static readonly List<AlertDialog> _shownDialogs = new List<AlertDialog>();

		private readonly PluginWindows _plugin;

		/// <summary>Y coordinate</summary>
		private Int32 _startPosition = 0;
		private Rectangle _workingArea;
		private Boolean _hide = false;

		/// <summary>Displaying a color header</summary>
		public Color TitleBackColor
		{
			get => pnlTitle.BackColor;
			set => pnlTitle.BackColor = value;
		}

		/// <summary>Form Title</summary>
		public String TitleText
		{
			get => lblTitle.Text;
			set => lblTitle.Text = value;
		}
		
		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams items = base.CreateParams;
				items.ClassStyle |= CS_DROPSHADOW;
				return items;
			}
		}

		public AlertDialog(PluginWindows plugin)
		{
			this._plugin = plugin ?? throw new ArgumentNullException(nameof(plugin));

			this.InitializeComponent();
		}

		private void SystemEvents_DisplaySettingsChanged(Object sender, EventArgs e)
		{
			this._workingArea = SystemInformation.WorkingArea;
			this.SetDialogLocation(true);
		}

		private void opacityTimer_Tick(Object sender, EventArgs e)
		{
			if(this._hide)
			{
				if(base.Opacity > 0)
					base.Opacity -= 0.1f;
				else
				{
					opacityTimer.Stop();
					this.Dispose();
				}
			} else
			{
				if(base.Opacity < 1.0f)
					base.Opacity += 0.1f;
				else
					opacityTimer.Stop();
			}
		}

		private void moveTimer_Tick(Object sender, EventArgs e)
		{
			if(this._hide)
			{
				if(base.Location.Y > this._startPosition)
					moveTimer.Stop();
				else
					base.Location = new Point(base.Location.X, base.Location.Y + 10);
			} else
			{
				if(base.Location.Y + base.Size.Height > this._startPosition)
					base.Location = new Point(base.Location.X, base.Location.Y - 10);
				else
					moveTimer.Stop();
			}
		}

		private void bnClose_Click(Object sender, EventArgs e)
			=> this.Hide();

		private void bnClose_MouseHover(Object sender, EventArgs e)
		{
			Cursor = Cursors.Hand;
			bnClose.ImageIndex = 1;
		}

		private void bnClose_MouseLeave(Object sender, EventArgs e)
		{
			Cursor = Cursors.Default;
			bnClose.ImageIndex = 0;
		}

		protected override Boolean ProcessDialogKey(Keys keyData)
		{
			switch(keyData)
			{
			case Keys.Escape:
				this.Hide();
				return true;
			default:
				return base.ProcessDialogKey(keyData);
			}
		}

		public void ShowInfo(Color titleBackColor, String titleText, params String[] items)
		{
			this.TitleBackColor = titleBackColor;
			this.TitleText = titleText;

			flowLabels.Controls.Clear();

			if(items != null && items.Length > 0)
			{
				base.Height += 5;

				Int32 count = 0;
				foreach(String item in items)
				{
					AlertItemLabel lbl = new AlertItemLabel(item);
					flowLabels.Controls.Add(lbl);
					base.Height += lbl.Height + lbl.Padding.Size.Height + lbl.Margin.Size.Height;
					if(count++ == 10)
					{
						lbl.Title = "...";
						break;
					}
				}
			}

			this.Show();
		}

		public new void Show()
		{
			this.ResetTimers(false);

			if(!AlertDialog._shownDialogs.Contains(this))
				AlertDialog._shownDialogs.Add(this);

			SystemEvents.DisplaySettingsChanged += new EventHandler(SystemEvents_DisplaySettingsChanged);
			this.SetDialogLocation(false);
			base.Show();

			opacityTimer.Start();
			moveTimer.Start();
		}

		private void SetDialogLocation(Boolean isShown)
		{
			Int32 dlgHeight = 0;// = isShown ? base.Size.Height : 0;

			foreach(AlertDialog dlg in AlertDialog._shownDialogs)
			{
				if(dlg == this)
				{
					if(isShown)
						dlgHeight += base.Size.Height;
					break;
				} else
					dlgHeight += dlg.Size.Height;
			}

			Int32 y = this._workingArea.Height - dlgHeight;
			this._startPosition = y;
			if(isShown)//If the window is already displayed, the starting position should be at the bottom of the window, not in the upper right corner.
				this._startPosition -= base.Size.Height;

			base.Location = new Point(this._workingArea.Width - base.Size.Width - 15, y);
		}

		public new void Hide()
		{
			SystemEvents.DisplaySettingsChanged -= SystemEvents_DisplaySettingsChanged;
			this.ResetTimers(true);
			opacityTimer.Start();
			moveTimer.Start();
		}

		/*/// <summary>
		/// Constants in Windows API
		/// 0x84 = WM_NCHITTEST - Mouse Capture Test
		/// 0x1 = HTCLIENT - Application Client Area
		/// 0x2 = HTCAPTION - Application Title Bar
		/// 
		/// This function intercepts all the commands sent to the application. 
		/// It checks to see of the message is a mouse click in the application. 
		/// It passes the action to the base action by default. It reassigns 
		/// the action to the title bar if it occurred in the client area
		/// to allow the drag and move behavior.
		/// </summary>
		protected override void WndProc(ref Message m)
		{
			switch(m.Msg)
			{
				case 0x84:
					base.WndProc(ref m);
					if((Int32)m.Result == 0x1)
						m.Result = (IntPtr)0x2;
					break;
				default:
					base.WndProc(ref m);
					break;
			}
		}*/

		private void ResetTimers(Boolean hide)
		{
			opacityTimer.Stop();
			moveTimer.Stop();

			this._hide = hide;
			if(!this._hide)
			{
				base.Opacity = 0;

				this._workingArea = SystemInformation.WorkingArea;
			}
		}
		/// <summary>Clean up any resources being used.</summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(Boolean disposing)
		{
			if(disposing && components != null)
			{
				if(AlertDialog._shownDialogs.Remove(this))//I remove the dialog from the array and move all other windows to the current window's location.
					foreach(AlertDialog dlg in AlertDialog._shownDialogs)
						dlg.SystemEvents_DisplaySettingsChanged(null, EventArgs.Empty);
				components.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}