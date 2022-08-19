#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs.Language
//    Project: FoCs.Language
//       File: TextParsers.cs
//    Created: 2022/08/19
// LastEdited: 2022/08/19
#endregion

using System;
using Superpower;
using Superpower.Model;
using Superpower.Parsers;

namespace FoCs.Language.Parsers {
	public class TextParsers {
		public static TextParser<TimeSpan> Magnitude { get; } =
			Character.EqualTo('d').Value(TimeSpan.FromDays(1))
					 .Or(Character.EqualTo('h').Value(TimeSpan.FromHours(1)))
					 .Or(Span.EqualTo("ms").Try().Value(TimeSpan.FromMilliseconds(1)))
					 .Or(Character.EqualTo('m').Value(TimeSpan.FromMinutes(1)))
					 .Or(Character.EqualTo('s').Value(TimeSpan.FromSeconds(1)));

		public static TextParser<TimeSpan> Duration { get; } =
			Numerics.DecimalDouble.Then(d => Magnitude.Select(m => m * d));

		public static TextParser<TextSpan> ManyRawText { get; } = Span.MatchedBy(Character.LetterOrDigit.Try().Many());
	}
}