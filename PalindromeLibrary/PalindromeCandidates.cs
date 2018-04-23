using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalindromeLibrary
{
    public class Candidate
    {
        public string entry;
        private string strippedEntry;
        public bool status {get;}

        public Candidate(string input)
        {
            entry = input;
            stripEntry();
            status = palindromeChecker();
        }
        private bool palindromeChecker()
        {
            int min = 0;
            int max = strippedEntry.Length - 1;
            while (true)
            {
                if (min > max)
                {
                    return true;
                }
                char a = strippedEntry[min];
                char b = strippedEntry[max];
                if (char.ToLower(a) != char.ToLower(b))
                {
                    return false;
                }
                min++;
                max--;
            }
        }
        private void stripEntry()
        {
            var sb = new StringBuilder();
            foreach (char c in entry)
            {
                if (!char.IsPunctuation(c))
                {
                    if (c != ' ')
                    {
                        sb.Append(c);
                    }
                }
            }
            strippedEntry = sb.ToString();
        }
    }
}
