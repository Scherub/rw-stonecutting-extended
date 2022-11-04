﻿using UnityEngine;
using Verse;

namespace StonecuttingExtended
{
	public static class StonecuttingExtendedDisplaySettings
	{
		public static void DisplaySettings(StonecuttingExtendedSettings settings, Rect inRect)
		{
			float margin = 16f;
			float columnWidth = inRect.width / 2f;
			float usableColumnWidth = columnWidth - margin * 2f;

			DisplaySkillSelection(settings, new Rect(inRect.x + margin, inRect.y, usableColumnWidth, inRect.height));

			DisplayRightPane(settings, new Rect(inRect.x + columnWidth + margin, inRect.y, usableColumnWidth, inRect.height));
		}

		static void DisplaySkillSelection(StonecuttingExtendedSettings settings, Rect inRect)
		{
			Listing_Standard listingStandard = new();

			listingStandard.Begin(inRect);

			listingStandard.Heading("SCE_UsedSkill_Label".Translate(), "SCE_UsedSkill_Description".Translate());

			listingStandard.BeginSubSection();

			if (listingStandard.RadioButtonLabel("WorkTagCrafting".Translate(), settings.usedSkill == Skill.Crafting))
				settings.usedSkill = Skill.Crafting;

			if (listingStandard.RadioButtonLabel("WorkTagArtistic".Translate(), settings.usedSkill == Skill.Art))
				settings.usedSkill = Skill.Art;

			listingStandard.EndSubSection();

			listingStandard.Gap(24f);

			listingStandard.Heading("ResetButton".Translate());

			listingStandard.BeginSubSection();

			if (listingStandard.ButtonTextLabeled("RestoreToDefaultSettings".Translate(), "ResetButton".Translate()))
				settings.Reset();

			listingStandard.EndSubSection();

			listingStandard.End();
		}

		static void DisplayRightPane(StonecuttingExtendedSettings settings, Rect inRect)
		{
			Listing_Standard listingStandard = new();

			listingStandard.Begin(inRect);

			listingStandard.Heading("SCE_WorkingAndLearningSpeed_Label".Translate(), "SCE_WorkingAndLearningSpeed_Description".Translate());

			listingStandard.BeginSubSection();

			settings.workAmountMultiplier = listingStandard.SliderLabel(settings.workAmountMultiplier, 0.1f, 1.5f, () => "SCE_WorkAmountMultiplier".Translate() + " (0.1 - 1.5): " + settings.workAmountMultiplier);
			settings.bulkWorkAmountMultiplier = listingStandard.SliderLabel(settings.bulkWorkAmountMultiplier, 0.1f, 1.5f, () => "SCE_BulkWorkAmountMultiplier".Translate() + " (0.1 - 1.5): " + settings.bulkWorkAmountMultiplier);
			settings.skillLearnFactor = listingStandard.SliderLabel(settings.skillLearnFactor, 0.1f, 2f, () => "SCE_SkillLearnFactor".Translate() + " (0.1 - 1.5): " + settings.skillLearnFactor);

			listingStandard.EndSubSection();

			listingStandard.End();
		}
	}
}
