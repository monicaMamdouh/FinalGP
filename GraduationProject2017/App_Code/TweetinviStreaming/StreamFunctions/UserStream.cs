using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using Tweetinvi;
using Tweetinvi.Models;
using Tweetinvi.Streaming;
using System;
using Tweetinvi.Models.DTO.QueryDTO;

/// <summary>
/// Summary description for UserStream
/// </summary>
public class UserStream
{

    private static IUserStream filteredStream;



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
    public static List<Followers> GetUsers(List<string> n)
    {

        filteredStream = Stream.CreateUserStream();

        List<Followers> peopleList = new List<Followers>();
        var users = default(IEnumerable<IUser>);
        List<string> first = new List<string>();

        try
        {

            users = User.GetUsersFromScreenNames(n).ToArray();


        }
        catch { }
        if (users != null && users.Count() > 0)
        {

            foreach (var user in users)
            {

                var us = new Followers(user);
                peopleList.Add(us);

            }
        }
        return peopleList;


    }
    public static List<Followers> GetUsersFollowes(String screenName)
    {
        RateLimit.RateLimitTrackerMode = RateLimitTrackerMode.TrackOnly;
        var fIds = new List<long>();
        long nextCursor = -1;


        var followerIds = GetFollowerIds(screenName, nextCursor, out nextCursor);
        fIds.AddRange(followerIds.SelectMany(x => x.Ids));

        // Your method to process the follower ids : ProcessFollowerIds(followerIds);



        filteredStream = Stream.CreateUserStream();
        List<Followers> peopleList = new List<Followers>();
        var users = default(IEnumerable<IUser>);
        IUser U = User.GetUserFromScreenName(screenName);


        try
        {


            users = User.GetUsersFromIds(fIds);
        }
        catch { }
        if (users != null && users.Count() > 0)
        {

            foreach (var user in users)
            {

                var us = new Followers(user);
                peopleList.Add(us);

            }
        }
        return peopleList;

    }
    private static IEnumerable<IIdsCursorQueryResultDTO> GetFollowerIds(string username, long cursor, out long nextCursor)
    {
        var query = string.Format("https://api.twitter.com/1.1/followers/ids.json?screen_name={0}&count=5000", username);

        // Ensure that we can get some information
        RateLimit.AwaitForQueryRateLimit(query);
        var results = TwitterAccessor.ExecuteCursorGETCursorQueryResult<IIdsCursorQueryResultDTO>(query, cursor: cursor).ToArray();

        if (!results.Any())
        {
            // Something went wrong. The RateLimits operation tokens got used before we performed our query
            RateLimit.ClearRateLimitCache();
            RateLimit.AwaitForQueryRateLimit(query);
            results = TwitterAccessor.ExecuteCursorGETCursorQueryResult<IIdsCursorQueryResultDTO>(query, cursor: cursor).ToArray();
        }

        if (results.Any())
        {
            nextCursor = results.Last().NextCursor;
        }
        else
        {
            nextCursor = -1;
        }

        return results;
    }


}