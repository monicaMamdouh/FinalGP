using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Tweetinvi.Models;
/// <summary>
/// Summary description for TweetClass
/// </summary>

    public partial class Tweets
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public string ScreenName { get; set; }
        public string UserName { get; set; }
        public int Score { get; set; }
        public int Favourites { get; set; }
        public System.DateTime Time { get; set; }
        public long TweetID { get; set; }
        public string Keyword { get; set; }
        public int Retweets { get; set; }
        public Tweets() { }
        public Tweets(ITweet tweet)
        {

            this.Text = tweet.Text;
            this.ScreenName = tweet.CreatedBy.ScreenName;
            this.UserName = tweet.CreatedBy.Name;
            this.Score = Score;
            this.ID = ID;
            this.Favourites = tweet.FavoriteCount;
            this.Time = tweet.CreatedAt;
            this.TweetID = tweet.Id;
            this.Retweets = tweet.RetweetCount;

        }

        /// <summary>
        /// This method serializes the tweet to a string
        /// </summary>
        public static string Serializer(Tweets line)
        {
            return JsonConvert.SerializeObject(line);
        }

        /// <summary>
        /// This method deserialize the string to Tweet object
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public static Tweets Deserializer(string line)
        {
            //Tweet decodedTweet = JsonConvert.DeserializeObject<Tweet>(line);
            //return decodedTweet;

            Dictionary<string, string> decodedTweet = new Dictionary<string, string>();
            decodedTweet = line.Split('\t').Select(
                x => x.Split(new string[] { "::" }, StringSplitOptions.None))
                .ToDictionary(x => x[0], x => x[1]);
            try
            {
                Tweets tweet = new Tweets();
                tweet.TweetID = Convert.ToInt64(decodedTweet["ID"]);
                tweet.Text = decodedTweet["Text"];
                tweet.ScreenName = decodedTweet["screen_name"];
                tweet.UserName = decodedTweet["user_name"];
                tweet.Favourites = Convert.ToInt32(decodedTweet["favourite"]);
                tweet.Retweets = Convert.ToInt32(decodedTweet["retweets"]);
                string timeFormat = "yyyy-MM-dd h:mm:ss tt";
                Console.WriteLine(decodedTweet["Time"]);
                tweet.Time = DateTime.ParseExact(decodedTweet["Time"], timeFormat, CultureInfo.InvariantCulture);
                //tweet.Time = Convert.ToDateTime(decodedTweet["Time"]);
                // tweet.lattitude = Convert.ToDouble(decodedTweet["Lattitude"]);
                // tweet.longitude = Convert.ToDouble(decodedTweet["Longitude"]);

                return tweet;
            }
            catch { return null; }

        }
    }

   /* public partial class Users
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
        public Users() { }
        public Users(IUser user)
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
        public static string Serializer(Users line)
        {
            return JsonConvert.SerializeObject(line);
        }

        /// <summary>
        /// This method deserialize the string to Tweet object
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public static Users Deserializer(string line)
        {
            //Tweet decodedTweet = JsonConvert.DeserializeObject<Tweet>(line);
            //return decodedTweet;

            Dictionary<string, string> decodedUser = new Dictionary<string, string>();
            decodedUser = line.Split('\t').Select(
                x => x.Split(new string[] { "::" }, StringSplitOptions.None))
                .ToDictionary(x => x[0], x => x[1]);
            try
            {
                Users people = new Users();

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

        } */
  
