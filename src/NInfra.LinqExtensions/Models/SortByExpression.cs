using System;
using System.Text.RegularExpressions;

namespace NInfra.LinqExtensions.Models
{
    public class SortByExpression
    {
        private static readonly Regex SortExpressionRegex =
            new Regex(@"\[(?<left>\S+?) (?<op>None|Asc|Desc)\]", RegexOptions.Compiled);

        public SortByExpression(string expression)
        {
            if (SortExpressionRegex.IsMatch(expression))
            {
                var match = SortExpressionRegex.Match(expression);
                Left = match.Groups["left"].Value;
                var op = match.Groups["op"].Value;
                Op = Enum.Parse<SortOperator>(op);
            }
            else
            {
                throw new NotSupportedException();
            }
        }

        public SortByExpression(string left, SortOperator op)
        {
            Left = left;
            Op = op;
        }

        public static implicit operator SortByExpression(string expression) => new SortByExpression(expression);

        public static implicit operator string(SortByExpression expression) => expression.ToString();

        public override string ToString() => $"[{Left} {Op}]";

        public string Left { get; set; }

        public SortOperator Op { get; set; }
    }

    public enum SortOperator
    {
        None,
        Asc,
        Desc
    }
}
