using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using CsvHelper;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInterestClassification
{
    class fromCsvtoSQL
    {

        public void readFromCsvTosql()
        {
            //Read Training Data from csv file 
            //save it in sqlServer
           
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-FQEB1DN;Initial Catalog=UserInterestClassification ;Integrated Security=True");
            //arts
            StreamReader readFile = new StreamReader(@"C:\Users\monica\Desktop\مشروع التخرج\arts.csv");
            var csv = new CsvReader(readFile);
            //business
            StreamReader readFile1 = new StreamReader(@"C:\Users\monica\Desktop\مشروع التخرج\business.csv");
            var csv1 = new CsvReader(readFile1);
            //education
            StreamReader readFile2 = new StreamReader(@"C:\Users\monica\Desktop\مشروع التخرج\education.csv");
            var csv2 = new CsvReader(readFile2);
            //fashion
            StreamReader readFile3 = new StreamReader(@"C:\Users\monica\Desktop\مشروع التخرج\fashion.csv");
            var csv3 = new CsvReader(readFile3);
            //food
            StreamReader readFile4 = new StreamReader(@"C:\Users\monica\Desktop\مشروع التخرج\food.csv");
            var csv4 = new CsvReader(readFile4);
            //music
            StreamReader readFile5 = new StreamReader(@"C:\Users\monica\Desktop\مشروع التخرج\music.csv");
            var csv5 = new CsvReader(readFile5);
            //news
            StreamReader readFile6 = new StreamReader(@"C:\Users\monica\Desktop\مشروع التخرج\news.csv");
            var csv6 = new CsvReader(readFile6);
            //politics
            StreamReader readFile7 = new StreamReader(@"C:\Users\monica\Desktop\مشروع التخرج\politics.csv");
            var csv7 = new CsvReader(readFile7);
            //sports
            StreamReader readFile8 = new StreamReader(@"C:\Users\monica\Desktop\مشروع التخرج\sports.csv");
            var csv8 = new CsvReader(readFile8);
            //technology
            StreamReader readFile9 = new StreamReader(@"C:\Users\monica\Desktop\مشروع التخرج\technology.csv");
            var csv9 = new CsvReader(readFile9);
            con.Open();


            while (csv.Read())
            {

                try
                {
                    var tweet = csv.GetField<string>("user");
                    var category = csv.GetField<string>("type");

                    SqlCommand c = new SqlCommand("INSERT INTO TrainingTweets (Text,category) VALUES(@g,@d)", con);

                    c.Parameters.AddWithValue("@g", tweet);
                    c.Parameters.AddWithValue("@d", category);

                    c.ExecuteNonQuery();

                }
                catch { throw; }
            }

            
            while (csv1.Read())
            {

                try
                {
                    var tweet = csv1.GetField<string>("user");
                    var category = csv1.GetField<string>("type");

                    SqlCommand c1 = new SqlCommand("INSERT INTO TrainingTweets (Text,category) VALUES(@g1,@d1)", con);

                    c1.Parameters.AddWithValue("@g1", tweet);
                    c1.Parameters.AddWithValue("@d1", category); 

                    c1.ExecuteNonQuery();

                }
                catch { throw; }

            } 
            while (csv2.Read())
            {

                try
                {
                    var tweet = csv2.GetField<string>("user");
                    var category = csv2.GetField<string>("type");

                    SqlCommand c2 = new SqlCommand("INSERT INTO TrainingTweets (Text,category) VALUES(@g2,@d2)", con);

                    c2.Parameters.AddWithValue("@g2", tweet);
                    c2.Parameters.AddWithValue("@d2", category);

                    c2.ExecuteNonQuery();

                }
                catch { throw; }

            }
            while (csv3.Read())
            {

                try
                {
                    var tweet = csv3.GetField<string>("user");
                    var category = csv3.GetField<string>("type");

                    SqlCommand c3 = new SqlCommand("INSERT INTO TrainingTweets (Text,category) VALUES(@g3,@d3)", con);

                    c3.Parameters.AddWithValue("@g3", tweet);
                    c3.Parameters.AddWithValue("@d3", category);

                    c3.ExecuteNonQuery();

                }
                catch { throw; }

            }
            while (csv4.Read())
            {

                try
                {
                    var tweet = csv4.GetField<string>("user");
                    var category = csv4.GetField<string>("type");

                    SqlCommand c4 = new SqlCommand("INSERT INTO TrainingTweets (Text,category) VALUES(@g4,@d4)", con);

                    c4.Parameters.AddWithValue("@g4", tweet);
                    c4.Parameters.AddWithValue("@d4", category);

                    c4.ExecuteNonQuery();

                }
                catch { throw; }

            }
            while (csv5.Read())
            {

                try
                {
                    var tweet = csv5.GetField<string>("user");
                    var category = csv5.GetField<string>("type");

                    SqlCommand c5 = new SqlCommand("INSERT INTO TrainingTweets (Text,category) VALUES(@g5,@d5)", con);

                    c5.Parameters.AddWithValue("@g5", tweet);
                    c5.Parameters.AddWithValue("@d5", category);

                    c5.ExecuteNonQuery();

                }
                catch { throw; }

            }
            while (csv6.Read())
            {

                try
                {
                    var tweet = csv6.GetField<string>("user");
                    var category = csv6.GetField<string>("type");

                    SqlCommand c6 = new SqlCommand("INSERT INTO TrainingTweets (Text,category) VALUES(@g6,@d6)", con);

                    c6.Parameters.AddWithValue("@g6", tweet);
                    c6.Parameters.AddWithValue("@d6", category);

                    c6.ExecuteNonQuery();

                }
                catch { throw; }

            }
            while (csv7.Read())
            {

                try
                {
                    var tweet = csv7.GetField<string>("user");
                    var category = csv7.GetField<string>("type");

                    SqlCommand c7 = new SqlCommand("INSERT INTO TrainingTweets (Text,category) VALUES(@g7,@d7)", con);

                    c7.Parameters.AddWithValue("@g7", tweet);
                    c7.Parameters.AddWithValue("@d7", category);

                    c7.ExecuteNonQuery();

                }
                catch { throw; }

            }
            while (csv8.Read())
            {

                try
                {
                    var tweet = csv8.GetField<string>("user");
                    var category = csv8.GetField<string>("type");

                    SqlCommand c8 = new SqlCommand("INSERT INTO TrainingTweets (Text,category) VALUES(@g8,@d8)", con);

                    c8.Parameters.AddWithValue("@g8", tweet);
                    c8.Parameters.AddWithValue("@d8",category);

                    c8.ExecuteNonQuery();

                }
                catch { throw; }

            }
            while (csv9.Read())
            {

                try
                {
                    var tweet = csv9.GetField<string>("user");
                    var category = csv9.GetField<string>("type");

                    SqlCommand c9= new SqlCommand("INSERT INTO TrainingTweets (Text,category) VALUES(@g9,@d9)", con);

                    c9.Parameters.AddWithValue("@g9", tweet);
                    c9.Parameters.AddWithValue("@d9", category);

                    c9.ExecuteNonQuery();

                }
                catch { throw; }

            }
            con.Dispose();
        }
    }
}
