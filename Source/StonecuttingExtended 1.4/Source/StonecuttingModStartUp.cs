using StonecuttingExtended.Defs;
using Verse;

namespace StonecuttingExtended
{
	[StaticConstructorOnStartup]
	public static class StonecuttingModStartUp
	{
		static StonecuttingModStartUp()
		{
			DefsUpdater.UpdateDefs();
		}
	}
}
