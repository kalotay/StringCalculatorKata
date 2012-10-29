﻿namespace StringCalculator.Lexer
{
    public struct StringCalculatorToken
    {
        public enum Types
        {
            DelimitersStart,
            DelimitersEnd,
            Delimiter,
            MultiCharacterDelimterStart,
            MultiCharacterDelimiterEnd,
            Numbers
        }

        public readonly Types Type;
        public readonly string Content;

        public static readonly StringCalculatorToken DelimitersStart =
            new StringCalculatorToken(Types.DelimitersStart, "//");

        public static readonly StringCalculatorToken DelimitersEnd =
            new StringCalculatorToken(Types.DelimitersEnd, "\n");

        public static readonly StringCalculatorToken MultiCharacterDelimiterStart =
            new StringCalculatorToken(Types.MultiCharacterDelimterStart, "[");

        public static readonly StringCalculatorToken MultiCharacterDelimiterEnd =
            new StringCalculatorToken(Types.MultiCharacterDelimiterEnd, "]");

        public static StringCalculatorToken DelimiterToken(string content)
        {
            return new StringCalculatorToken(Types.Delimiter, content);
        }

        public static StringCalculatorToken NumbersToken(string content)
        {
            return new StringCalculatorToken(Types.Numbers, content);
        }

        private StringCalculatorToken(Types type, string content)
        {
            Type = type;
            Content = content;
        }
    }
}
