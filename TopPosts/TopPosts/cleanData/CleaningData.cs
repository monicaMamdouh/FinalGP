using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopPosts
{
    class CleaningData
    {
        public string cleanEachTweet(String TweetText)
        {
            Tokenizer token = new Tokenizer();
            String afterToken = token.token(TweetText);

            Normalization norm = new Normalization();
            String afterNormal = norm.normal(afterToken);

            stopWords1 stop1 = new stopWords1();
            String afterStop1 = stop1.stopWordFunction1(afterNormal);

            stopWords2 stop2 = new stopWords2();
            String afterStop2 = stop2.stopWordFunction2(afterStop1);

            return afterStop2;





        }
    }
}
