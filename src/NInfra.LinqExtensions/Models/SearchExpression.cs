using System;
using System.Text.RegularExpressions;

namespace NInfra.LinqExtensions.Models
{
    public class SearchExpression
    {
        private static readonly Regex SearchExpressionRegex =
            new Regex(@"\[(?<left>\S+?) (?<op>Equal|NotEqual|Like|IsNull|NotNull) (?<right>\S+?)\]", RegexOptions.Compiled);

        public SearchExpression(string expression)
        {
            if (SearchExpressionRegex.IsMatch(expression))
            {
                var match = SearchExpressionRegex.Match(expression);
                Left = match.Groups["left"].Value;
                var op = match.Groups["op"].Value;
                Op = Enum.Parse<SearchOperator>(op);
                Right = match.Groups["right"].Value;
            }
            else
            {
                throw new NotSupportedException();
            }
        }

        public SearchExpression(string left, SearchOperator op, string right)
        {
            Left = left;
            Op = op;
            Right = right;
        }

        public static implicit operator SearchExpression(string expression) => new SearchExpression(expression);

        public static implicit operator string(SearchExpression expression) => expression.ToString();

        public override string ToString() => $"[{Left} {Op} {Right}]";

        public string Left { get; set; }

        public SearchOperator Op { get; set; }

        public string Right { get; set; }
    }

    public enum SearchOperator
    {
        Equal,
        NotEqual,
        Like,
        IsNull,
        NotNull
    }
}
