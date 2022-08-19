#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs.Language
//    Project: FoCs.Language
//       File: DateTimeTextParser.cs
//    Created: 2022/08/19
// LastEdited: 2022/08/19
#endregion

using System;
using Superpower;
using Superpower.Parsers;

namespace FoCs.Language.Parsers {
	//https://github.com/datalust/superpower/blob/dev/sample/DateTimeTextParser/DateTimeTextParser.cs
	public static class DateTimeTextParser {
		static TextParser<int> IntDigits(int count) =>
				Character.Digit
						 .Repeat(count)
						 .Select(chars => int.Parse(new string(chars)));

		static TextParser<int> TwoDigits { get; } = IntDigits(2);
		static TextParser<int> FourDigits { get; } = IntDigits(4);

		static TextParser<char> Dash { get; } = Character.EqualTo('-');
		static TextParser<char> Colon { get; } = Character.EqualTo(':');
		static TextParser<char> TimeSeparator { get; } = Character.In('T', ' ');

		public static TextParser<DateTime> Date { get; } =
			from year in FourDigits
			from _ in Dash
			from month in TwoDigits
			from __ in Dash
			from day in TwoDigits
			select new DateTime(year, month, day);

		public static TextParser<TimeSpan> Time { get; } =
			from hour in TwoDigits
			from _ in Colon
			from minute in TwoDigits
			from second in Colon
						   .IgnoreThen(TwoDigits)
						   .OptionalOrDefault()
			select new TimeSpan(hour, minute, second);

		public static TextParser<DateTime> DateTime { get; } =
			from date in Date
			from time in TimeSeparator
						 .IgnoreThen(Time)
						 .OptionalOrDefault()
			select date + time;

		static TextParser<DateTime> DateTimeOnly { get; } = DateTime.AtEnd();

		public static DateTime Parse(string input) {
			return DateTimeOnly.Parse(input);
		}
	}
}