using System.Reflection;
using System.Runtime.InteropServices;

[assembly: Guid("a9e8eb60-7922-4115-8866-d19debe2cc1b")]
[assembly: System.CLSCompliant(true)]

#if NETCOREAPP
[assembly: AssemblyMetadata("ProjectUrl", "https://github.com/DKorablin/Plugin.Notify")]
#else

[assembly: AssemblyDescription("Creates a nifty notification window")]
[assembly: AssemblyCopyright("Copyright © Danila Korablin 2013-2014")]
#endif