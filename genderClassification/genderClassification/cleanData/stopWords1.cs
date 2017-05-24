using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace genderClassification
{
    class stopWords1
    {
        public string stopWordFunction1(string tweetText)
        {
            string text = tweetText;
            string[] words = text.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] == "and")
                {

                    words[i] = words[i].Remove(0);
                }
                if (words[i] == "the")
                {

                    words[i] = words[i].Remove(0);
                }
                if (words[i] == "of")
                {

                    words[i] = words[i].Remove(0);
                }
                if (words[i] == "which")
                {

                    words[i] = words[i].Remove(0);
                }
                if (words[i] == "in")
                {

                    words[i] = words[i].Remove(0);
                }
                if (words[i] == "want")
                {

                    words[i] = words[i].Remove(0);
                }
                if (words[i] == "this")
                {
                    words[i] = words[i].Remove(0);
                }
                if (words[i] == "to")
                {
                    words[i] = words[i].Remove(0);
                }
                if (words[i] == "on")
                {
                    words[i] = words[i].Remove(0);
                }
                if (words[i] == "always")
                {
                    words[i] = words[i].Remove(0);
                }
                if (words[i] == "then")
                {
                    words[i] = words[i].Remove(0);
                }
                if (words[i] == "that")
                {
                    words[i] = words[i].Remove(0);
                }
                if (words[i] == "these")
                {
                    words[i] = words[i].Remove(0);
                }
                if (words[i] == "be")
                {
                    words[i] = words[i].Remove(0);
                }
                if (words[i] == "very")
                {
                    words[i] = words[i].Remove(0);
                }
                if (words[i] == "so")
                {
                    words[i] = words[i].Remove(0);
                }
                if (words[i] == "all")
                {
                    words[i] = words[i].Remove(0);
                }
                if (words[i] == "those")
                {
                    words[i] = words[i].Remove(0);
                }
                if (words[i] == "has")
                {

                    words[i] = words[i].Remove(0);
                }
                if (words[i] == "have")
                {

                    words[i] = words[i].Remove(0);
                }
                if (words[i] == "from")
                {
                    words[i] = words[i].Remove(0);
                }
                if (words[i] == "for")
                {
                    words[i] = words[i].Remove(0);
                }
                if (words[i].Length == 1 || words[i].Length == 2)
                {

                    words[i] = words[i].Remove(0);
                }

            }
            string tweet = String.Join(" ", words);
            tweet = tweet.Replace("  ", " ");
            tweet = tweet.Replace("  ", " ");
            tweet = tweet.Replace("  ", " ");
            tweet = tweet.Trim();
            return tweet;
        }
    }
}
