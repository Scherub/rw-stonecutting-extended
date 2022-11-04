using System.Linq;
using RimWorld;
using Verse;

namespace StonecuttingExtended
{
	public static class StonecuttingExtendedDefsUpdater
	{
		public static void UpdateDefs()
		{
			StonecuttingExtendedSettings settings = LoadedModManager.GetMod<StonecuttingExtendedMod>().GetSettings<StonecuttingExtendedSettings>();

			UpdateStonecuttingSpeedStat(settings);
			UpdateStonecuttingRecipes(settings);
		}

		private static void UpdateStonecuttingSpeedStat(StonecuttingExtendedSettings settings)
		{
			Skill usedSkill = settings.usedSkill;

			StatDef stonecuttingSpeedStatDef = DefDatabase<StatDef>.GetNamed("StonecuttingSpeed");

			if (stonecuttingSpeedStatDef == null)
			{
				Log.Warning("StonecuttingSpeed not found.");
				return;
			}

			foreach (SkillNeed skillNeed in stonecuttingSpeedStatDef.skillNeedFactors)
			{
				skillNeed.skill = GetSkillDef(usedSkill);
			}
		}

		private static void UpdateStonecuttingRecipes(StonecuttingExtendedSettings settings)
		{
			float workAmount = settings.GetWorkAmount();
			float bulkWorkAmount = settings.GetBulkWorkAmount();
			SkillDef skillDef = GetSkillDef(settings.usedSkill);
			float skillLearnFactor = settings.skillLearnFactor;

			foreach (var recipeDef in DefDatabase<RecipeDef>.AllDefs.Where(rd => rd.defName.StartsWith("Make_StoneBlocks")))
			{
				recipeDef.workAmount = (recipeDef.defName.Contains("Bulk")) ? bulkWorkAmount : workAmount;
				recipeDef.workSkill = skillDef;
				recipeDef.workSkillLearnFactor = skillLearnFactor;
			}
		}

		private static SkillDef GetSkillDef(Skill skill)
		{
			if (skill == Skill.Art)
				return DefDatabase<SkillDef>.GetNamed("Artistic");
			else
				return DefDatabase<SkillDef>.GetNamed("Crafting");
		}
	}
}
