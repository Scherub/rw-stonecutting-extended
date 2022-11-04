using UnityEngine;
using Verse;

namespace StonecuttingExtended
{
	public class StonecuttingExtendedMod : Mod
	{
		readonly StonecuttingExtendedSettings _settings;

		public StonecuttingExtendedMod(ModContentPack content)
			: base(content)
		{
			_settings = GetSettings<StonecuttingExtendedSettings>();
		}

		public override void DoSettingsWindowContents(Rect inRect)
		{
			StonecuttingExtendedDisplaySettings.DisplaySettings(_settings, inRect);

			base.DoSettingsWindowContents(inRect);
		}

		public override string SettingsCategory()
		{
			return "Stonecutting Extended";
		}

		public override void WriteSettings()
		{
			StonecuttingExtendedDefsUpdater.UpdateDefs();

			base.WriteSettings();
		}
	}
}
