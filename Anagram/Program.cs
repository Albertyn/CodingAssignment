using System;

namespace Anagram
{
    /* 
Two words are anagrams of one another if their letters can be rearranged to form the other word.
In this challenge, you will be given a string. You must split it into two contiguous substrings, 
then determine the minimum number of characters to change to make the two substrings into anagrams of one another.

For example, given the string 'abccde', you would break it into two parts: 'abc' and 'cde'. 
Note that all letters have been used, the substrings are contiguous and their lengths are equal. 
Now you can change 'a' and 'b' in the first substring to 'd' and 'e' to have 'dec' and 'cde' which are anagrams. 
Two changes were necessary.

     Input Format
        The first line will contain an integer, q, the number of test cases. 
        Each test case will contain a string n which will be concatenation of 
        both the strings described above in the problem. 
        The given string will contain only characters in the range ascii[a-z].

     Constraints
        1 <= q <= 100
        1 <= s <= 100000
        s consists only of characters in the range ascii[a-z].
Input
    6
    aaabbb
    ab
    abc
    mnop
    xyyx
    xaxbbbxx


     Output Format
        For each test case, print an integer 
        representing the minimum number of changes 
        required to make an anagram. 
        Print -1 if it is not possible.
Output
    3
    1
    -1
    2
    0
    1

    */
    class Solution
    {

        // Complete the anagram function below.
        static int anagram(string s)
        {
            if (s.Length % 2 > 0) return -1; // Odd

            string a = s.Substring(0, s.Length / 2);
            string b = s.Substring(s.Length / 2);

            // take every char you find in b and remove 1 match from a
            foreach (char c in b)
            {
                if (a.IndexOf(c) > -1)
                    a = a.Remove(a.IndexOf(c), 1);
            }

            return a.Length;
        }

        static void Main(string[] args)
        {
            int q = Convert.ToInt32(Console.ReadLine());

            for (int qItr = 0; qItr < q; qItr++)
            {
                string s = Console.ReadLine();

                int result = anagram(s);

                Console.WriteLine(result);
            }


            // Keep the console window open
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}

