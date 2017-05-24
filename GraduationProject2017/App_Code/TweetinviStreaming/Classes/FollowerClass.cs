using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Tweetinvi.Models;


/// <summary>
/// Summary description for FollowerClass
/// </summary>
public partial class Followers
{

    public long UserID { get; set; }
    public string UserName { get; set; }
    public Nullable<int> followers_count { get; set; }
    public Nullable<int> friends_count { get; set; }
    public string description { get; set; }
    public Nullable<int> favourites_count { get; set; }
    public string language { get; set; }
    public string country { get; set; }
    public Nullable<int> post_count { get; set; }
    public string screenName { get; set; }
    public string image { get; set; }
    public Followers() { }
    public Followers(IUser user)
    {

        this.UserID = user.Id;
        this.UserName = user.Name;
        this.followers_count = user.FollowersCount;
        this.friends_count = user.FriendsCount;
        this.description = user.Description;
        this.favourites_count = user.FavouritesCount;
        this.language = user.Language.ToString();   //api lang
        this.country = user.TimeZone;
        this.post_count = user.StatusesCount;
        this.screenName = user.ScreenName;
        this.image = user.ProfileImageUrlHttps;




    }

    /// <summary>
    /// This method serializes the tweet to a string
    /// </summary>
    public static string Serializer(Followers line)
    {
        return JsonConvert.SerializeObject(line);
    }

    /// <summary>
    /// This method deserialize the string to Tweet object
    /// </summary>
    /// <param name="line"></param>
    /// <returns></returns>
    public static Followers Deserializer(string line)
    {
        //Tweet decodedTweet = JsonConvert.DeserializeObject<Tweet>(line);
        //return decodedTweet;

        Dictionary<string, string> decodedUser = new Dictionary<string, string>();
        decodedUser = line.Split('\t').Select(
            x => x.Split(new string[] { "::" }, StringSplitOptions.None))
            .ToDictionary(x => x[0], x => x[1]);
        try
        {
            Followers people = new Followers();

            people.UserID = Convert.ToInt64(decodedUser["id"]);
            people.UserName = decodedUser["Name"];
            people.followers_count = Convert.ToInt32(decodedUser["followers_count"]);
            people.description = decodedUser["description"];
            people.friends_count = Convert.ToInt32(decodedUser["friends_count"]);
            people.favourites_count = Convert.ToInt32(decodedUser["favourites_count"]);
            people.post_count = Convert.ToInt32(decodedUser["statuses_count"]);
            people.screenName = decodedUser["screen_name"];
            people.image = decodedUser["profile_image_url"];
            people.language = decodedUser["lang"];
            people.country = decodedUser["Time_zone"];


            return people;
        }
        catch { return null; }

    }
}

