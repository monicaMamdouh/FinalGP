using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInterestClassification
{
    class stopWords2
    {
        public string stopWordFunction2(string tweetText)
        {
            string[] stopWords = File.ReadAllLines(@"C:\Users\monica\Desktop\مشروع التخرج\stopWords.txt");

            List<String> stringList = new List<string>();
            stringList = tweetText.Split(' ').ToList();
            string monica = null;
            for (int i = 0; i < stringList.Count(); i++)
            {
                foreach (string stop in stopWords)
                {
                    if (stringList[i].ToLower().Equals(stop))
                    {
                        stringList[i] = stringList[i].Replace(stringList[i], "");

                    }

                }
                monica = String.Join(" ", stringList).Replace("  ", " ");
                monica = monica.ToString().Replace("  ", " ");
                monica = monica.ToString().Replace("  ", " ");
                monica = monica.Trim();
            }
            return monica;

        }
    }
}
