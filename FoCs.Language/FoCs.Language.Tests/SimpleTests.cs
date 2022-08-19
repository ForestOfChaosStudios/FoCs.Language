using System;
using Superpower;
using Superpower.Model;
using Xunit;
using Xunit.Abstractions;

namespace FoCs.Language.Tests {
    public class SimpleTests {
        private readonly ITestOutputHelper Output;

        public SimpleTests(ITestOutputHelper output) {
            this.Output = output;
        }

        [Theory]
        [InlineData("Select")]
        [InlineData("SELECT")]
        [InlineData("select")]
        [InlineData("where")]
        [InlineData("Where")]
        [InlineData("WHERE")]
        [InlineData("where ThisColumn")]
        [InlineData("Where ThisColumn")]
        [InlineData("WHERE ThisColumn")]
        [InlineData("where ThisColumn Help")]
        [InlineData("Where ThisColumn Help Me")]
        [InlineData("WHERE ThisColumn Help AnotherColumn Does")]
        [InlineData("WHERE ThisColumn 2022-02-10")]
        [InlineData("WHERE ThisColumn 2022-02-10T12:23")]
        [InlineData("WHERE ThisColumn 2022-02-10 12:23")]
        [InlineData("WHERE ThisColumn 12:23")]
        [InlineData("WHERE ThisColumn ;")]
        public void Test1(string input) {
            TestParse(input);
        }

        private void TestParse(string input) {
            try {
                var tokens = ExpressionTokenizer.TryTokenize(input);

                if (!tokens.HasValue) {
                    Output.WriteLine(input);
                    WriteSyntaxError(tokens.ToString(), tokens.ErrorPosition);

                    throw new Exception("Token Parse Error");
                }

                Output.WriteLine($"{Pad("Kind")}Data");

                foreach (var token in tokens.Value) {
                    Output.WriteLine($"{Pad(token.Kind)}{token.Span.ToStringValue()}");
                }
            }
            catch (ParseException pe) {
                Output.WriteLine(input);
                WriteSyntaxError(pe.Message, pe.ErrorPosition);

                throw;
            }
        }

        private void WriteSyntaxError(string message, Position errorPosition) {
            if (errorPosition.HasValue && errorPosition.Line == 1)
                Output.WriteLine(new string(' ', errorPosition.Column - 1) + '^');
            Output.WriteLine(message);
        }

        private string Pad<T>(T obj, int padding = 25) {
            return obj.ToString().PadRight(25);
        }
    }
}
