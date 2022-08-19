#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs.Language
//    Project: FoCs.Language
//       File: TokenizerBuilderExtensions.cs
//    Created: 2022/08/19
// LastEdited: 2022/08/19
#endregion

using Superpower.Parsers;
using Superpower.Tokenizers;

namespace FoCs.Language.Extensions {
	public static class TokenizerBuilderExtensions {
		public static TokenizerBuilder<U> MatchSimple<U>(this TokenizerBuilder<U> tokenizer, U token) {
			return tokenizer.Match(Span.EqualToIgnoreCase(token.ToString()), token);
		}
	}
}