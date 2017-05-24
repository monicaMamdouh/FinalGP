using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for saveTweets
/// </summary>
public class saveTweets
{
    public void save()
    {
        TweetsStream.SetCredentials();
        List<Tweets> tweetList = new List<Tweets>();
        tweetList=TweetsStream.GetTweetsWithKeyword();
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-FQEB1DN;Initial Catalog=TwitterTest ;Integrated Security=True");
        con.Open();
        for (int i = 0; i < 3000; i++)
        {

            SqlCommand c = new SqlCommand("INSERT INTO TweetTable(Retweets,Favourites,UserName,ScreenName,Text,TweetID) VALUES(@a,@b,@c,@d,@e,@f)", con);
            c.Parameters.AddWithValue("@a", tweetList[i].Retweets);
            c.Parameters.AddWithValue("@b", tweetList[i].Favourites);
            c.Parameters.AddWithValue("@c", tweetList[i].UserName);
            c.Parameters.AddWithValue("@d", tweetList[i].ScreenName);
            c.Parameters.AddWithValue("@e", tweetList[i].Text);
            c.Parameters.AddWithValue("@f", tweetList[i].TweetID);

            c.ExecuteNonQuery();


        }


    }
}