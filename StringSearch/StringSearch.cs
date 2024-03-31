using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringSearch
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class StringSearch
    {
        static int HashString(string str)
        {
            int hash = 0;
            foreach (char c in str)
            {
                hash = hash * 256 + c;
            }
            return hash;
        }


        static int RabinKarpSearch(string text, string pattern)
        {
            int n = text.Length;
            int m = pattern.Length;

            int patternHash = HashString(pattern);
            int textHash = HashString(text.Substring(0, m));

            for (int i = 0; i <= n - m; i++)
            {
                if (patternHash == textHash && text.Substring(i, m) == pattern)
                    return i;

                if (i < n - m)
                {
                    textHash = textHash - text[i] * (int)Math.Pow(256, m - 1);
                    textHash = textHash * 256 + text[i + m];
                }
            }

            return -1;
        }
    }
}
