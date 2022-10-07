using Verse;

namespace StonecuttingExtended
{
	public class StonecuttingExtendedSettings : ModSettings
	{
		public const float DEFAULT_WORK_AMOUNT = 1600;

		public float workAmountMultiplier = 1f;

		public float bulkWorkAmountMultiplier = 0.8f;

		public float skillLearnFactor = 0.25f;

		public Skill usedSkill = Skill.Crafting;

		public override void ExposeData()
		{
			Scribe_Values.Look(ref workAmountMultiplier, "WorkAmountMultiplier", 1f);
			Scribe_Values.Look(ref bulkWorkAmountMultiplier, "BulkWorkAmountMultiplier", 0.8f);
			Scribe_Values.Look(ref skillLearnFactor, "SkillLearnFactor", 0.25f);

			Scribe_Values.Look<Skill>(ref usedSkill, "UsedSkill", 0);

			base.ExposeData();
		}

		public float GetWorkAmount()
		{
			return DEFAULT_WORK_AMOUNT * workAmountMultiplier;
		}

		public float GetBulkWorkAmount()
		{
			return DEFAULT_WORK_AMOUNT * 3 * bulkWorkAmountMultiplier;
		}
	}
}
