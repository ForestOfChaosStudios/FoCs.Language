#region © Forest Of Chaos Studios 2019 - 2022
//   Solution: FoCs.Language
//    Project: FoCs.Language
//       File: ExpressionToken.cs
//    Created: 2022/08/19
// LastEdited: 2022/08/19
#endregion

using Superpower.Display;

namespace FoCs.Language.Enum {
    public enum ExpressionToken {
        [Token(Category = "Literal", Example = "42")]
        Number,
        [Token(Category = "Literal", Example = "2d")]
        Duration,

        [Token(Category = "Literal", Example = "'2022-01-02'd")]
        Date,
        [Token(Category = "Literal", Example = "'12:34't")]
        Time,
        [Token(Category = "Literal", Example = "'2022-01-02 12:34'dt")]
        DateTime,

        [Token(Category = "Literal Alias", Example = "now", Description = "The current Date and Time eg. DateTime.Now")]
        Now,
        [Token(Category = "Literal Alias", Example = "today", Description = "The current Date")]
        Today,
        [Token(Category = "Literal Alias", Example = "yesterday", Description = "24 hours ago")]
        Yesterday,
        [Token(Category = "Literal Alias", Example = "tomorrow", Description = "24 hours in the future")]
        Tomorrow,

        [Token(Category = "Arithmetic Operator", Example = "+")]
        Plus,
        [Token(Category = "Arithmetic Operator", Example = "-")]
        Minus,
        [Token(Category = "Arithmetic Operator", Example = "*")]
        Asterisk,
        [Token(Category = "Arithmetic Operator", Example = "/")]
        Slash,

        [Token(Example = "(")]
        LeftParentheses,
        [Token(Example = ")")]
        RightParentheses,

        [Token(Example = "[")]
        LeftBracket,
        [Token(Example = "]")]
        RightBracket,

        [Token(Example = "{")]
        LeftBraces,
        [Token(Example = "}")]
        RightBraces,

        [Token(Category = "Seperator", Example = ",")]
        Comma,

        [Token(Category = "Logical Operator", Example = "=")]
        Equal,
        [Token(Category = "Logical Operator", Example = "!=")]
        NotEqual,
        [Token(Category = "Logical Operator", Example = ">")]
        GraterThan,
        [Token(Category = "Logical Operator", Example = ">=")]
        GreaterThanOrEqual,
        [Token(Category = "Logical Operator", Example = "<")]
        LessThan,
        [Token(Category = "Logical Operator", Example = "<=")]
        LessThanOrEqual,

        [Token(Category = "Statement Keyword", Example = "Where")]
        Where,
        [Token(Category = "Statement Keyword", Example = "Select")]
        Select,

        [Token(Category = "Keyword", Example = "And")]
        And,
        [Token(Category = "Keyword", Example = "Or")]
        Or,

        [Token(Category = "ColumnName")]
        ColumnName,

    }
}