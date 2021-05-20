using System.Text.RegularExpressions;

namespace TCC
{
    internal class regex : Regex
    {
        public regex(string pattern) : base(pattern)
        {
        }
    }
}