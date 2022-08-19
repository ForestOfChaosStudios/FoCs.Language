using FoCs.Language.Enum;
using FoCs.Language.Extensions;
using FoCs.Language.Parsers;
using Superpower;
using Superpower.Model;
using Superpower.Parsers;
using Superpower.Tokenizers;

namespace FoCs.Language {
	public class ExpressionTokenizer {
		public static TextParser<TextSpan> Duration { get; } =
			Numerics.Decimal
					.Then(_ => Span.WithAll(char.IsLetter));

		static Tokenizer<ExpressionToken> Tokenizer { get; } = new TokenizerBuilder<ExpressionToken>()
															   .Ignore(Comment.CStyle)
															   .MatchSimple(ExpressionToken.Select)
															   .MatchSimple(ExpressionToken.Where)
															   .MatchSimple(ExpressionToken.And)
															   .MatchSimple(ExpressionToken.Now)
															   .MatchSimple(ExpressionToken.Today)
															   .MatchSimple(ExpressionToken.Tomorrow)
															   .MatchSimple(ExpressionToken.Yesterday)
															   .Match(DateTimeTextParser.DateTime, ExpressionToken.DateTime)
															   .Match(DateTimeTextParser.Date, ExpressionToken.Date)
															   .Match(DateTimeTextParser.Time, ExpressionToken.Time)
															   .Match(Character.EqualTo('+'), ExpressionToken.Plus)
															   .Match(Character.EqualTo('-'), ExpressionToken.Minus)
															   .Match(Character.EqualTo('*'), ExpressionToken.Asterisk)
															   .Match(Character.EqualTo('/'), ExpressionToken.Slash)
															   .Match(Duration, ExpressionToken.Duration, requireDelimiters: true)
															   .Match(Numerics.Decimal, ExpressionToken.Number, requireDelimiters: true)
															   .Match(Character.EqualTo('('), ExpressionToken.LeftParentheses)
															   .Match(Character.EqualTo(')'), ExpressionToken.RightParentheses)
															   .Ignore(Span.WhiteSpace)
															   .Match(TextParsers.ManyRawText, ExpressionToken.ColumnName)
															   .Build();

		public static Result<TokenList<ExpressionToken>> TryTokenize(string source) {
			return Tokenizer.TryTokenize(source);
		}
	}
}
