using System;
using UnityEngine;
using Verse;

namespace StonecuttingExtended.Settings
{
	public static class StonecuttingDisplaySettings
	{
		public static void DisplaySettings(StonecuttingSettings settings, Rect inRect)
		{
			Listing_Standard listingStandard = new();

			listingStandard.Begin(inRect);

			listingStandard.GapLine();

			listingStandard.Label("SCE_UsedSkill_Label".Translate(), -1f, "SCE_UsedSkill_Description".Translate());
			listingStandard.Gap();

			if (listingStandard.RadioButton("WorkTagCrafting".Translate(), settings.usedSkill == Skill.Crafting))
				settings.usedSkill = Skill.Crafting;
			if (listingStandard.RadioButton("WorkTagArtistic".Translate(), settings.usedSkill == Skill.Art))
				settings.usedSkill = Skill.Art;

			listingStandard.GapLine();

			listingStandard.Label("SCE_WorkAmountMultiplier".Translate() + " (0.1 - 1.5): " + settings.workAmountMultiplier);
			settings.workAmountMultiplier = (float)Math.Round(listingStandard.Slider(settings.workAmountMultiplier, 0.1f, 1.5f), 2);

			listingStandard.Label("SCE_BulkWorkAmountMultiplier".Translate() + " (0.1 - 1.5): " + settings.bulkWorkAmountMultiplier);
			settings.bulkWorkAmountMultiplier = (float)Math.Round(listingStandard.Slider(settings.bulkWorkAmountMultiplier, 0.1f, 1.5f), 2);

			listingStandard.Label("SCE_SkillLearnFactor".Translate() + " (0.1 - 2.0): " + settings.skillLearnFactor);
			settings.skillLearnFactor = (float)Math.Round(listingStandard.Slider(settings.skillLearnFactor, 0.1f, 2f), 2);

			listingStandard.GapLine();

			if (listingStandard.ButtonTextLabeled("RestoreToDefaultSettings".Translate(), "ResetButton".Translate()))
				settings.Reset();

			listingStandard.End();
		}
	}
}
