using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class About : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //stream Tweets and save it in Sql Server
        //saveTweets s = new saveTweets();
        // s.save();

        //stream TwitterFollowers and save it in Sql Server

        saveFollowers s = new saveFollowers();
        s.save();
    }
}