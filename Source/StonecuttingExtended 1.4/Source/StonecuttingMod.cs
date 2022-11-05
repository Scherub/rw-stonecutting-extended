using StonecuttingExtended.Defs;
using StonecuttingExtended.Settings;
using UnityEngine;
using Verse;

namespace StonecuttingExtended
{
	public class StonecuttingMod : Mod
	{
		public static StonecuttingSettings Settings { get; private set; } = default!;

		public StonecuttingMod(ModContentPack content)
			: base(content)
		{
			Settings = GetSettings<StonecuttingSettings>();
		}

		public override void DoSettingsWindowContents(Rect inRect)
		{
			StonecuttingDisplaySettings.DisplaySettings(Settings, inRect);

			base.DoSettingsWindowContents(inRect);
		}

		public override string SettingsCategory()
		{
			return "Stonecutting Extended";
		}

		public override void WriteSettings()
		{
			DefsUpdater.UpdateDefs();

			base.WriteSettings();
		}
	}
}
