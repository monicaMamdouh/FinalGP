using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopPosts
{
    class Normalization
    {
        string Text;
        public string normal(string tweet)
        {
            string text = tweet;
            string[] words = text.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] == "rt")
                {

                    words[i] = words[i].Remove(0);
                }
                if (words[i].IndexOf("?") != -1)
                {

                    words[i] = words[i].Remove(0);
                }
                if (words[i] == "ps")
                {

                    words[i] = words[i].Remove(0);
                }

                if (words[i].IndexOf("@") != -1)
                {
                    words[i] = words[i].Remove(0);
                }
                if (words[i].IndexOf("http") != -1)
                {
                    words[i] = words[i].Remove(0);
                }
                if (words[i].IndexOf("https") != -1)
                {
                    words[i] = words[i].Remove(0);
                }
                if (words[i].IndexOf("/") != -1)
                {
                    words[i] = words[i].Remove(0);
                }


                Text = String.Join(" ", words).Replace("  ", " ");
                Text = Text.ToString().Replace("  ", " ");
                Text = Text.ToString().Replace("  ", " ");
                Text = Text.Trim();
            }
            return Text;
        }

    }
}