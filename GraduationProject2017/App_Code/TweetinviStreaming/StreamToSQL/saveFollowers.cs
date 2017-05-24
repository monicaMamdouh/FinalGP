using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for saveFollowers
/// </summary>
public class saveFollowers
{
    public void save()
    {
        List<Followers> followerList = new List<Followers>();
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-FQEB1DN;Initial Catalog=TwitterTest ;Integrated Security=True");
        con.Open();

        followerList = UserStream.GetUsersFollowes("@imWilISmith");

        for (int i = 0; i < 5000; i++)
        {

            SqlCommand c = new SqlCommand("INSERT INTO FollowerTable(UserId,UserName,followers_count,friends_count,description,favourites_count,language,country,screenName,post_count,image) VALUES(@a,@b,@c,@d,@e,@f,@g,@h,@i,@j,@k)", con);
            c.Parameters.AddWithValue("@a", followerList[i].UserID);
            c.Parameters.AddWithValue("@b", followerList[i].UserName);
            c.Parameters.AddWithValue("@c", followerList[i].followers_count);
            c.Parameters.AddWithValue("@d", followerList[i].friends_count);
            c.Parameters.AddWithValue("@e", followerList[i].description);
            c.Parameters.AddWithValue("@f", followerList[i].favourites_count);
            c.Parameters.AddWithValue("@g", followerList[i].language);
            c.Parameters.AddWithValue("@h", followerList[i].country);
            c.Parameters.AddWithValue("@i", followerList[i].screenName);
            c.Parameters.AddWithValue("@j", followerList[i].post_count);
            c.Parameters.AddWithValue("@k", followerList[i].image);



            c.ExecuteNonQuery();


        }
    }
}