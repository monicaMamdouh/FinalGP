using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopPosts.stemming;

namespace TopPosts
{
    class Program
    {
        static void Main(string[] args)
        {
            //cleaning tweets
           /* SqlConnection con = new SqlConnection("Data Source=DESKTOP-FQEB1DN;Initial Catalog=TopPosts ;Integrated Security=True");

            DataTable dataTable = new DataTable();
            SqlCommand cmd = new SqlCommand("select Text from Tweets", con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            dataTable.Load(reader);
            //dataGridView1.DataSource = dataTable;
            foreach (DataRow row in dataTable.Rows)
            {
                string tweetText = row["Text"].ToString().ToLower();

                //cleaning data
                CleaningData c = new CleaningData();
                String cleanedTweet = c.cleanEachTweet(tweetText);
                //stemming
              //  stemmingFunction sf = new stemmingFunction();
              //  string stemmedTweet = sf.stemFunction(cleanedTweet);
                try
                {
                    SqlCommand command = new SqlCommand("INSERT INTO WeightTweet (Tweets,CleanedTweets) VALUES(@b,@c)", con);
                    command.Parameters.AddWithValue("@b", tweetText);
                    command.Parameters.AddWithValue("@c",cleanedTweet);

                    command.ExecuteNonQuery();
                    //  cmd.Dispose();
                }catch { throw; }
                
            }*/


            //give each Tweet Weight
           //Scoring s = new Scoring();
           //s.CalculateDocumentScore();


            
        }
    }
}
