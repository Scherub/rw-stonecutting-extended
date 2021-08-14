using Verse;

namespace StonecuttingExtended
{
	[StaticConstructorOnStartup]
	public static class StonecuttingExtendedStartUp
	{
		static StonecuttingExtendedStartUp()
		{
			StonecuttingExtendedDefsUpdater.UpdateDefs();
		}
	}
}
