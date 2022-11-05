using System.Linq;
using RimWorld;
using StonecuttingExtended.Settings;
using Verse;

namespace StonecuttingExtended.Defs
{
	public static class DefsUpdater
	{
		public static void UpdateDefs()
		{
			StonecuttingSettings settings = LoadedModManager.GetMod<StonecuttingMod>().GetSettings<StonecuttingSettings>();

			UpdateStonecuttingSpeedStat(settings);
			UpdateStonecuttingRecipes(settings);
		}

		private static void UpdateStonecuttingSpeedStat(StonecuttingSettings settings)
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

		private static void UpdateStonecuttingRecipes(StonecuttingSettings settings)
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
				return SkillDefOf.Artistic;
			else if (skill == Skill.Construction)
				return SkillDefOf.Construction;
			else
				return SkillDefOf.Crafting;
		}
	}
}
