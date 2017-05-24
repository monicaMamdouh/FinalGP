using System;
using System.Collections.Generic;
using System.Linq;


namespace UserInterestClassification
{
    class stemmingFunction
    {
        public string stemFunction(String cleanedTweet)
        {

            //stemming
            List<string> stringList = cleanedTweet.Split(' ').ToList();
            List<string> stemList = new List<string>();

            string monica = null;
            for (int i = 0; i < stringList.Count(); i++)
            {
                Stemmer stem = new Stemmer();
                var actual = stem.Stem(stringList[i]).Value;
                stemList.Add(actual);
            }
            return monica = string.Join(" ", stemList.ToArray());

            
        }

    }
}
