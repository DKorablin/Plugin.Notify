using System.Reflection;
using System.Runtime.InteropServices;

[assembly: ComVisible(false)]
[assembly: Guid("a9e8eb60-7922-4115-8866-d19debe2cc1b")]
[assembly: System.CLSCompliant(true)]

#if NETCOREAPP
[assembly: AssemblyMetadata("ProjectUrl", "https://github.com/DKorablin/Plugin.Notify")]
#else

[assembly: AssemblyTitle("Plugin.Notify")]
[assembly: AssemblyDescription("Create a nifty notify window")]
#if DEBUG
[assembly: AssemblyConfiguration("Debug")]
#else
[assembly: AssemblyConfiguration("Release")]
#endif
[assembly: AssemblyCompany("Danila Korablin")]
[assembly: AssemblyProduct("Plugin.Notify")]
[assembly: AssemblyCopyright("Copyright © Danila Korablin 2013-2014")]
#endif