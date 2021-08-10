using System;
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
			Listing_Standard listingStandard = new Listing_Standard();
			listingStandard.Begin(inRect);


			listingStandard.GapLine();

			listingStandard.Label("Used Skill", -1f, "The skill used for cutting chunks into stones.");
			listingStandard.Gap();

			if (listingStandard.RadioButton("Crafting", _settings.usedSkill == Skill.Crafting))
				_settings.usedSkill = Skill.Crafting;
			if (listingStandard.RadioButton("Art", _settings.usedSkill == Skill.Art))
				_settings.usedSkill = Skill.Art;

			listingStandard.GapLine();

			listingStandard.Label("Work Amount Multiplier (0.1 - 1.5): " + _settings.workAmountMultiplier);
			_settings.workAmountMultiplier = (float)Math.Round(listingStandard.Slider(_settings.workAmountMultiplier, 0.1f, 1.5f), 2);

			listingStandard.Label("Bulk Work Amount Multiplier (0.1 - 1.5): " + _settings.bulkWorkAmountMultiplier);
			_settings.bulkWorkAmountMultiplier = (float)Math.Round(listingStandard.Slider(_settings.bulkWorkAmountMultiplier, 0.1f, 1.5f), 2);

			listingStandard.Label("Skill Learn Factor (0.1 - 2.0): " + _settings.skillLearnFactor);
			_settings.skillLearnFactor = (float)Math.Round(listingStandard.Slider(_settings.skillLearnFactor, 0.1f, 2f), 2);

			listingStandard.GapLine();

			if (listingStandard.ButtonTextLabeled("Reset to Default", "Reset"))
			{
				_settings.workAmountMultiplier = 1f;
				_settings.bulkWorkAmountMultiplier = 0.8f;
				_settings.skillLearnFactor = 0.25f;
				_settings.usedSkill = Skill.Crafting;
			}

			listingStandard.End();

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
