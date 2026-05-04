using System;
using System.Drawing;
using System.Windows.Forms;
using SAL.Flatbed;

namespace Plugin.Notify
{
	public class PluginWindows : IPlugin
	{
		internal ITraceSource Trace { get; }

		public PluginWindows(ITraceSource trace)
		{
			this.Trace = trace ?? throw new ArgumentNullException(nameof(trace));
		}

		public Form ShowNotifyWindow(Color titleColor, String titleText, params String[] args)
		{
			AlertDialog dlg = new AlertDialog();
			dlg.ShowInfo(titleColor, titleText, args);
			return dlg;
		}

		public void HideNotifyWindow(String titleText)
		{
			for(Int32 loop = AlertDialog._shownDialogs.Count - 1; loop >= 0; loop--)
			{
				AlertDialog dlg = AlertDialog._shownDialogs[loop];
				if(dlg.TitleText == titleText)
				{
					AlertDialog._shownDialogs.RemoveAt(loop);
					dlg.Dispose();
				}
			}
		}

		Boolean IPlugin.OnConnection(ConnectMode mode)
			=> true;

		Boolean IPlugin.OnDisconnection(DisconnectMode mode)
		{
			foreach(AlertDialog dlg in AlertDialog._shownDialogs)
				dlg.Dispose();
			return true;
		}
	}
}