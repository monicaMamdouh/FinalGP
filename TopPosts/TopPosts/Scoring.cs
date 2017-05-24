using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopPosts.VectorSpaceModel;

namespace TopPosts
{
    class Scoring
    {
    
        public void CalculateDocumentScore()
        {
            // Some example documents.
            string[] documents = new string[3000];

            SqlConnection con = new SqlConnection("Data Source=DESKTOP-FQEB1DN;Initial Catalog=TopPosts ;Integrated Security=True");
            con.Open();

            DataTable dataTable = new DataTable();
            SqlCommand cmd = new SqlCommand("select CleanedTweets from WeightTweet ", con);
            SqlDataReader reader = cmd.ExecuteReader();
            dataTable.Load(reader);
            List<string> stemmedDoc = new List<string>();

            for (int i = 0; i < 3000; i++)
            {
                DataRow myRow = dataTable.Rows[i];
                String Text = myRow["CleanedTweets"].ToString().ToLower();
                documents[i] = Text;
            }



            // Apply TF*IDF to the documents and get the resulting vectors.
            double[][] inputs = TFIDF.Transform(documents, 0);
            inputs = TFIDF.Normalize(inputs);
            double totalTweetWeight;
            int k = 1;
            // Display the output.
            for (int index = 0; index < inputs.Length; index++)
            {
                string s = documents[index].ToString();
                Console.WriteLine(s.ToString());
                totalTweetWeight = 0.0;
                foreach (double value in inputs[index])
                {
                    totalTweetWeight += value;
                }

                //Console.WriteLine("\n");
                string query = string.Format("UPDATE WeightTweet SET Weight = '{0}' WHERE CleanedTweets = " + "'"+s+"'"      , totalTweetWeight);
                SqlCommand c = new SqlCommand(query, con);
                c.ExecuteNonQuery();
                //Console.WriteLine(totalTweetWeight);
                k++;
            }

        }
    }
    }

