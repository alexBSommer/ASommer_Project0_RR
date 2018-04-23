using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PalindromeLibrary;

namespace Palindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Enter a String to check for palindromes");
            Candidate userEntry = new Candidate(Console.ReadLine());
            if (userEntry.status)
            {
                Console.WriteLine(userEntry.entry + " is a Palindrome!");
            }
            else
            {
                Console.WriteLine(userEntry.entry + " is not a Palindrome.");
            }
            Console.Read();
        }
    }
}
