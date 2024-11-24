using System;
using System.Windows.Forms;

namespace Plugin.Notify
{
	internal partial class AlertItemLabel : UserControl
	{
		public String Title
		{
			get => lblTitle.Text;
			set => lblTitle.Text = value;
		}

		public AlertItemLabel(String title)
		{
			InitializeComponent();
			this.Title = title;
		}
	}
}
