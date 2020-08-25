using System;
using System.Text.RegularExpressions;

namespace RichUnity.StringUtils
{
    public static class StringExtensions
    {
        public static bool OrdinalEquals(this string a, string b)
        {
            if (a == null || b == null)
            {
                return false;
            }
            
            return a.Equals(b, StringComparison.Ordinal);
        }
        
        public static bool CustomStartsWith(this string a, string b)
        {
            int aLen = a.Length;
            int bLen = b.Length;
    
            int ap = 0; int bp = 0;
    
            while (ap < aLen && bp < bLen && a [ap] == b [bp])
            {
                ap++;
                bp++;
            }
    
            return (bp == bLen);
        }
        
        public static bool CustomEndsWith(this string a, string b)
        {
            int ap = a.Length - 1;
            int bp = b.Length - 1;
    
            while (ap >= 0 && bp >= 0 && a [ap] == b [bp])
            {
                ap--;
                bp--;
            }
    
            return (bp < 0);
        }
        
        public static bool CompareBy(this string a, string b, StringComparisonWays stringComparisonWay)
        {
            switch (stringComparisonWay)
            {
                case StringComparisonWays.Equals:
                    return a.OrdinalEquals(b);
                case StringComparisonWays.StartsWith:
                    return a.CustomStartsWith(b);
                case StringComparisonWays.EndsWith:
                    return a.CustomEndsWith(b);
                case StringComparisonWays.Regex:
                    return Regex.IsMatch(a, b);
            }
            return false;
        }
    }
}