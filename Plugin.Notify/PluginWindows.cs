using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using SAL.Flatbed;
using SAL.Windows;

namespace Plugin.Notify
{
	public class PluginWindows : IPlugin
	{
		private readonly IHostWindows _hostWindows;
		private TraceSource _trace;

		internal TraceSource Trace { get => this._trace ?? (this._trace = PluginWindows.CreateTraceSource<PluginWindows>()); }

		public PluginWindows(IHostWindows hostWindows)
			=> this._hostWindows = hostWindows ?? throw new ArgumentNullException(nameof(hostWindows));

		public Form ShowNotifyWindow(Color titleColor, String titleText, params String[] args)
		{
			AlertDialog dlg = new AlertDialog(this);
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

		private static TraceSource CreateTraceSource<T>(String name = null) where T : IPlugin
		{
			TraceSource result = new TraceSource(typeof(T).Assembly.GetName().Name + name);
			result.Switch.Level = SourceLevels.All;
			result.Listeners.Remove("Default");
			result.Listeners.AddRange(System.Diagnostics.Trace.Listeners);
			return result;
		}
	}
}