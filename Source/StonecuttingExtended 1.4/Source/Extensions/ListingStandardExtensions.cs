using System;
using Verse;

namespace StonecuttingExtended
{
	internal static class ListingStandardExtensions
	{
		public static void BeginSubSection(this Listing_Standard listingStandard, float gapWidth = 12f)
		{
			listingStandard.Indent(gapWidth);
			listingStandard.ColumnWidth -= gapWidth;
		}

		public static void EndSubSection(this Listing_Standard listingStandard, float gapWidth = 12f)
		{
			listingStandard.Outdent(gapWidth);
			listingStandard.ColumnWidth += gapWidth;
		}

		public static void Heading(this Listing_Standard listingStandard, string label, string? tooltip = null)
		{
			GameFont oldFont = Text.Font;
			Text.Font = GameFont.Medium;

#if RIMWORLD_1_6
			listingStandard.Label(new(label), -1f, tooltip);
#else
			listingStandard.Label(label, -1f, tooltip);
#endif
			listingStandard.Gap();

			Text.Font = oldFont;
		}

		public static bool RadioButtonLabel(this Listing_Standard listingStandard, string label, bool isActive)
		{
			bool result = listingStandard.RadioButton(label, isActive);

			listingStandard.Gap(4f);

			return result;
		}

		public static float SliderLabel(this Listing_Standard listingStandard, float value, float min, float max, Func<string> label)
		{
			GameFont oldFont = Text.Font;
			//Text.Font = GameFont.Tiny;

			if (label != null)
				listingStandard.Label(label());

			value = listingStandard.Slider(value, min, max);
			value = (float)Math.Round(value, 2);

			Text.Font = oldFont;

			return value;
		}
	}
}
