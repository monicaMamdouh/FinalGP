using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using Tweetinvi;
using Tweetinvi.Models;
using Tweetinvi.Streaming;
using Tweetinvi.Models.DTO;
using Tweetinvi.Models.DTO.QueryDTO;



/// <summary>
/// Summary description for TweetsStream
/// </summary>
public class TweetsStream
{
    
    private static IFilteredStream filteredStream;
    private static IUserStream userStream;




    /// <summary>
    /// Setting up twitter app credentials
    /// </summary>
    public static void SetCredentials()
    {
        //Initializing a Token with Twitter Credentials contained in the App.config 
        //  Auth.SetUserCredentials("NzLProNuLh74Jrj7KfBa8tuSQ", "PYGFqV2vvp5Db4yMCNeDSjsVbCqBh3OKlU1k49g8EnodXFnytk", "831170758885912576-Yls3QWPfauvHoqsjKdBYUxxqKQjYkes", "u6FDWAHfSkEmH145HXD1g3gXbsDp1Di6LAwCEHcGGdsPH");
        ITwitterCredentials creds = new TwitterCredentials("NzLProNuLh74Jrj7KfBa8tuSQ", "PYGFqV2vvp5Db4yMCNeDSjsVbCqBh3OKlU1k49g8EnodXFnytk", "831170758885912576-Yls3QWPfauvHoqsjKdBYUxxqKQjYkes", "u6FDWAHfSkEmH145HXD1g3gXbsDp1Di6LAwCEHcGGdsPH");
        Auth.SetCredentials(creds);
    }

    /// <summary>
    /// This method streams the tweets with given keyword
    /// </summary>
    /// <param name="keyword"></param>
    /// <returns></returns>

    public static List<Tweets> GetTweetsWithKeyword()
    {
        var tweets = default(IEnumerable<ITweet>);
        var downloadedTweets = new List<Tweets>();

        // Search for all tweets published at a specific location
        //var searchParameter = Search.GenerateTweetSearchParameter(-51.5072, 0.1275, 30, DistanceMeasure.Kilometers);
        //  var searchParameter = Search.SearchTweets("https://api.twitter.com/1.1/users/show.json?favourites_count>20");
        filteredStream = Stream.CreateFilteredStream();

        try
        {
            //tweets = Search.SearchTweets(keyword); //unable to stream more than 100 tweets
            // tweets = Search.SearchTweets(keyword);
            //

            // tweets = Timeline.GetUserTimeline("@OfficialHenedy", 200);
            //    var lastTweets = Timeline.GetUserTimeline("@OfficialHenedy", 200).ToArray();
            var lastTweets = Timeline.GetUserTimeline("@imWilISmith", 200).ToArray();


            var allTweets = new List<ITweet>(lastTweets);
            var beforeLast = allTweets;

            while (lastTweets.Length > 0 && allTweets.Count <= 3200)
            {
                var idOfOldestTweet = lastTweets.Select(x => x.Id).Min();


                var timelineRequestParameters = new Tweetinvi.Parameters.UserTimelineParameters
                {
                    // We ensure that we only get tweets that have been posted BEFORE the oldest tweet we received
                    MaxId = idOfOldestTweet - 1,
                    MaximumNumberOfTweetsToRetrieve = allTweets.Count > 3000 ? (3200 - allTweets.Count) : 200
                };

                lastTweets = Timeline.GetUserTimeline("@imWilISmith", timelineRequestParameters).ToArray();

                allTweets.AddRange(lastTweets);
                foreach (var tweet in allTweets)
                {

                    var atweet = new Tweets(tweet);
                    downloadedTweets.Add(atweet);

                }

            }
        }
        catch { }

        return downloadedTweets;
    }

    public static List<Tweets> GetTweetsWithKey(string keyword)
    {
        // var tweets = default(IEnumerable<ITweet>);
        var downloadedTweets = new List<Tweets>();

        // Search for all tweets published at a specific location
        //var searchParameter = Search.GenerateTweetSearchParameter(-51.5072, 0.1275, 30, DistanceMeasure.Kilometers);
        //  var searchParameter = Search.SearchTweets("https://api.twitter.com/1.1/users/show.json?favourites_count>20");
        filteredStream = Stream.CreateFilteredStream();

        try
        {
            //tweets = Search.SearchTweets(keyword); //unable to stream more than 100 tweets
            // tweets = Search.SearchTweets(keyword);
            //

            // tweets = Timeline.GetUserTimeline("@OfficialHenedy", 200);
            //    var lastTweets = Timeline.GetUserTimeline("@OfficialHenedy", 200).ToArray();
            var lastTweets = Search.SearchTweets(keyword).ToArray();


            var allTweets = new List<ITweet>(lastTweets);
            var beforeLast = allTweets;
            while (lastTweets.Length > 0 && allTweets.Count <= 3000)
            {
                var idOfOldestTweet = lastTweets.Select(x => x.Id).Min();

                var searchParameter = new Tweetinvi.Parameters.SearchTweetsParameters(keyword);
                searchParameter.MaxId = idOfOldestTweet - 1;
                //searchParameter.SearchType = SearchResultType.Popular;
                searchParameter.MaximumNumberOfResults = allTweets.Count > 2800 ? (3000 - allTweets.Count) : 200;


                lastTweets = Search.SearchTweets(searchParameter).ToArray();

                allTweets.AddRange(lastTweets);
                foreach (var tweet in allTweets)
                {

                    var atweet = new Tweets(tweet);
                    downloadedTweets.Add(atweet);
                }
            } }
        catch { }
        
        return downloadedTweets;
    }



}